using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splashScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeScreen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator changeScreen(){
        yield return new WaitForSeconds(8);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

}
