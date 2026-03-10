using UnityEngine;

public class Attacks : MonoBehaviour
{
    enum TypeAttack
    {
        punch,
        FireBall
    }
    [SerializeField] TypeAttack AttackType;

    // Start is called once before the first execution of Update 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider Other)
    {
        if (AttackType == TypeAttack.punch)
        {
            Debug.Log("Punched: " + Other.name);
            IDamage Enemy = Other.GetComponent<IDamage>();

            if (Enemy == null) { return; }
            Enemy.TakeDamage(1);
        }

        if (AttackType == TypeAttack.FireBall)
        {
            Debug.Log("FireBall Hit: " + Other.name);
            IDamage Enemy = Other.GetComponent<IDamage>();

            if (Enemy == null) { return; }
            Enemy.TakeDamage(2);

            Destroy(gameObject);

        }
    }
}


