using UnityEngine;
using System;

[Serializable]
public class Player : MonoBehaviour
{
    public enum PlayerType
    {
        Player1,
        Player2
    }

    //Player
    [Header("Player Info")]
    [SerializeField] public PlayerType Type;
    [SerializeField] public GameObject GamePlayerOB;
    [SerializeField] public CharacterController controller;
    [SerializeField] public GameObject PunchBox;
    [SerializeField] public int Speed = 5;
    //[SerializeField] int Hearts = 3;
    //[SerializeField] int TotalJumps = 1;
    [SerializeField] public int JumpMax = 1;
    [SerializeField] public int JumpSpeed = 2;

    [Header("MISC")]
    [SerializeField] public float Gravity = 9.8f;//TODO: make both players jump higher

    //Original Stats
    [NonSerialized] public int PlayerOGHearts;

    [NonSerialized] public int PlayerOGSpeed;
    [NonSerialized] public int OGGravity;

    //Counters
    [NonSerialized] public int JumpCount;
    [NonSerialized] public Vector3 MoveDirection;
    [NonSerialized] public Vector3 JumpVelocity;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OGGravity = (int)Gravity;
        PlayerOGSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {

    }






}
