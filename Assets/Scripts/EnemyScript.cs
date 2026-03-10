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

        if (Health <= 0 && Type == EnemyType.Grave)
        {
            GameManager.Instance.AddMeter();
            GameManager.Instance.AddScore(100);
            if (RandomNUM <= 50)//50% to spawn zombie
            {
                Instantiate(GameManager.Instance.Zombie, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }

        if (Health <= 0 && Type == EnemyType.Zombie)
        {
            GameManager.Instance.AddMeter();
            GameManager.Instance.AddScore(500);
            Destroy(gameObject);
        }
    }

}
