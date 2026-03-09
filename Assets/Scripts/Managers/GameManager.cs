using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player UI/items")]
    [SerializeField] Image[] BarMeter;
    public int Counter;

    [SerializeField] TextMeshProUGUI Score;
    int HighestScore;

    //pause menu
    //shows highest score

    //Option menu

    //Shop menu (UI)

    //Inventory menu

    [Header("Warning Texts")]
    [SerializeField] public TextMeshProUGUI NoMeterLabel;


    //[Header("MISC")]



    // Awake is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //needed to initiate this class
        if (!Instance) { Instance = this; }


        Counter = BarMeter.Length;

        Score.text = "00000";
        //turn off all the meters
        for (int i = 0; i < BarMeter.Length; i++)
        {
            AddMeter(false);
        }

        NoMeterLabel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void AddMeter(bool AddOne = true)
    {
        if (AddOne)//sets the current meter true
        {
            Counter++;
            BarMeter[Counter - 1].gameObject.SetActive(true);
        }
        else //sets the current meter false
        {
            BarMeter[Counter - 1].gameObject.SetActive(false);
            Counter--;
        }

    }


    public void AddScore(int AddedNumber)
    {
        if ((int.Parse(Score.text) + AddedNumber) > 1000)
        {
            Score.text = "0" + (int.Parse(Score.text) + AddedNumber).ToString();
            SetHighestScore();

        }
        else if ((int.Parse(Score.text) + AddedNumber) > 10000)
        {
            Score.text = (int.Parse(Score.text) + AddedNumber).ToString();
            SetHighestScore();
        }
        else
        {
            Score.text = "00" + (int.Parse(Score.text) + AddedNumber).ToString();
            SetHighestScore();
        }
    }

    void SetHighestScore()
    {
        if (HighestScore < int.Parse(Score.text))
        {
            HighestScore = int.Parse(Score.text);
        }
    }

    public int GetMeterAmount()
    {
        return Counter;
    }

    public IEnumerator DisplayWarning(TextMeshProUGUI TextShown, float TimeLength = 0.5f)
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


}
