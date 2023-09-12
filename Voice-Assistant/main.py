import speech_recognition as sr
import os
import win32com.client
import openai
from config import apikey
import random

speaker=win32com.client.Dispatch("SAPI.SpVoice")

chatStr = ""
def chat(query):
    global chatStr
    openai.api_key = apikey
    chatStr += f"Ajay: {query}\n Jarvis:"
    response = openai.ChatCompletion.create(
        model="gpt-3.5-turbo",
        messages=[
            {
                "role": "user",
                "content": chatStr
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
    speaker.Speak(response["choices"][ 0]["message"]["content"])
    print("i am here")
    chatStr += f"{response['choices'][0]['message']['content']}\n"
    return response["choices"][0]["message"]["content"]
    print(chatStr)
    if not os.path.exists("Openai"):
        os.mkdir("Openai")
    # with open(f"Openai/prompt - {random.randint(1, 999999)}","w") as f:
    createFile(prompt, text)
    # with open(f"Openai/{''.join(prompt.split('hello')[1:])}.txt", "w") as f:
    #     print(f.name)
    #     f.write(text)

def ai(prompt):
    openai.api_key = apikey
    text = f"OpenAI response for prompt: {prompt} \n ************************\n\n"

    response = openai.ChatCompletion.create(
        model="gpt-3.5-turbo",
        messages=[
            {
                "role": "user",
                "content": prompt
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
    # print(response["choices"][0]["text"])
    text += response["choices"][0]["message"]["content"]
    say(response["choices"][0]["message"]["content"])
    print(text)
    if not os.path.exists("Openai"):
        os.mkdir("Openai")
    # with open(f"Openai/prompt - {random.randint(1, 999999)}","w") as f:
    createFile(prompt, text)
    # with open(f"Openai/{''.join(prompt.split('hello')[1:])}.txt", "w") as f:
    #     print(f.name)
    #     f.write(text)

def createFile(name, text):
    with open(f"Openai/{''.join(name.split('hello')[1:]).strip()}.txt", 'w') as f:
        f.write(text)
        print(f"created file {f.name}")

def say(text):
    speaker.Speak(str(text))

def takeCommand():
    r = sr.Recognizer()
    with sr.Microphone() as source:
        r.pause_threshold = 1
        audio = r.listen(source)
        try:
            query = r.recognize_google(audio, language="en-in")
            query = query.lower()+ ". Explain in very minimum words in such a way that a child of age 10 can understand it."
            print(f"User said: {query}")
            return query
        except Exception as e:
            return "Some error occured. Please repeat again!"


if __name__ == '__main__':
    speaker.Speak("Hello I am here to help you")
    while True:
        print("Listening...")
        query = takeCommand()
        if "Hello".lower() in query.lower():
            ai(prompt=query)

        elif "Thank".lower() in query.lower():
            exit()

        elif "reset chat".lower() in query.lower():
            chatStr = ""
        else:
            print("Chatting...")
            chat(query)
        # say(query)