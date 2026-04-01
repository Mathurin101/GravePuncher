using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player1 UI/items")]
    [SerializeField] public GameObject Player;
    [SerializeField] public Image[] BarMeterP1;
    [SerializeField] public Image[] NotBarMeterP1;
    public int CounterP1;

    [SerializeField] TextMeshProUGUI ScoreP1;
    int HighestScoreP1;

    [Header("Player2 UI/items")]
    [SerializeField] public GameObject Player2;
    [SerializeField] public GameObject P2Character;
    [SerializeField] public Image[] BarMeterP2;
    [SerializeField] public Image[] NotBarMeterP2;
    public int CounterP2;

    [SerializeField] TextMeshProUGUI ScoreP2;
    int HighestScoreP2;


    [Header("Menus")]
    [SerializeField] GameObject MenuActive;
    [SerializeField] GameObject MenuPause;
    [SerializeField] GameObject MenuShop;
    [SerializeField] GameObject MenuLose;
    [SerializeField] GameObject MenuWin;


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
    [SerializeField] public TextMeshProUGUI NoMeterLabelP2;


    [Header("MISC")]
    [SerializeField] TextMeshProUGUI PressStart;
    bool isPressed;

    [SerializeField] TextMeshProUGUI Rounds;

    float OGTimeScale = 1f;
    bool isPaused = false;

    // Awake is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //needed to initiate this class
        if (!Instance) { Instance = this; }

        //Used to stop time later
        OGTimeScale = Time.deltaTime;

        CounterP1 = BarMeterP1.Length;
        CounterP2 = BarMeterP2.Length;

        ScoreP1.text = "00000";
        ScoreP2.text = "00000";

        //turn off all the meters
        for (int i = 0; i < BarMeterP1.Length; i++)
        {
            AddMeter(BarMeterP1, ref CounterP1, false);
            AddMeter(BarMeterP2, ref CounterP2, false);
        }

        NoMeterLabel.gameObject.SetActive(false);
        NoMeterLabelP2.gameObject.SetActive(false);

        PressStart.gameObject.SetActive(false);

        isPressed = true;
        StartCoroutine(FlashesForever(PressStart));
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown("1"))
        // {
        //     AddMeter(BarMeterP1, ref CounterP1);
        // }
        //
        // if (Input.GetKeyDown("2") && P2Character.activeSelf)
        // {
        //     AddMeter(BarMeterP2, ref CounterP2);
        // }
        //
        // //will remove text if true
        // if (Input.GetKey("k"))
        // {
        //     isPressed = false;
        // }


    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;//freezes time
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void UnpauseGame()
    {
        isPaused = false;
        Time.timeScale = OGTimeScale;//Unfreezes time
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //turn off the active menu and set it to null 
        MenuActive.SetActive(false);
        MenuActive = null;
    }

    public void PauseMenu()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (MenuActive == null)
            {
                PauseGame();
                MenuActive = MenuPause;
                MenuActive.SetActive(true);
            }
            else if (MenuActive == MenuPause)
            {
                UnpauseGame();
            }
        }
    }

    public void AddMeter(Image[] Meter, ref int Counter, bool AddOne = true)
    {
        if (AddOne)//sets the current meter true -- add one
        {
            //can't go over the amount of meter
            if (Counter == Meter.Length) { Debug.Log("can't go over!"); return; }

            Counter++;
            Meter[Counter - 1].gameObject.SetActive(true);
        }
        else //sets the current meter false -- minus one
        {
            Meter[Counter - 1].gameObject.SetActive(false);
            Counter--;
        }

    }

    public void AddScore(int AddedNumber, TextMeshProUGUI Score)
    {
        if ((int.Parse(Score.text) + AddedNumber) > 1000)
        {
            ScoreP1.text = "0" + (int.Parse(Score.text) + AddedNumber).ToString();
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
        //player one
        if (HighestScoreP1 < int.Parse(ScoreP1.text))
        {
            HighestScoreP1 = int.Parse(ScoreP1.text);
        }

        //player two
        if (HighestScoreP2 < int.Parse(ScoreP2.text))
        {
            HighestScoreP2 = int.Parse(ScoreP2.text);
        }
    }

    public int GetMeterAmount()
    {
        return CounterP1;
    }
    public Image[] GetMeter()
    {
        return BarMeterP1;
    }
    public TextMeshProUGUI GetScore()
    {
        return ScoreP1;
    }

    public int GetMeterAmountP2()
    {
        return CounterP2;
    }
    public Image[] GetMeterP2()
    {
        return BarMeterP2;
    }
    public TextMeshProUGUI GetScoreP2()
    {
        return ScoreP2;
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

    public IEnumerator DisplayWarningMeters(int MetersNeeded, Image[] Player, float TimeLength = 0.2f)
    {
        //almost flashes 
        for (int i = 0; i < MetersNeeded; i++)
        {
            Player[i].gameObject.SetActive(true);
        } //turns on
        yield return new WaitForSeconds(TimeLength);
        for (int i = 0; i < MetersNeeded; i++)
        {
            Player[i].gameObject.SetActive(false);
        } //turns off

        yield return new WaitForSeconds(TimeLength);
        for (int i = 0; i < MetersNeeded; i++)
        {
            Player[i].gameObject.SetActive(true);
        } //turns on

        yield return new WaitForSeconds(TimeLength);
        for (int i = 0; i < MetersNeeded; i++)
        {
            Player[i].gameObject.SetActive(false);
        } //turns off
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
        P2Character.SetActive(true);

    }

}
