using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueDisplayer : MonoBehaviour
{

    public TextMeshProUGUI TextArea;

    void Start()
    {
        StartCoroutine(BusText());
    }


    internal void setText(string text)
    {
        
    }

    private IEnumerator BusText()
    {
        yield return new WaitForSeconds(2.5f);
        TextArea.text = "Get into bus";
    }

    public void ClearText()
    {
        TextArea.text = String.Empty;
    }


}