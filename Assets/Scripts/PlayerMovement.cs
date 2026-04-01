using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //allows us to use all the actions in the "InputAction" assets
    [SerializeField] InputActionAsset InputActions;

    private InputAction MoveAction;
    private InputAction JumpAction;

    private Rigidbody PlayerRigidbody;
    private CharacterController controller;

    [SerializeField] float Speed = 5;
    [SerializeField] int JumpMax = 1;
    [SerializeField] float JumpSpeed = 5;
    [SerializeField] float JumpHeight = 5;
    [SerializeField] float Gravity = 9.8f;

    Vector3 MoveDirection;
    Vector3 JumpVelocity;

    Vector2 MoveAmount;



    int JumpCount;
    float OGGravity;


    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }
    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }


    private void Awake()
    {
        MoveAction = InputSystem.actions.FindAction("Move");
        JumpAction = InputSystem.actions.FindAction("Jump");

        PlayerRigidbody = GetComponent<Rigidbody>();
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
        if (JumpAction.WasPressedThisFrame() && JumpCount == 0)
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
        //add in a new input
        AttackMoves.Instance.Punch();
    }

    void FireBallPunch()
    {
        AttackMoves.Instance.FireBallPunch();

    }
}
