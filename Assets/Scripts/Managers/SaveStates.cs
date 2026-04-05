using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SaveStates : MonoBehaviour
{
    public static SaveStates SaveThis;

    public enum PlayerMove
    {
        up, down, left, right, punch, FireBall, Jump
    }
    [SerializeField] InputActionAsset InputActions;

    String[] Player1Move;
    String[] Player2Move;

    InputAction MovePlayer1;
    InputAction MovePlayer2;

    InputAction MovePlayer1Punch;
    InputAction MovePlayer2Punch;

    InputAction MovePlayer1FireBall;
    InputAction MovePlayer2FireBall;

    InputAction JumpPlayer1;
    InputAction JumpPlayer2;

    protected int GravesPunched;

    void Awake()
    {
        //needed to initiate this class
        if (!SaveThis) { SaveThis = this; }

        Player1Move = new string[7];
        Player2Move = new string[7];

        MovePlayer1 = InputActions.FindActionMap("Player").FindAction("Move");
        MovePlayer2 = InputActions.FindActionMap("Player2").FindAction("Move");

        JumpPlayer1 = InputActions.FindActionMap("Player").FindAction("Jump");
        JumpPlayer2 = InputActions.FindActionMap("Player2").FindAction("Jump");

        MovePlayer1Punch = InputActions.FindActionMap("Player").FindAction("Punch");
        MovePlayer2Punch = InputActions.FindActionMap("Player2").FindAction("Punch");

        MovePlayer1FireBall = InputActions.FindActionMap("Player").FindAction("FireBall");
        MovePlayer2FireBall = InputActions.FindActionMap("Player2").FindAction("FireBall");

        SetControlsP1();
        SetControlsP2();
    }

    void Update()
    {
        SetControlsP1();
        SetControlsP2();
    }

    public void SetControlsP1()
    {
        for (int i = 0; i < 4; i++)
        {
            Player1Move[i] = MovePlayer1.GetBindingDisplayString(2 + i, InputBinding.DisplayStringOptions.DontUseShortDisplayNames).ToString();
        }
        Player1Move[4] = MovePlayer1Punch.GetBindingDisplayString(0, InputBinding.DisplayStringOptions.DontUseShortDisplayNames).ToString();
        Player1Move[5] = MovePlayer1FireBall.GetBindingDisplayString(0, InputBinding.DisplayStringOptions.DontUseShortDisplayNames).ToString();
        Player1Move[6] = JumpPlayer1.GetBindingDisplayString(0, InputBinding.DisplayStringOptions.DontUseShortDisplayNames).ToString();
    }
    public void SetControlsP2()
    {
        for (int i = 0; i < 4; i++)
        {
            Player1Move[i] = MovePlayer2.GetBindingDisplayString(2 + i, InputBinding.DisplayStringOptions.DontUseShortDisplayNames).ToString();
        }
        Player2Move[4] = MovePlayer2Punch.GetBindingDisplayString(0, InputBinding.DisplayStringOptions.DontUseShortDisplayNames).ToString();
        Player2Move[5] = MovePlayer2FireBall.GetBindingDisplayString(0, InputBinding.DisplayStringOptions.DontUseShortDisplayNames).ToString();
        Player2Move[6] = JumpPlayer2.GetBindingDisplayString(0, InputBinding.DisplayStringOptions.DontUseShortDisplayNames).ToString();
    }

    public string GetControlsP1(int Index)
    {
        return Player1Move[Index];
    }
    public string GetControlsP2(int Index)
    {
        return Player2Move[Index];
    }


    //GravesPunched
    public int SetGravesPunched(int NumberPunched) { return GravesPunched; }
    public int GetGravesPunched() { return GravesPunched; }




}
