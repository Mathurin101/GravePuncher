using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    enum Player
    {
        Player,
        Player2
    }
    //allows us to use all the actions in the "InputAction" assets
    [SerializeField] InputActionAsset InputActions;

    private InputAction MoveAction;
    private InputAction JumpAction;
    private InputAction PunchAction;
    private InputAction FireBallAction;


    private CharacterController controller;

    [Header("Player Stats")]
    [SerializeField] Player Type;
    [SerializeField] float Speed = 5;
    [SerializeField] int JumpMax = 1;
    [SerializeField] float JumpSpeed = 5;
    [SerializeField] float Gravity = 9.8f;

    [Header("Player Moves")]
    [SerializeField] GameObject PunchBox;
    [SerializeField] GameObject FireBall;

    Vector3 MoveDirection;
    Vector3 JumpVelocity;

    Vector2 MoveAmount;



    int JumpCount;
    float OGGravity;


    private void OnEnable()
    {
        InputActions.FindActionMap(Type.ToString()).Enable();
    }
    private void OnDisable()
    {
        InputActions.FindActionMap(Type.ToString()).Disable();
    }


    private void Awake()
    {
        MoveAction = InputSystem.actions.FindAction("Move");
        JumpAction = InputSystem.actions.FindAction("Jump");
        PunchAction = InputSystem.actions.FindAction("Punch");
        FireBallAction = InputSystem.actions.FindAction("FireBall");

        controller = GetComponent<CharacterController>();
        OGGravity = Gravity;
    }

    void FixedUpdate()
    {
        MoveAmount = MoveAction.ReadValue<Vector2>();
        MovePlayer();
    }

    void Jump()
    {
        if (JumpAction.WasPressedThisFrame() && JumpCount <= JumpMax)
        {
            JumpVelocity.y = JumpSpeed;
            JumpCount++;
        }
    }

    void MovePlayer()
    {
        if (controller.isGrounded)
        {
            JumpVelocity = Vector3.zero;
            JumpCount = 0;
            Gravity = OGGravity;
        }
        else
        {
            JumpVelocity.y -= Gravity * Time.deltaTime;
        }

        if (MoveAction.IsPressed())
        {
            MoveDirection = MoveAmount.y * gameObject.transform.forward + MoveAmount.x * gameObject.transform.right;

            controller.Move(MoveDirection * Speed * Time.deltaTime);
        }
        Jump();
        controller.Move(JumpVelocity * Time.deltaTime);

        Punch();
        FireBallPunch();
    }

    void Punch()
    {
        if (PunchAction.IsPressed())
        {
            //add in a new input
            StartCoroutine(AttackHitBox());
        }
    }
    IEnumerator AttackHitBox()
    {
        PunchBox.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        PunchBox.SetActive(false);
    }

    void FireBallPunch(int MetersNeeded = 2)
    {
        //player1
        if (GameManager.Instance.GetMeterAmount() < MetersNeeded && FireBallAction.WasPerformedThisFrame() && Type == Player.Player)
        {
            //display "Not enough meter"
            StartCoroutine(GameManager.Instance.DisplayWarning(GameManager.Instance.NoMeterLabel));
            //display meters needed
            StartCoroutine(GameManager.Instance.DisplayWarningMeters(MetersNeeded, GameManager.Instance.NotBarMeterP1));
            return;
        }
        else if (GameManager.Instance.GetMeterAmount() >= MetersNeeded && FireBallAction.WasPerformedThisFrame() && Type == Player.Player)
        {
            Instantiate(FireBall, PunchBox.transform.position, PunchBox.transform.rotation);
            for (int i = 0; i < MetersNeeded; i++)
            {
                GameManager.Instance.AddMeter(GameManager.Instance.GetMeter(), ref GameManager.Instance.CounterP1, false);
            }
        }

        //player2
        if (GameManager.Instance.GetMeterAmountP2() < MetersNeeded && FireBallAction.WasPerformedThisFrame() && Type == Player.Player2)
        {
            //display "Not enough meter"
            StartCoroutine(GameManager.Instance.DisplayWarning(GameManager.Instance.NoMeterLabelP2));
            //display meters needed
            StartCoroutine(GameManager.Instance.DisplayWarningMeters(MetersNeeded, GameManager.Instance.NotBarMeterP2));
            return;
        }
        else if (GameManager.Instance.GetMeterAmountP2() >= MetersNeeded && FireBallAction.WasPerformedThisFrame() && Type == Player.Player2)
        {
            Instantiate(FireBall, PunchBox.transform.position, PunchBox.transform.rotation);
            for (int i = 0; i < MetersNeeded; i++)
            {
                GameManager.Instance.AddMeter(GameManager.Instance.GetMeterP2(), ref GameManager.Instance.CounterP2, false);
            }
        }
    }

}
