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

    void Start()
    {
        if (Type == EnemyType.Zombie) { Health = 3; }
    }

    void Update()
    {
     
        
    }

    public void TakeDamage(int DamageTaken)
    {
        Health -= DamageTaken;

        if (Health <= 0 && Type == EnemyType.Grave)
        {
            GameManager.Instance.AddMeter(true);
            GameManager.Instance.AddScore(100);
            Destroy(gameObject);
        }

        if (Health <= 0 && Type == EnemyType.Zombie)
        {
            GameManager.Instance.AddMeter(true);
            GameManager.Instance.AddScore(500);
            Destroy(gameObject);
        }
    }

}
