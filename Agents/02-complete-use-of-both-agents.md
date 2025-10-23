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

The above code is now evolved to use the latest version of autogen

```
import asyncio
from autogen_agentchat.agents import AssistantAgent, UserProxyAgent
from autogen_ext.models.openai import OpenAIChatCompletionClient

async def main():
    # Create the model client (replace model name / API key as appropriate)
    model_client = OpenAIChatCompletionClient(model="gpt-4-turbo", api_key="YOUR_OPENAI_API_KEY")

    # Create agents
    coder = AssistantAgent(
        name="Coder",
        model_client=model_client,
        system_message="You are a Python expert. Write and improve code collaboratively.",
    )
    reviewer = AssistantAgent(
        name="Reviewer",
        model_client=model_client,
        system_message="You review code for bugs and optimization issues.",
    )
    user = UserProxyAgent(
        name="User",
        model_client=model_client,
        system_message="You provide the task and let agents collaborate until you approve the output.",
        human_input_mode="AUTO",  # or "NEVER" if fully automated
    )

    # Link peers so coder and reviewer can talk
    coder.set_peer_agents([reviewer])
    reviewer.set_peer_agents([coder])

    # Kick off the collaboration: user -> coder
    await user.initiate_chat(
        coder,
        message="Write Python code for quicksort and have Reviewer review it.",
        max_turns=10  # limit number of turns to avoid runaway loops
    )

    # Clean up / close the model client
    await model_client.close()

if __name__ == "__main__":
    asyncio.run(main())
```
