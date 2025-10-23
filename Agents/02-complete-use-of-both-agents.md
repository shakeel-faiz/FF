```
from autogen import AssistantAgent, UserProxyAgent

# Create agents
coder = AssistantAgent(name="Coder", llm_config={"model": "gpt-4-turbo"})
reviewer = AssistantAgent(name="Reviewer", llm_config={"model": "gpt-4-turbo"})
user = UserProxyAgent(name="User")

# Start a multi-agent conversation
user.initiate_chat(
    coder,
    message="Write Python code for quicksort algorithm and ask the Reviewer to check it."
)

# Let Coder and Reviewer collaborate
coder.initiate_chat(
    reviewer,
    message="Please review my quicksort implementation and suggest improvements."
)
```

Previous code was dummy, this is the new one

```
from autogen import AssistantAgent, UserProxyAgent

# Create agents
coder = AssistantAgent(
    name="Coder",
    llm_config={"model": "gpt-4-turbo"},
    system_message="You are a Python expert. Write and improve code collaboratively."
)

reviewer = AssistantAgent(
    name="Reviewer",
    llm_config={"model": "gpt-4-turbo"},
    system_message="You review code for bugs and optimization issues."
)

user = UserProxyAgent(name="User")

# Connect them as peers (so they can talk)
coder.set_peer_agents([reviewer])
reviewer.set_peer_agents([coder])

# Start the multi-agent collaboration
user.initiate_chat(
    coder,
    message="Write Python code for quicksort and have Reviewer review it."
)

```
