using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //allows us to use all the actions in the "InputAction" assets
    [SerializeField] InputActionAsset InputActions;

    private InputAction MoveAction;
    private InputAction JumpAction;

    [SerializeField] Rigidbody PlayerRigidbody;
    [SerializeField] CharacterController PlayerController;

    [SerializeField] float speed = 5;
    [SerializeField] float JumpSpeed = 5;
    [SerializeField] float JumpHeight = 5;

    Vector3 MoveDirection;
    Vector3 JumpVelocity;


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
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void Jump()
    {
        if (JumpAction.WasPressedThisFrame())
        {
            PlayerRigidbody.AddForceAtPosition(new Vector3(0, JumpHeight, 0), Vector3.up, ForceMode.Impulse);

            //apply a jump animation soon here
        }
    }

    private void MovePlayer()
    {
        if (MoveAction.WasPressedThisFrame())
        {
            //PlayerRigidbody.MovePosition(PlayerRigidbody.position + transform.right * speed * Time.deltaTime);
            //PlayerController.Move()
        }





        Jump();
    }

}
