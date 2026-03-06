using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    [Header("Player Stats")]
    [SerializeField] int Speed = 1;
    [SerializeField] int Hearts = 3;
    [SerializeField] int TotalJumps = 1;
    [SerializeField] int JumpMax = 1;
    [SerializeField] int JumpSpeed = 2;


    [Header("MISC")]
    [SerializeField] float Gravity = 9.8f;
    [SerializeField] GameObject PunchBox;


    //Original Stats
    int PlayerOGHearts;
    int PlayerOGSpeed;
    int OGGravity;

    //Counters
    int JumpCount;

    Vector3 MoveDirection;
    Vector3 JumpVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OGGravity = (int)Gravity;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    void Movement()
    {
        if (controller.isGrounded)
        {
            JumpVelocity = Vector3.zero;
            JumpCount = 0;
            Gravity = OGGravity;
        }
        else
        {
            //Apply Gravity
            JumpVelocity.y -= (Gravity * Time.deltaTime);
        }
        MoveDirection = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        controller.Move(MoveDirection * Speed * Time.deltaTime);

        Jump();
        controller.Move(JumpVelocity * Time.deltaTime);

        Punch();


    }


    void Jump()
    {
        if (Input.GetButton("Jump") && JumpCount <= JumpMax)
        {
            JumpVelocity.y = JumpSpeed;
            JumpCount++;
        }
    }


    void Punch()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKey("f"))
        {
            StartCoroutine(AttackHitBox());
        }

        //bug test
        if (Input.GetKey("g") && PunchBox.activeSelf == false)
        {
            PunchBox.SetActive(true);
        }
        else if (Input.GetKey("h") && PunchBox.activeSelf == true)
        {
            PunchBox.SetActive(false);
        }
    }

    //jumpPunch

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        //Add logic for when the player exits the trigger
    }

    IEnumerator AttackHitBox()
    {
        PunchBox.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        PunchBox.SetActive(false);
    }
}
