.env
base_url=https://llm.pron.com/
api_key=sk-
model_name=gpt-ggg

from agno.agent import Agent
from agno.models.openai import OpenAIChat # Or your preferred model
from agno.models.openai.like import OpenAILike
from agno.db.in_memory import InMemoryDb
import os
from dotenv import load_dotenv

load_dotenv()

agent_db = InMemoryDb()

# 1. Initialize the agent with a specific model
agent = Agent(
    model=OpenAILike(
        id= os.getenv("model_name"),
        base_url= os.getenv("base_url"),
        api_key=os.getenv("api_key")
    ),
    db= agent_db,
    add_history_to_context= True,
    num_history_runs=3,
    markdown=True
)

# 2. Use print_response to see the result directly in the terminal
agent.print_response("My name is Rashid")
agent.print_response("what is my name")
