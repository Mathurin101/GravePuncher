using System.Collections;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] Player player;

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
        if (player.controller.isGrounded)
        {
            player.JumpVelocity = Vector3.zero;
            player.JumpCount = 0;
            player.Gravity = player.OGGravity;
        }
        else
        {
            //Apply Gravity
            player.JumpVelocity.y -= player.Gravity * Time.deltaTime;
        }

        if (Player.PlayerType.Player1 == player.Type)
        {
            player.MoveDirection = Input.GetAxis("HorizontalL") * player.GamePlayerOB.transform.right
                                   + Input.GetAxis("VerticalL") * player.GamePlayerOB.transform.forward;
        }
        else if (Player.PlayerType.Player2 == player.Type)
        {
            player.MoveDirection = Input.GetAxis("Horizontal") * player.GamePlayerOB.transform.right
                                   + Input.GetAxis("Vertical") * player.GamePlayerOB.transform.forward;
        }

        player.controller.Move(player.MoveDirection * player.Speed * Time.deltaTime);
        Jump();
        player.controller.Move(player.JumpVelocity * Time.deltaTime);
        Punch();
        //projectile
        FireBallPunch();
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && player.JumpCount <= player.JumpMax && Player.PlayerType.Player1 == player.Type)
        {
            player.JumpVelocity.y = player.JumpSpeed;
            player.JumpCount++;
        }
        else if (Input.GetKeyDown("/") && player.JumpCount <= player.JumpMax && Player.PlayerType.Player2 == player.Type)
        {
            player.JumpVelocity.y = player.JumpSpeed;
            player.JumpCount++;
        }
    }


    void Punch()
    {
        AttackMoves.Instance.Punch();
    }

    //FireBallPunch
    void FireBallPunch()
    {
        AttackMoves.Instance.FireBallPunch();
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        //Add logic for when the player exits the trigger
    }

}
