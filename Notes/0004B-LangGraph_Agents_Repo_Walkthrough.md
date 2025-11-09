Great — here are **five public repositories** you can study to see how others have built agents using LangGraph (and adapt to build your own). I’ll include a short summary for each, what makes them interesting, and what to pay attention to.

---

| # | Repository                                                                                                                                                                | What you’ll learn / why it’s useful                                                                                                                                              |
| - | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 1 | langgraph-example (by the core team) – [GitHub](https://github.com/langchain-ai/langgraph-example) ([GitHub][1])                                                          | This is a canonical “starter” example from the creators of LangGraph. It shows basic usage of graphs/agents, gives you a minimal working setup. Good for understanding core API. |
| 2 | langgraph-agentic-workflow (by safzanpirani) – [GitHub](https://github.com/safzanpirani/langgraph-agentic-workflow) ([GitHub][2])                                         | A self‑correcting RAG workflow (Retrieval‑Augmented Generation) built with LangGraph. Useful to see how retrieval + tool + feedback loops are implemented.                       |
| 3 | fastapi-langgraph-agent-production-ready-template (by wassim249) – [GitHub](https://github.com/wassim249/fastapi-langgraph-agent-production-ready-template) ([GitHub][3]) | A production‑ready template combining LangGraph + FastAPI + monitoring + persistence. Good if you want to build something that can scale.                                        |
| 4 | langgraph-multi-agent (by AWS samples) – [GitHub](https://github.com/aws-samples/langgraph-multi-agent) ([GitHub][4])                                                     | Demonstrates multi‐agent workflows: breaking tasks into specialised agents, orchestrating between them. Good for advanced architecture ideas.                                    |
| 5 | langgraph-agents-template (by panaversity) – [GitHub](https://github.com/panaversity/langgraph-agents-template) ([GitHub][5])                                             | A starter template meant for building multi‐agent systems. Clean directory structure, good for “starting from scratch” with your own custom workflow.                            |

---

### 🔍 Tips on what to inspect in each repo

* How they define the **graph / nodes / edges**: what actions, decisions, tools each node corresponds to.
* How the agent loop is structured: when does the LLM decide what tool to call next, when does it stop. (See docs: “an agent consists of an LLM + a set of tools + prompt” in LangGraph. ([Langchain AI][6])
* How they integrate **tools** (retrieval, computation, API calls) – see how tool invocation and observation happen.
* How they manage **state/memory**: short‑term and long‑term memory, persistence across sessions. ([Langchain AI][6])
* How they structure multi-agent/dialogue (if applicable): one agent supervises, or multiple specialists. (See multi‑agent doc) ([Langchain AI][7])
* How they deploy / serve the agent: APIs, streaming, UI, etc (especially in production templates).
* How branching/loops are handled: agents often need cycles or revisits, LangGraph supports that. (In docs) ([Langchain AI][8])

---

If you like, I can **pick 2‑3 of these repos and walk you through key code files** (for example: `graph.py`, `agent.py`, `tool_invocation.py`) and explain how they work line by line. Would that be useful for you?

[1]: https://github.com/langchain-ai/langgraph-example?utm_source=chatgpt.com "langchain-ai/langgraph-example - GitHub"
[2]: https://github.com/safzanpirani/langgraph-agentic-workflow?utm_source=chatgpt.com "LangGraph Agentic RAG Workflow - GitHub"
[3]: https://github.com/wassim249/fastapi-langgraph-agent-production-ready-template?utm_source=chatgpt.com "wassim249/fastapi-langgraph-agent-production-ready-template"
[4]: https://github.com/aws-samples/langgraph-multi-agent?utm_source=chatgpt.com "aws-samples/langgraph-multi-agent - GitHub"
[5]: https://github.com/panaversity/langgraph-agents-template?utm_source=chatgpt.com "panaversity/langgraph-agents-template: Starter template to ... - GitHub"
[6]: https://langchain-ai.github.io/langgraph/agents/overview/?utm_source=chatgpt.com "Agent development with LangGraph"
[7]: https://langchain-ai.github.io/langgraph/concepts/multi_agent/?utm_source=chatgpt.com "LangGraph Multi-Agent Systems - Overview"
[8]: https://langchain-ai.github.io/langgraph/tutorials/workflows/?utm_source=chatgpt.com "Workflows & agents - GitHub Pages"
