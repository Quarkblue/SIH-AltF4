using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{   
    public float walkSpeed;
    [SerializeField] public FixedJoystick joystick;
    [SerializeField] private AudioSource busStart;
    private Rigidbody2D rb;
    float horizontal;
    float vertical;
    public GameObject sitbtn;

    List<GameObject> spawnPositions;
    public Animator playerAnim;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        Debug.Log("Player instantiated");
        if(SceneManager.GetActiveScene().name.ToString() == "Level1")
        {
            Debug.Log("haan bhai yahi hoon");
            busStart = GameObject.Find("busStart").GetComponent<AudioSource>();
        }
        joystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        rb = GetComponent<Rigidbody2D>();
        if(SceneManager.GetActiveScene().name == "Classroom")
        {
            sitbtn = GameObject.Find("sitBtn");
            sitbtn.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;
        playerAnim.SetFloat("Horizontal", horizontal);
        playerAnim.SetFloat("Vertical", vertical);
        playerAnim.SetFloat("speed", new Vector2(vertical, horizontal).sqrMagnitude);

        //wasd
        //horizontal = Input.GetAxisRaw("Horizontal");
        //vertical = Input.GetAxisRaw("Vertical");

        if (transform.parent && transform.parent.name == "bus")
        {
            StartCoroutine(busSequence());
        }
    }

    

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * walkSpeed, vertical * walkSpeed);
    }




    // Custom sequences
    private IEnumerator busSequence()
    {
        transform.position = transform.parent.position;
        var busAnimator = transform.parent.GetComponent<Animator>();
        busAnimator.SetBool("hasClimbed", true);
        yield return new WaitForSeconds(7);

        transform.parent = null;
        busAnimator.SetBool("hasLeft", true);

        yield return new WaitForSeconds(2.5f);
    }

    private IEnumerator schoolSequence()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Classroom");
    }






    // Trigger events
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "bus")
        {
            collision.gameObject.transform.Find("ClimbBusBtn").gameObject.SetActive(true);
            busStart.Play();
        }
        if(collision.gameObject.name == "School")
        {
            // school enter sequence
            StartCoroutine(schoolSequence());
        }

        if(collision.gameObject.CompareTag("desks"))
        {
            sitbtn.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "bus")
        {
            collision.gameObject.transform.Find("ClimbBusBtn").gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("desks"))
        {
           sitbtn.SetActive(false);
        }
    }
}
