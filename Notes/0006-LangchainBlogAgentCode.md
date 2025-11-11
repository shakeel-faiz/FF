Here is an updated version of the script for **LangChain v1** (i.e., version 1.0+) that uses the new `create_agent` API and middleware patterns described in the official docs. ([LangChain Docs][1])

```python
# ai_blog_publisher_v1.py
"""
An agent workflow using LangChain v1:
1. Research hot topics via a web search tool.
2. Generate a blog post via LLM.
3. Critique the post; optionally loop.
4. Publish to GitHub.

Requirements:
    pip install langchain openai python-dotenv PyGithub serpapi
Environment variables:
    OPENAI_API_KEY, SERPAPI_API_KEY, GITHUB_TOKEN, GITHUB_REPO, GITHUB_BLOG_PATH
"""

import os
import datetime
import json
import argparse
import textwrap
from typing import List, Dict, Optional

from dotenv import load_dotenv
load_dotenv()

OPENAI_API_KEY = os.getenv("OPENAI_API_KEY")
SERPAPI_API_KEY = os.getenv("SERPAPI_API_KEY")
GITHUB_TOKEN = os.getenv("GITHUB_TOKEN")
GITHUB_REPO = os.getenv("GITHUB_REPO")
GITHUB_BLOG_PATH = os.getenv("GITHUB_BLOG_PATH", "content/posts/")

if not OPENAI_API_KEY:
    raise RuntimeError("OPENAI_API_KEY is required")

# Import LangChain v1 components
from langchain.chat_models import init_chat_model
from langchain.messages import SystemMessage, HumanMessage, AIMessage
from langchain.tools import tool
from langchain.agents import create_agent
from langchain.agents.middleware import AgentMiddleware
from github import Github

# Initialize LLM
llm = init_chat_model("gpt-4o-mini", openai_api_key=OPENAI_API_KEY, temperature=0.2)

# --- Search tool ---
@tool
def web_search(query: str, max_results: int = 5) -> List[Dict[str, str]]:
    """Perform web search and return list of {title, snippet, link}."""
    if not SERPAPI_API_KEY:
        return []
    from langchain.utilities import SerpAPIWrapper
    serp = SerpAPIWrapper(serpapi_api_key=SERPAPI_API_KEY)
    raw = serp.results(query)
    organic = raw.get("organic_results") or []
    results = []
    for r in organic[:max_results]:
        results.append({
            "title": r.get("title",""),
            "snippet": r.get("snippet",""),
            "link": r.get("link","")
        })
    return results

# --- Blog generation tool ---
@tool
def generate_blog(topic: str, research_notes: str, style: str = "informal but professional", word_count: int = 800) -> str:
    prompt = f"""
You are an expert technical blog writer. Write a well-structured blog post about "{topic}".
Use the following research notes (summarize + cite inline links):
{research_notes}

Style guidelines:
- Tone: {style}
- Include an intro, 3-6 subheadings, a conclusion, and a short TL;DR at the top.
- Target length: approximately {word_count} words.
- Provide 3 suggested tags at the end and a suggested slug.

Write in Markdown.
"""
    resp = llm.invoke([HumanMessage(prompt)])
    return resp.text

# --- Critique tool ---
@tool
def critique_blog(markdown: str) -> Dict:
    prompt = f"""
You are an experienced editor. Critique the following Markdown blog post for clarity, technical accuracy, and reader value.
Return a JSON object with fields:
{{ "score": int(1-100), "issues": [list of short strings], "suggested_changes": "text of suggested edits or rewritten sections" }}
Post:
{markdown}
"""
    resp = llm.invoke([HumanMessage(prompt)])
    try:
        # assume JSON starts at first "{"
        json_start = resp.text.find("{")
        crit = json.loads(resp.text[json_start:])
        return crit
    except Exception:
        return {"score":60, "issues":["Could not parse critique output"], "suggested_changes": resp.text}

# --- GitHub publish tool ---
@tool
def publish_to_github(title: str, markdown: str) -> Dict:
    if not GITHUB_TOKEN:
        raise RuntimeError("GITHUB_TOKEN is required")
    gh = Github(GITHUB_TOKEN)
    repo = gh.get_repo(GITHUB_REPO)
    date_str = datetime.datetime.utcnow().strftime("%Y-%m-%d")
    slug = title.lower().strip().replace(" ", "-").replace("/", "-")
    filename = f"{GITHUB_BLOG_PATH}{date_str}-{slug}.md"
    front = textwrap.dedent(f"""
    ---
    title: "{title}"
    date: {date_str}
    slug: {slug}
    tags: []
    draft: false
    ---
    """).lstrip()
    full_md = front + "\n" + markdown
    try:
        commit_msg = f"chore: add post {title}"
        repo.create_file(filename, commit_msg, full_md)
        return {"status":"created", "path":filename, "commit_message":commit_msg}
    except Exception as e:
        if "already exists" in str(e) or "exists" in str(e):
            ts = datetime.datetime.utcnow().strftime("%H%M%S")
            filename = f"{GITHUB_BLOG_PATH}{date_str}-{slug}-{ts}.md"
            repo.create_file(filename, commit_msg, full_md)
            return {"status":"created_with_suffix", "path":filename, "commit_message":commit_msg}
        else:
            raise

# --- Optional Middleware (for example, limit number of searches) ---
class SearchLimitMiddleware(AgentMiddleware):
    def __init__(self, max_calls_per_run: int = 3):
        self.max_calls = max_calls_per_run
        self.calls = 0

    def wrap_tool_call(self, request, handler):
        if request.tool.name == "web_search":
            self.calls += 1
            if self.calls > self.max_calls:
                # block further search calls
                return AIMessage(content="\"search_exhausted\"")
        return handler(request)

# --- Assemble agent ---
agent = create_agent(
    model=llm,
    tools=[web_search, generate_blog, critique_blog, publish_to_github],
    system_prompt="You are an autonomous blog-post agent. Follow steps: research => generate => critique => publish.",
    middleware=[SearchLimitMiddleware(max_calls_per_run=2)]
)

# --- Invocation / CLI ---
def main():
    parser = argparse.ArgumentParser(description="LangChain v1 blog publisher agent")
    parser.add_argument('--query', required=True, help='Topic query to research')
    parser.add_argument('--style', default='informal but professional')
    parser.add_argument('--word_count', type=int, default=800)
    parser.add_argument('--no_publish', action='store_true')
    args = parser.parse_args()

    messages = [HumanMessage(f"Research topic: {args.query}. Then generate a blog post accordingly.")]
    result = agent.invoke({"messages": messages})
    print(json.dumps(result, indent=2))

if __name__ == "__main__":
    main()
```

### Notes & Differences for v1

* Use `create_agent(...)` from `langchain.agents`. ([LangChain Docs][1])
* Tools are defined via the `@tool` decorator or as callables, and passed into the agent. ([LangChain Docs][2])
* Middleware can intercept or govern model/tool calls (e.g., limit searches). ([LangChain Docs][1])
* Message types (`SystemMessage`, `HumanMessage`, `AIMessage`) are used for structured interactions. ([LangChain Docs][3])
* The main loop is now `agent.invoke(...)`.
* Structured output strategies (if needed) use `ToolStrategy` or `ProviderStrategy` (not shown here for brevity). ([LangChain Docs][2])

---

If you like, I can **adapt this script fully for your workflow** (research → generate → critique → publish) *and* include a full **LangGraph orchestration version** side-by-side (since v1 supports both). Would you like that?

[1]: https://docs.langchain.com/oss/python/releases/langchain-v1?utm_source=chatgpt.com "What's new in v1 - Docs by LangChain"
[2]: https://docs.langchain.com/oss/python/migrate/langchain-v1?utm_source=chatgpt.com "LangChain v1 migration guide"
[3]: https://docs.langchain.com/oss/python/langchain/messages?utm_source=chatgpt.com "Messages - Docs by LangChain"
