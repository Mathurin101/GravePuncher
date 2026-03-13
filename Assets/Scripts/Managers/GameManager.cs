using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player1 UI/items")]
    [SerializeField] Image[] BarMeterP1;
    [SerializeField] Image[] NotBarMeterP1;
    int CounterP1;

    [SerializeField] TextMeshProUGUI ScoreP1;
    int HighestScoreP1;

    [Header("Player2 UI/items")]
    [SerializeField] GameObject Player2;
    [SerializeField] Image[] BarMeterP2;
    [SerializeField] Image[] NotBarMeterP2;
    int CounterP2;

    [SerializeField] TextMeshProUGUI ScoreP2;
    int HighestScoreP2;



    //pause menu
    //shows highest score

    //Option menu

    //Shop menu (UI)

    //Inventory menu

    //Enemies
    [Header("Enemies")]
    [SerializeField] public GameObject Zombie;
    [SerializeField] public GameObject Grave;

    [Header("Warning Texts")]
    [SerializeField] public TextMeshProUGUI NoMeterLabel;


    [Header("MISC")]
    [SerializeField] TextMeshProUGUI PressStart;
    bool isPressed;
    [SerializeField] TextMeshProUGUI Rounds;



    // Awake is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //needed to initiate this class
        if (!Instance) { Instance = this; }

        CounterP1 = BarMeterP1.Length;

        ScoreP1.text = "00000";
        //turn off all the meters
        for (int i = 0; i < BarMeterP1.Length; i++)
        {
            AddMeterP1(false);
        }

        NoMeterLabel.gameObject.SetActive(false);

        PressStart.gameObject.SetActive(false);

        isPressed = true;
        StartCoroutine(FlashesForever(PressStart));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            AddMeterP1();
        }

        //will remove text if true
        if (Input.GetKey("k"))
        {
            isPressed = false;
        }

    }

    //Player1
    public void AddMeterP1(bool AddOne = true)
    {
        if (AddOne)//sets the current meter true -- add one
        {
            //can't go over the amount of meter
            if (CounterP1 == BarMeterP1.Length) { Debug.Log("can't go over! "); return; }

            CounterP1++;
            BarMeterP1[CounterP1 - 1].gameObject.SetActive(true);
        }
        else //sets the current meter false -- minus one
        {
            BarMeterP1[CounterP1 - 1].gameObject.SetActive(false);
            CounterP1--;
        }

    }

    public void AddScoreP1(int AddedNumber)
    {
        if ((int.Parse(ScoreP1.text) + AddedNumber) > 1000)
        {
            ScoreP1.text = "0" + (int.Parse(ScoreP1.text) + AddedNumber).ToString();
            SetHighestScoreP1();

        }
        else if ((int.Parse(ScoreP1.text) + AddedNumber) > 10000)
        {
            ScoreP1.text = (int.Parse(ScoreP1.text) + AddedNumber).ToString();
            SetHighestScoreP1();
        }
        else
        {
            ScoreP1.text = "00" + (int.Parse(ScoreP1.text) + AddedNumber).ToString();
            SetHighestScoreP1();
        }
    }

    void SetHighestScoreP1()
    {
        if (HighestScoreP1 < int.Parse(ScoreP1.text))
        {
            HighestScoreP1 = int.Parse(ScoreP1.text);
        }
    }

    public int GetMeterAmount()
    {
        return CounterP1;
    }

    public IEnumerator DisplayWarning(TextMeshProUGUI TextShown, float TimeLength = 0.2f)
    {
        //almost flashes 
        TextShown.gameObject.SetActive(true);
        yield return new WaitForSeconds(TimeLength);
        TextShown.gameObject.SetActive(false);
        yield return new WaitForSeconds(TimeLength);
        TextShown.gameObject.SetActive(true);
        yield return new WaitForSeconds(TimeLength);
        TextShown.gameObject.SetActive(false);
    }

    public IEnumerator DisplayWarningMeters(int MetersNeeded, float TimeLength = 0.2f)
    {
        //almost flashes 
        for (int i = 0; i < MetersNeeded; i++)
        {
            NotBarMeterP1[i].gameObject.SetActive(true);
        } //turns on
        yield return new WaitForSeconds(TimeLength);
        for (int i = 0; i < MetersNeeded; i++)
        {
            NotBarMeterP1[i].gameObject.SetActive(false);
        } //turns off

        yield return new WaitForSeconds(TimeLength);
        for (int i = 0; i < MetersNeeded; i++)
        {
            NotBarMeterP1[i].gameObject.SetActive(true);
        } //turns on

        yield return new WaitForSeconds(TimeLength);
        for (int i = 0; i < MetersNeeded; i++)
        {
            NotBarMeterP1[i].gameObject.SetActive(false);
        } //turns off
    }


    //Player2
    public void AddMeterP2(bool AddOne = true)
    {
        if (AddOne)//sets the current meter true -- add one
        {
            //can't go over the amount of meter
            if (CounterP2 == BarMeterP2.Length) { Debug.Log("can't go over! "); return; }

            CounterP2++;
            BarMeterP2[CounterP2 - 1].gameObject.SetActive(true);
        }
        else //sets the current meter false -- minus one
        {
            BarMeterP2[CounterP2 - 1].gameObject.SetActive(false);
            CounterP2--;
        }
    }

    public void AddScoreP2(int AddedNumber)
    {
        if ((int.Parse(ScoreP2.text) + AddedNumber) > 1000)
        {
            ScoreP2.text = "0" + (int.Parse(ScoreP2.text) + AddedNumber).ToString();
            SetHighestScoreP2();

        }
        else if ((int.Parse(ScoreP2.text) + AddedNumber) > 10000)
        {
            ScoreP2.text = (int.Parse(ScoreP2.text) + AddedNumber).ToString();
            SetHighestScoreP2();
        }
        else
        {
            ScoreP2.text = "00" + (int.Parse(ScoreP2.text) + AddedNumber).ToString();
            SetHighestScoreP2();
        }
    }

    void SetHighestScoreP2()
    {
        if (HighestScoreP2 < int.Parse(ScoreP2.text))
        {
            HighestScoreP2 = int.Parse(ScoreP2.text);
        }
    }

    public int GetMeterAmountP2()
    {
        return CounterP2;
    }

    IEnumerator FlashesForever(TextMeshProUGUI TextShown, float WaitTime = 0.7f)
    {
        do
        {
            TextShown.gameObject.SetActive(true);
            yield return new WaitForSeconds(WaitTime);
            TextShown.gameObject.SetActive(false);
            yield return new WaitForSeconds(WaitTime);

        } while (isPressed);
        TextShown.gameObject.SetActive(false);

        //TODO: display player two UI
        Player2.SetActive(true);
    }

}
