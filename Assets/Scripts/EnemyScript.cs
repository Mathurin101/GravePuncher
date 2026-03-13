using UnityEngine;

public class EnemyScript : MonoBehaviour, IDamage
{
    enum EnemyType
    {
        Grave,
        Zombie
    }

    [SerializeField] int Health = 1;
    [SerializeField] EnemyType Type;

    int RandomNUM;

    void Start()
    {
        if (Type == EnemyType.Zombie) { Health = 3; }

        //TODO: Add rounds soon
        //Random.Range(1, 100 * int.parse(GameManager.Instance.Rounds.text));
        RandomNUM = Random.Range(1, 100);
    }

    void Update()
    {


    }

    public void TakeDamage(int DamageTaken)
    {
        Health -= DamageTaken;

        Debug.Log(GetComponent<Collider>().name + " Hit me");

        if (Health <= 0 && Type == EnemyType.Grave)
        {
            if (AttackMoves.isPlayer1)
            {
                GameManager.Instance.AddMeter(GameManager.Instance.GetMeter(), GameManager.Instance.GetMeterAmount());
                GameManager.Instance.AddScore(100, GameManager.Instance.GetScore());
            }
            else if (AttackMoves.isPlayer2)
            {
                GameManager.Instance.AddMeter(GameManager.Instance.GetMeter(), GameManager.Instance.GetMeterAmount());
                GameManager.Instance.AddScore(100, GameManager.Instance.GetScoreP2());
            }

            if (RandomNUM <= 50)//50% to spawn zombie
            {
                Instantiate(GameManager.Instance.Zombie, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }

        if (Health <= 0 && Type == EnemyType.Zombie)
        {

            if (AttackMoves.isPlayer1)
            {
                GameManager.Instance.AddMeter(GameManager.Instance.GetMeter(), GameManager.Instance.GetMeterAmount());
                GameManager.Instance.AddScore(500, GameManager.Instance.GetScore());
            }
            else if (AttackMoves.isPlayer2)
            {
                GameManager.Instance.AddMeter(GameManager.Instance.GetMeter(), GameManager.Instance.GetMeterAmount());
                GameManager.Instance.AddScore(500, GameManager.Instance.GetScoreP2());
            }
            Destroy(gameObject);
        }

    }
}