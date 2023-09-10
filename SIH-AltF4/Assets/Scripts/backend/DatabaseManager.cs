
using UnityEngine;
using UnityEngine.UI;

public class DatabaseManager : MonoBehaviour
{
    public InputField Phone;
    public InputField Query;

    void Start()
    {

    }

    public void CreateUser()
    {
        reportForm newUser = new reportForm(long.Parse(Phone.text), Query.text);
        
    }
}