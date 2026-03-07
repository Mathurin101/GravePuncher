using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player UI/items")]
    [SerializeField] Image[] BarMeter;
    int Counter;

    //pause menu

    //Option menu

    //Score menu

    //Shop menu (UI)

    //Inventory menu



    // Awake is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //needed to initiate this class
        if (!Instance) { Instance = this; }


        Counter = BarMeter.Length;

        //turn off all the meters
        for (int i = 0; i < BarMeter.Length; i++)
        {
            AddMeter(false);
        }
        Debug.Log("The count: " + Counter);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddMeter(bool AddOne = true)
    {
        if (AddOne)//sets the current meter true
        {
            Debug.Log("The count was added: " + Counter);
            Counter++;
            BarMeter[Counter -1].gameObject.SetActive(true);
        }
        else//sets the current meter false
        {
            Debug.Log("The count was subtracted: " + Counter);
            BarMeter[Counter -1].gameObject.SetActive(false);
            Counter--;
        }


    }
}
