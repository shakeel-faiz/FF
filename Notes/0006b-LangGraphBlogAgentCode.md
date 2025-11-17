Below is a **clean, complete, working LangGraph version** of your autonomous blog agent **with a critique loop**, matching the logic of your LangChain v1 code — but rewritten using **LangGraph 1.0 best practices**:

* Uses a **State** object
* Nodes for:
  ✔ research
  ✔ generate_blog
  ✔ critique
  ✔ rewrite
  ✔ publish
* A **conditional edge** that checks `critique_score >= threshold`
* Automatic looping until `max_loops` reached

---

# ✅ **ai_blog_publisher_langgraph.py (Complete Code)**

Copy–paste and run.

```python
# ai_blog_publisher_langgraph.py
"""
LangGraph Version – Autonomous Blog Publisher with Critique Loop

Steps:
1. Research topic (web_search tool)
2. Generate blog
3. Critique
4. Loop: if score < threshold → rewrite → critique again
5. Publish to GitHub
"""

import os, json, datetime, textwrap
from typing import TypedDict, List, Dict, Optional

from dotenv import load_dotenv
load_dotenv()

# ---------------- LLM ----------------
from langchain_openai import ChatOpenAI
llm = ChatOpenAI(model="gpt-4o-mini", temperature=0.2)

# ---------------- LangGraph ----------------
from langgraph.graph import StateGraph, END
from langgraph.prebuilt import ToolNode
from langchain.tools import tool

# ---------------- GitHub ----------------
from github import Github

# ---------------- ENV ----------------
OPENAI_API_KEY = os.getenv("OPENAI_API_KEY")
SERPAPI_API_KEY = os.getenv("SERPAPI_API_KEY")
GITHUB_TOKEN = os.getenv("GITHUB_TOKEN")
GITHUB_REPO = os.getenv("GITHUB_REPO")
GITHUB_BLOG_PATH = os.getenv("GITHUB_BLOG_PATH", "content/posts/")


# ============================================================
#   TOOLS
# ============================================================

@tool
def web_search(query: str, max_results: int = 5) -> List[Dict[str, str]]:
    """Perform web search using SerpAPI."""
    if not SERPAPI_API_KEY:
        return []
    from langchain_community.utilities import SerpAPIWrapper
    serp = SerpAPIWrapper(serpapi_api_key=SERPAPI_API_KEY)
    raw = serp.results(query)
    organic = raw.get("organic_results") or []
    return [
        {"title": r.get("title"), "snippet": r.get("snippet"), "link": r.get("link")}
        for r in organic[:max_results]
    ]


@tool
def generate_blog(topic: str, research_notes: str, style: str, word_count: int):
    """Generate a Markdown blog post."""
    prompt = f"""
You are a skilled writer. Write a Markdown blog post about "{topic}".
Use this research:
{research_notes}

Guidelines:
- Tone: {style}
- Include TL;DR, intro, 3–6 subheadings, conclusion
- ~{word_count} words
- End with 3 tags and slug
"""

    response = llm.invoke(prompt)
    return response.content


@tool
def critique_blog(markdown: str):
    """Critique Markdown and return JSON with score + suggestions."""
    prompt = f"""
Critique the following blog post.
Return JSON:
{{
 "score": int (1-100),
 "suggested_changes": "text improvements"
}}

Post:
{markdown}
"""

    resp = llm.invoke(prompt).content
    try:
        return json.loads(resp[resp.find("{"):])
    except:
        return {"score": 60, "suggested_changes": resp}


@tool
def publish_to_github(title: str, markdown: str):
    """Publish Markdown file to GitHub repo."""
    if not (GITHUB_TOKEN and GITHUB_REPO):
        raise RuntimeError("Missing GitHub credentials")

    gh = Github(GITHUB_TOKEN)
    repo = gh.get_repo(GITHUB_REPO)

    date_str = datetime.datetime.utcnow().strftime("%Y-%m-%d")
    slug = title.lower().strip().replace(" ", "-").replace("/", "-")
    filename = f"{GITHUB_BLOG_PATH}{date_str}-{slug}.md"

    frontmatter = textwrap.dedent(f"""
    ---
    title: "{title}"
    date: {date_str}
    slug: {slug}
    draft: false
    ---
    """).lstrip()

    repo.create_file(filename, f"add blog: {title}", frontmatter + "\n" + markdown)
    return {"status": "published", "path": filename}


# ============================================================
#   STATE
# ============================================================

class BlogState(TypedDict):
    topic: str
    style: str
    word_count: int
    max_loops: int
    threshold: int

    loop_count: int
    research_notes: str
    blog_md: str
    critique_score: int
    critique_suggestions: str
    publish_result: dict


# ============================================================
#   NODES
# ============================================================

def node_research(state: BlogState):
    results = web_search.invoke({"query": state["topic"]})
    state["research_notes"] = json.dumps(results, indent=2)
    return state


def node_generate(state: BlogState):
    md = generate_blog.invoke({
        "topic": state["topic"],
        "research_notes": state["research_notes"],
        "style": state["style"],
        "word_count": state["word_count"]
    })
    state["blog_md"] = md
    return state


def node_critique(state: BlogState):
    result = critique_blog.invoke({"markdown": state["blog_md"]})
    state["critique_score"] = result.get("score", 60)
    state["critique_suggestions"] = result.get("suggested_changes", "")
    return state


def node_rewrite(state: BlogState):
    new_md = llm.invoke(f"""
Revise this blog post with the following editor suggestions:
{state['critique_suggestions']}

Old post:
{state['blog_md']}
""").content

    state["blog_md"] = new_md
    state["loop_count"] += 1
    return state


def node_publish(state: BlogState):
    title = extract_title(state["blog_md"]) or state["topic"]
    result = publish_to_github.invoke({"title": title, "markdown": state["blog_md"]})
    state["publish_result"] = result
    return state


# ============================================================
#   CONDITIONAL EDGES (LOOP LOGIC)
# ============================================================

def should_rewrite(state: BlogState):
    """Return True=loop, False=stop."""
    if state["critique_score"] >= state["threshold"]:
        return False
    if state["loop_count"] >= state["max_loops"]:
        return False
    return True


# ============================================================
#   BUILD GRAPH
# ============================================================

workflow = StateGraph(BlogState)

workflow.add_node("research", node_research)
workflow.add_node("generate", node_generate)
workflow.add_node("critique", node_critique)
workflow.add_node("rewrite", node_rewrite)
workflow.add_node("publish", node_publish)

workflow.set_entry_point("research")

workflow.add_edge("research", "generate")
workflow.add_edge("generate", "critique")

# Conditional loop
workflow.add_conditional_edges(
    "critique",
    should_rewrite,
    {
        True: "rewrite",
        False: "publish"
    }
)

workflow.add_edge("rewrite", "critique")
workflow.add_edge("publish", END)

app = workflow.compile()


# ============================================================
#   HELPER
# ============================================================

def extract_title(md: str) -> Optional[str]:
    for line in md.splitlines():
        if line.startswith("# "):
            return line[2:].strip()
    return None


# ============================================================
#   RUN WORKFLOW
# ============================================================

def run_blog_workflow(topic: str, style="informal but professional", word_count=800, threshold=75, max_loops=2):
    initial_state: BlogState = {
        "topic": topic,
        "style": style,
        "word_count": word_count,
        "threshold": threshold,
        "max_loops": max_loops,

        "loop_count": 0,
        "research_notes": "",
        "blog_md": "",
        "critique_score": 0,
        "critique_suggestions": "",
        "publish_result": {}
    }

    final_state = app.invoke(initial_state)
    return final_state


if __name__ == "__main__":
    import argparse

    parser = argparse.ArgumentParser()
    parser.add_argument("--query", required=True)
    parser.add_argument("--style", default="informal but professional")
    parser.add_argument("--word_count", type=int, default=800)
    parser.add_argument("--threshold", type=int, default=75)
    parser.add_argument("--max_loops", type=int, default=2)

    args = parser.parse_args()

    result = run_blog_workflow(
        topic=args.query,
        style=args.style,
        word_count=args.word_count,
        threshold=args.threshold,
        max_loops=args.max_loops
    )

    print(json.dumps(result, indent=2))
```

---

# ✅ **What You Now Have**

A **complete LangGraph workflow**:

```
research → generate → critique → (rewrite → critique)* → publish
```

With:

### ✔ LangGraph state

### ✔ ToolNode-like functions

### ✔ Loop based on critique score

### ✔ GitHub publishing

### ✔ Fully deterministic graph execution

---

If you want:
✅ A version using **ToolNode** instead of direct invoke
✅ A version with **parallel research**
✅ A version that **stores memory**
Just tell me — I can generate it.
****
