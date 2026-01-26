using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    [Header("Player Stats")]
    [SerializeField] int Speed = 1;
    [SerializeField] int Hearts = 3;
    [SerializeField] int TotalJumps = 1;

    [Header("MISC")]
    [SerializeField] float Gravity = 9.8f;

    //Original Stats
    int PlayerOGHearts;
    int PlayerOGSpeed;

    //Counters
    int JumpCount;


    Vector3 MoveDirection;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    void Movement()
    {
   
        MoveDirection = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        controller.Move(MoveDirection * Speed * Time.deltaTime);
        /*switch (KeyCode.At)
        {
            case KeyCode.A:

            case KeyCode.D:

                MoveDirection = Input.GetAxis("Horizontal") * transform.right;
                controller.Move(MoveDirection * Speed * Time.deltaTime);
                break;

            case KeyCode.W:

            case KeyCode.S:
                MoveDirection = Input.GetAxis("Vertical") * transform.forward;
                controller.Move(MoveDirection * Speed * Time.deltaTime);
                break;
        }*/


    }

    //punch

    //jump

    //jumpPunch


}
