using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private DialogueDisplayer textDisplay;

    // Start is called before the first frame update
    void Start()
    {
        textDisplay = GameObject.FindGameObjectWithTag("GameController").GetComponent<DialogueDisplayer>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()
    {
        
        if(transform.parent.name == "bus")
        {
            player.transform.SetParent(transform.parent);
            transform.gameObject.SetActive(false);
            textDisplay.ClearText();    

        }
        else if(transform.parent.name == "School")
        {
            SceneManager.LoadScene("Classroom");
            textDisplay.ClearText();
        }
    }

}
