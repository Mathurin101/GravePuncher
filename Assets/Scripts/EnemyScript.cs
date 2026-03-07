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

        if (Health <= 0)
        {
            GameManager.Instance.AddMeter(true);
            Destroy(gameObject);
        }
    }

}
