import os
import openai
from config import apikey

openai.api_key = apikey

response = openai.ChatCompletion.create(
  model="gpt-3.5-turbo",
  messages=[
    {
      "role": "user",
      "content": "Hello "
    },
    {
      "role": "assistant",
      "content": "Hello! How may I assist you today?"
    }
  ],
  temperature=1,
  max_tokens=256,
  top_p=1,
  frequency_penalty=0,
  presence_penalty=0
)

print(response)


# {
#   "id": "chatcmpl-7xsupn3IuyZ5gMtiuuZSIMXW5KbAu",
#   "object": "chat.completion",
#   "created": 1694506803,
#   "model": "gpt-3.5-turbo-0613",
#   "choices": [
#     {
#       "index": 0,
#       "message": {
#         "role": "assistant",
#         "content": "Hi there! How can I help you today?"
#       },
#       "finish_reason": "stop"
#     }
#   ],
#   "usage": {
#     "prompt_tokens": 22,
#     "completion_tokens": 10,
#     "total_tokens": 32
#   }
# }