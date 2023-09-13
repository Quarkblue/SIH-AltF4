using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    [SerializeField] Transform startPos;
    public GameObject playerPrefab;
    private Cinemachine.CinemachineVirtualCamera vcam;
    public List<GameObject> SpawnPositions;
    public GameObject playerExists;

    public static GameManager Instance;

    public bool afterSchool;

    private void Awake()
    {
        Instance = this;
        afterSchool = false;
        if (FindObjectsOfType<GameManager>().Length > 1)
        {
            PlayerPrefs.SetInt("hasStarted", 0);
            Destroy(gameObject);
        }
        else
        {
            PlayerPrefs.SetInt("hasStarted", 1);
            PlayerPrefs.SetInt("SpawnPos", 1); // start pos = 1, school = 0, hospital = 2
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");
        SpawnPositions = GameObject.FindGameObjectsWithTag("SpawnPos").ToList();


        //level 1 init
        vcam = GameObject.Find("Virtual Camera").GetComponent<Cinemachine.CinemachineVirtualCamera>();
        Instantiate(playerPrefab, SpawnPositions[PlayerPrefs.GetInt("SpawnPos")].transform.position, Quaternion.identity);
        vcam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
        vcam.gameObject.GetComponent<Animator>().SetBool("hasStarted", true);
    }

    // Update is called once per frame
    void Update()
    {

        playerExists = GameObject.FindGameObjectWithTag("Player");
        if (SceneManager.GetActiveScene().name == "Classroom" && !playerExists)
        {
            vcam = GameObject.Find("Virtual Camera").GetComponent<Cinemachine.CinemachineVirtualCamera>();
            GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpawnPos");
            GameObject player = Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
            player.transform.localScale = new Vector3(1, 1, 1);
            vcam.Follow = GameObject.FindGameObjectWithTag("Player").transform;

        }
        if(SceneManager.GetActiveScene().name == "Level1" && !playerExists && afterSchool)
        {
            vcam = GameObject.Find("Virtual Camera").GetComponent<Cinemachine.CinemachineVirtualCamera>();
            GameObject spawnPoint = GameObject.Find("SchoolPos");
            Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
            vcam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
            afterSchool = false;
        }

        if(SceneManager.GetActiveScene().name == "Hospital" && !playerExists)
        {
            GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpawnPos");
            GameObject player = Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
            player.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }

    }

    //private IEnumerator changeText(string text)
    //{

    //}

}
