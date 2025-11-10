## Most Recent Code

```
# file: langgraph_conversational_agent.py
import operator
from typing import Annotated, TypedDict, List
from langchain_core.messages import AnyMessage, HumanMessage, AIMessage, ToolMessage
from langgraph.graph import StateGraph, START, END
from langgraph.prebuilt import ToolNode, tools_condition
# Use the correct class name: TavilySearch
from langchain_tavily import TavilySearch
from langchain_openai import ChatOpenAI
from langchain_core.tools import tool

# -----------------------------
# 1. Define the MessageState
# Use operator.add for message accumulation
# -----------------------------
class MessageState(TypedDict):
    messages: Annotated[List[AnyMessage], operator.add]

# -----------------------------
# 2. Define tools
# -----------------------------
# Example: web search. Note the class name change.
tavily_tool = TavilySearch(max_results=3)

# Example: simple Python functions
@tool
def multiply(a: int, b: int) -> int:
    """Multiply two numbers"""
    return a * b

@tool
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

tools_list = [tavily_tool, multiply, add]

# -----------------------------
# 3. Bind tools to LLM
# -----------------------------
llm_with_tool = ChatOpenAI(model='gpt-4o-mini', temperature=0).bind_tools(tools_list)

# -----------------------------
# 4. Define LLM node
# -----------------------------
def llm_chatbot(state: MessageState):
    """Node for AI conversation"""
    return {'messages': [llm_with_tool.invoke(state['messages'])]}

# -----------------------------
# 5. Define ToolNode
# -----------------------------
tool_node = ToolNode(tools_list)

# -----------------------------
# 6. Build StateGraph
# -----------------------------
builder = StateGraph(MessageState)
builder.add_node('LLM', llm_chatbot)
builder.add_node('tools', tool_node)

builder.add_edge(START, 'LLM')

builder.add_conditional_edges(
    'LLM',
    tools_condition,
)

builder.add_edge('tools', 'LLM')

app = builder.compile()

# -----------------------------
# 7. Example invocations
# -----------------------------
print("=== Example 1: Direct LLM Response ===")
msg = app.invoke({'messages': [HumanMessage(content="Hi AI! How are you?")]})
for m in msg['messages']:
    m.pretty_print()

print("\n=== Example 2: Tool Call ===")
msg = app.invoke({'messages': [
    HumanMessage(content="Tell me about Air India Ahmedabad plane crash and multiply 10 by 2")
]})
for m in msg['messages']:
    m.pretty_print()

```

## Old Code and Read Me
Sure! I’ll give you a **complete, runnable example** of a LangGraph conversational agent with:

* `MessageState` to maintain conversation history
* LLM node that can call tools
* `ToolNode` that executes tools automatically
* Conditional routing (`tools_condition`)

This is **self-contained**, assuming you have LangGraph, LangChain, and TavilySearch installed and an OpenAI API key.

```python
# file: langgraph_conversational_agent.py
from typing import Annotated, TypedDict, List
from langchain_core.messages import AnyMessage, HumanMessage, AIMessage
from langgraph.graph import StateGraph, START, END
from langgraph.graph.message import add_messages
from langgraph.prebuilt import ToolNode, tools_condition
from langchain_community.tools.tavily_search import TavilySearchResults
from langchain_openai import ChatOpenAI
from langchain_core.tools import tool

# -----------------------------
# 1. Define the MessageState
# -----------------------------
class MessageState(TypedDict):
    messages: Annotated[List[AnyMessage], add_messages]

# -----------------------------
# 2. Define tools
# -----------------------------
# Example: web search
tavily_tool = TavilySearchResults(max_results=3)

# Example: simple Python functions
@tool
def multiply(a: int, b: int) -> int:
    """Multiply two numbers"""
    return a * b

@tool
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

tools_list = [tavily_tool, multiply, add]

# -----------------------------
# 3. Bind tools to LLM
# -----------------------------
llm_with_tool = ChatOpenAI(model='gpt-4o-mini').bind_tools(tools_list)

# -----------------------------
# 4. Define LLM node
# -----------------------------
def llm_chatbot(state: MessageState):
    """Node for AI conversation"""
    return {'messages': [llm_with_tool.invoke(state['messages'])]}

# -----------------------------
# 5. Define ToolNode
# -----------------------------
tool_node = ToolNode(tools_list)

# -----------------------------
# 6. Build StateGraph
# -----------------------------
build = StateGraph(MessageState)
build.add_node('LLM', llm_chatbot)
build.add_node('tools', tool_node)

# Start workflow
build.add_edge(START, 'LLM')

# Conditional edge: if LLM requests a tool, route to ToolNode
build.add_conditional_edges(
    'LLM',
    tools_condition,  # prebuilt condition function
    # By default, tools_condition maps tool calls to 'tools'
)

# After tools run, return to LLM for next step
build.add_edge('tools', 'LLM')

# Compile workflow
app = build.compile()

# -----------------------------
# 7. Example invocations
# -----------------------------
# 1️⃣ LLM responds directly
print("=== Example 1: Direct LLM Response ===")
msg = app.invoke({'messages': [HumanMessage(content="Hi AI! How are you?")]})
for m in msg['messages']:
    m.pretty_print()

# 2️⃣ LLM calls tools
print("\n=== Example 2: Tool Call ===")
msg = app.invoke({'messages': [
    HumanMessage(content="Tell me about Air India Ahmedabad plane crash and multiply 10 by 2")
]})
for m in msg['messages']:
    m.pretty_print()
```

---

### ✅ How it works

1. `MessageState` keeps the conversation history using `add_messages`.
2. `llm_chatbot` node sends messages to the LLM.
3. If the LLM requests a tool:

   * `tools_condition` detects it
   * Routes to `ToolNode`
   * Executes requested tools
4. Updated tool outputs return to LLM for **final reasoning**.
5. All messages (AI, Human, Tool) are appended to `messages` and preserved.

---

💡 **Next steps to test it:**

1. Install dependencies:

```bash
pip install langgraph langchain langchain-community openai
```

2. Set your **OpenAI API key**:

```bash
export OPENAI_API_KEY="your_api_key_here"  # Linux/Mac
setx OPENAI_API_KEY "your_api_key_here"     # Windows
```

3. Run the script:

```bash
python langgraph_conversational_agent.py
```

You’ll see **AI messages, tool call messages, and final combined responses**.

---

If you want, I can also **add a feature to let the agent handle multiple consecutive user messages in a loop**, so it behaves like a **real chat session**.

Do you want me to do that?
