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

        //for player binds display
        MovePlayer1 = InputActions.FindActionMap("Player").FindAction("Move");
        MovePlayer2 = InputActions.FindActionMap("Player2").FindAction("Move");

        JumpPlayer1 = InputActions.FindActionMap("Player").FindAction("Jump");
        JumpPlayer2 = InputActions.FindActionMap("Player2").FindAction("Jump");

        MovePlayer1Punch = InputActions.FindActionMap("Player").FindAction("Punch");
        MovePlayer2Punch = InputActions.FindActionMap("Player2").FindAction("Punch");

        MovePlayer1FireBall = InputActions.FindActionMap("Player").FindAction("FireBall");
        MovePlayer2FireBall = InputActions.FindActionMap("Player2").FindAction("FireBall");
    }

    void Update()
    {

    }

    public string GetControlsP1(int Index)
    {
        string InputStr = " ";
        if (Index <= 3)
        {
            InputStr = MovePlayer1.GetBindingDisplayString(2 + Index, InputBinding.DisplayStringOptions.DontUseShortDisplayNames).ToString();
        }
        else if (Index == 4)
        {
            InputStr = MovePlayer1Punch.GetBindingDisplayString(0, InputBinding.DisplayStringOptions.DontUseShortDisplayNames).ToString();
        }
        else if (Index == 5)
        {
            InputStr = MovePlayer1FireBall.GetBindingDisplayString(0, InputBinding.DisplayStringOptions.DontUseShortDisplayNames).ToString();
        }
        else if (Index == 6)
        {
            InputStr = JumpPlayer1.GetBindingDisplayString(0, InputBinding.DisplayStringOptions.DontUseShortDisplayNames).ToString();
        }
        return InputStr;
    }
    public string GetControlsP2(int Index)
    {
        string InputStr = " ";
        if (Index <= 3)
        {
            InputStr = MovePlayer2.GetBindingDisplayString(2 + Index, InputBinding.DisplayStringOptions.DontUseShortDisplayNames).ToString();
        }
        else if (Index == 4)
        {
            InputStr = MovePlayer2Punch.GetBindingDisplayString(0, InputBinding.DisplayStringOptions.DontUseShortDisplayNames).ToString();
        }
        else if (Index == 5)
        {
            InputStr = MovePlayer2FireBall.GetBindingDisplayString(0, InputBinding.DisplayStringOptions.DontUseShortDisplayNames).ToString();
        }
        else if (Index == 6)
        {
            InputStr = JumpPlayer2.GetBindingDisplayString(0, InputBinding.DisplayStringOptions.DontUseShortDisplayNames).ToString();
        }
        return InputStr;
    }


    //GravesPunched
    public int SetGravesPunched(int NumberPunched) { return GravesPunched; }
    public int GetGravesPunched() { return GravesPunched; }




}
