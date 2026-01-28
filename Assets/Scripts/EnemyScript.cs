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
            Destroy(gameObject);
        }
        else if (Type == EnemyType.Zombie)
        {
            Debug.Log("Zombie took damage");
        }
        else if (Type == EnemyType.Grave)
        {
            Debug.Log("Grave took damage");
        }
    }

}
