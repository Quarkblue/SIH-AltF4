using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialougeManager : MonoBehaviour
{
    [Header("Dialouge UI")]
    [SerializeField] private GameObject dialougePanel;
    [SerializeField] private TextMeshProUGUI dialougeText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    public bool dialougeIsPlaying { get; private set; }

    private static DialougeManager instance;

    


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Found more than one dialouge manager on this scene");
        }
        instance = this; 
    }

    public static DialougeManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialougeIsPlaying = false;
        dialougePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!dialougeIsPlaying)
        {
            return;
        }
        if(Input.GetMouseButtonDown(0))
        {
            ContinueStory();
        }
    }

    public void EnterDialougeMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialougeIsPlaying = true;
        dialougePanel.SetActive(true);

        if (currentStory.canContinue)
        {
            dialougeText.text = currentStory.Continue();
            displayChoices();

        }
        else
        {
            ExitDialougeMode();
        }
    }
    private IEnumerator ExitDialougeMode()
    {
        yield return new WaitForSeconds(0.2f);
        dialougeIsPlaying = false;
        dialougePanel.SetActive(false);
        dialougeText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialougeText.text = currentStory.Continue();

        }
        else
        {
            StartCoroutine(ExitDialougeMode());
        } 
    }
    private void displayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError("more choices were given");

            int index = 0;

            foreach(Choice choice in currentChoices)
            {
                choices[index].gameObject.SetActive(true);
                choicesText[index].text = choice.text;
                index++;
            }
            for(int i = 0; i < choices.Length; i++)
            {
                choices[i].gameObject.SetActive(false);
            }
        }
    }
}
