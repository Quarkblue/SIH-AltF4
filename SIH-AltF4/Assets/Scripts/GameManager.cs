using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI textArea;

    [SerializeField] Transform startPos;
    public GameObject playerPrefab;
    public Cinemachine.CinemachineVirtualCamera vcam;
    public List<GameObject> SpawnPositions;

    private void Awake()
    {
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

        Instantiate(playerPrefab, SpawnPositions[PlayerPrefs.GetInt("SpawnPos")].transform.position, Quaternion.identity);
        vcam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
        vcam.gameObject.GetComponent<Animator>().SetBool("hasStarted", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private IEnumerator changeText(string text)
    //{

    //}

}
