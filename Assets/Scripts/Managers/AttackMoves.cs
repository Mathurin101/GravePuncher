using System.Collections;
using UnityEngine;

public class AttackMoves : MonoBehaviour
{
    public static AttackMoves Instance;

    [SerializeField] Player player;
    [SerializeField] Player player2;
    [SerializeField] GameObject FireBall;

    //uppercut

    //Dragon Fist

    //Air Fist

    public static bool isPlayer1;
    public static bool isPlayer2;

    private void Awake()
    {
        //needed to initiate this class
        if (!Instance)
        {
            Instance = this;

            isPlayer1 = Player.PlayerType.Player1 == player.Type;
            isPlayer2 = Player.PlayerType.Player2 == player.Type;
        }
    }

    public void Punch()
    {
        StartCoroutine(AttackHitBox());
    }

    public void FireBallPunch(int Meters = 2)
    {
        int MetersNeeded = Meters;
        if (Input.GetKeyDown("e") && isPlayer1)
        {
            if (GameManager.Instance.GetMeterAmount() < MetersNeeded)
            {
                //display "Not enough meter"
                StartCoroutine(GameManager.Instance.DisplayWarning(GameManager.Instance.NoMeterLabel));

                //display meters needed
                StartCoroutine(GameManager.Instance.DisplayWarningMeters(MetersNeeded, GameManager.Instance.NotBarMeterP1));
                return;
            }
            else
            {
                Instantiate(FireBall, player.PunchBox.transform.position, player.PunchBox.transform.rotation);

                for (int i = 0; i < MetersNeeded; i++)
                {
                    GameManager.Instance.AddMeter(GameManager.Instance.GetMeter(), ref GameManager.Instance.CounterP1, false);
                }
            }
        }

        if (Input.GetKeyDown(".") && isPlayer2)
        {
            if (GameManager.Instance.GetMeterAmount() < MetersNeeded)
            {
                //display "Not enough meter"
                StartCoroutine(GameManager.Instance.DisplayWarning(GameManager.Instance.NoMeterLabelP2));
                //display meters needed
                StartCoroutine(GameManager.Instance.DisplayWarningMeters(MetersNeeded, GameManager.Instance.NotBarMeterP2));
                return;
            }
            else
            {
                Debug.Log("Fire Ball");
                Instantiate(FireBall, player2.PunchBox.transform.position, player2.PunchBox.transform.rotation);
                for (int i = 0; i < MetersNeeded; i++)
                {
                    GameManager.Instance.AddMeter(GameManager.Instance.GetMeterP2(), ref GameManager.Instance.CounterP1, false);
                }
            }
        }
    }

    IEnumerator AttackHitBox()
    {
        if (Input.GetKeyDown("f"))
        {
            player.PunchBox.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            player.PunchBox.SetActive(false);
        }
        else if (Input.GetKeyDown(","))
        {
            Debug.Log("Just punched");
            player2.PunchBox.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            player2.PunchBox.SetActive(false);
        }
    }

}
