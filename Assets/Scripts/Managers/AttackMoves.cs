using System.Collections;
using UnityEngine;

public class AttackMoves : MonoBehaviour
{
    public static AttackMoves Instance;

    [SerializeField] public GameObject PunchBox;
    [SerializeField] GameObject FireBall;

    //uppercut

    //Dragon Fist

    //Air Fist


    private void Awake()
    {
        //needed to initiate this class
        if (!Instance) { Instance = this; }
    }

    public void Punch()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKey("f"))
        {
            StartCoroutine(AttackHitBox());
        }

        //bug test
        /* if (Input.GetKey("g") && PunchBox.activeSelf == false)
         {
             PunchBox.SetActive(true);
         }
         else if (Input.GetKey("h") && PunchBox.activeSelf == true)
         {
             PunchBox.SetActive(false);
         }*/
    }

    public void FireBallPunch(int Meters = 2)
    {
        int MetersNeeded = Meters;
        if (Input.GetKeyDown("e"))
        {
            if (GameManager.Instance.GetMeterAmount() < MetersNeeded)
            {
                //display "Not enough meter"
                StartCoroutine(GameManager.Instance.DisplayWarning(GameManager.Instance.NoMeterLabel));

                //display meters needed
                StartCoroutine(GameManager.Instance.DisplayWarningMeters(MetersNeeded));
                return;
            }
            else
            {
                Debug.Log("Fire Ball");
                Instantiate(FireBall, PunchBox.transform.position, PunchBox.transform.rotation);

                for (int i = 0; i < MetersNeeded; i++)
                {
                    GameManager.Instance.AddMeter(false);
                }
            }
        }

    }

    IEnumerator AttackHitBox()
    {
        PunchBox.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        PunchBox.SetActive(false);
    }

}
