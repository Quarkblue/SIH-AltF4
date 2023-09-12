using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public GameObject overlay;
    [SerializeField] public AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer.Play();
        overlay.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onStart(){
        StartCoroutine(onStartSequence());
    }

    public void quit(){
       Application.Quit();
    }


    IEnumerator onStartSequence()
    {
        overlay.SetActive(true);
        overlay.transform.Find("OverlayDisplay").GetComponent<Animator>().SetBool("StartAnim", true);
        yield return new WaitForSeconds(10);
        PlayerPrefs.SetInt("hasStarted", 1);
        SceneManager.LoadScene("Level1");
    }

}
