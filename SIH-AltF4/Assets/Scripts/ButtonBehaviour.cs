using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
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
            Debug.Log("Button pressed");

            player.transform.SetParent(transform.parent);
        }
    }

}
