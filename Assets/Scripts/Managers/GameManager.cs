using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    InputActionAsset InputActions;

    [Header("Player1 UI/items")]
    [SerializeField] public GameObject Player;
    [SerializeField] public Image[] BarMeterP1;
    [SerializeField] public Image[] NotBarMeterP1;
    public int CounterP1;

    [SerializeField] TextMeshProUGUI ScoreP1;
    int HighestScoreP1;

    [Header("Player2 UI/items")]
    [SerializeField] public GameObject Player2;
    [SerializeField] public GameObject Player2UI;
    [SerializeField] public Image[] BarMeterP2;
    [SerializeField] public Image[] NotBarMeterP2;
    [SerializeField] public Transform P2SpawnLoc;
    public int CounterP2;

    [SerializeField] TextMeshProUGUI ScoreP2;
    int HighestScoreP2;


    [Header("Menus")]
    [SerializeField] GameObject MenuActive;
    [SerializeField] GameObject MenuPause;
    [SerializeField] GameObject MenuShop;
    [SerializeField] GameObject MenuLose;
    [SerializeField] GameObject MenuWin;
    [SerializeField] GameObject MenuInfo;
    [SerializeField] GameObject MenuInfoP1;
    [SerializeField] GameObject MenuInfoP1Fist;
    [SerializeField] GameObject MenuInfoP2;
    [SerializeField] GameObject MenuInfoP2Fist;

    [Header("Player1 Inputs Display")]
    [SerializeField] TextMeshProUGUI P1up;
    [SerializeField] TextMeshProUGUI P1down;
    [SerializeField] TextMeshProUGUI P1left;
    [SerializeField] TextMeshProUGUI P1right;
    [SerializeField] TextMeshProUGUI P1jump;
    [SerializeField] TextMeshProUGUI P1punch;
    [SerializeField] TextMeshProUGUI P1fireball;

    [Header("Player2 Inputs Display")]
    [SerializeField] TextMeshProUGUI P2up;
    [SerializeField] TextMeshProUGUI P2down;
    [SerializeField] TextMeshProUGUI P2left;
    [SerializeField] TextMeshProUGUI P2right;
    [SerializeField] TextMeshProUGUI P2jump;
    [SerializeField] TextMeshProUGUI P2punch;
    [SerializeField] TextMeshProUGUI P2fireball;

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
    bool isPressed = true;

    [SerializeField] TextMeshProUGUI Rounds;

    float OGTimeScale = 1f;
    bool isPaused = false;

    // Awake is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //needed to initiate this class
        if (!Instance) { Instance = this; }

        //Used to stop time later
        OGTimeScale = Time.timeScale;

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

        MenuInfoP1Fist.SetActive(false);
        MenuInfoP2Fist.SetActive(false);

        StartCoroutine(FlashesForever(PressStart));
        SetAllBindDisplays();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            AddMeter(BarMeterP1, ref CounterP1);
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame && Player2UI.activeSelf)
        {
            AddMeter(BarMeterP2, ref CounterP2);
        }

        //will remove text if true
        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            isPressed = false;
        }

        PauseMenu();
        SetAllBindDisplays();
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;//freezes time
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
    }

    public void UnpauseGame()
    {
        isPaused = false;
        Time.timeScale = OGTimeScale;//Unfreezes time
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        //turn off the active menu and set it to null 
        MenuActive.SetActive(false);
        MenuActive = null;
    }

    public void PauseMenu()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
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
    void SetAllBindDisplays()
    {
        P1up.text = SaveStates.SaveThis.GetControlsP1((int)SaveStates.PlayerMove.up);
        P1down.text = SaveStates.SaveThis.GetControlsP1((int)SaveStates.PlayerMove.down);
        P1left.text = SaveStates.SaveThis.GetControlsP1((int)SaveStates.PlayerMove.left);
        P1right.text = SaveStates.SaveThis.GetControlsP1((int)SaveStates.PlayerMove.right);
        P1jump.text = SaveStates.SaveThis.GetControlsP1((int)SaveStates.PlayerMove.Jump);
        P1punch.text = SaveStates.SaveThis.GetControlsP1((int)SaveStates.PlayerMove.punch);
        P1fireball.text = SaveStates.SaveThis.GetControlsP1((int)SaveStates.PlayerMove.FireBall);
        P1fireball.text = SaveStates.SaveThis.GetControlsP1((int)SaveStates.PlayerMove.FireBall);

        P2up.text = SaveStates.SaveThis.GetControlsP2((int)SaveStates.PlayerMove.up);
        P2down.text = SaveStates.SaveThis.GetControlsP2((int)SaveStates.PlayerMove.down);
        P2left.text = SaveStates.SaveThis.GetControlsP2((int)SaveStates.PlayerMove.left);
        P2right.text = SaveStates.SaveThis.GetControlsP2((int)SaveStates.PlayerMove.right);
        P2jump.text = SaveStates.SaveThis.GetControlsP2((int)SaveStates.PlayerMove.Jump);
        P2punch.text = SaveStates.SaveThis.GetControlsP2((int)SaveStates.PlayerMove.punch);
        P2fireball.text = SaveStates.SaveThis.GetControlsP2((int)SaveStates.PlayerMove.FireBall);
    }

    public void InfoMenuP1Button()
    {
        MenuActive.SetActive(false);//Pause Menu

        MenuInfoP1Fist.SetActive(true);
        MenuInfoP2Fist.SetActive(false);

        MenuActive = MenuInfo;
        MenuActive.SetActive(true);

        MenuInfoP1.SetActive(true);
        MenuInfoP2.SetActive(false);
    }

    public void InfoMenuP2Button()
    {
        MenuInfoP1.SetActive(false);
        MenuInfoP2.SetActive(true);

        MenuInfoP1Fist.SetActive(false);
        MenuInfoP2Fist.SetActive(true);
    }

    public void PreviousButton()
    {
        MenuActive.SetActive(false);//menuInfo

        MenuActive = MenuPause;
        MenuActive.SetActive(true);
    }

    public void CloseButton()
    {
        UnpauseGame();
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
        TextShown.gameObject.SetActive(isPressed);

        Player2UI.SetActive(!isPressed);
        Player2.SetActive(!isPressed);
        Player2.name = "Player2";
    }


}
