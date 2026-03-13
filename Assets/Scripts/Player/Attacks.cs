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
        if (AttackType == TypeAttack.FireBall)
        {
            MovingAttack();
        }
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (AttackType == TypeAttack.punch)
        {
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

    void MovingAttack()
    {
        //move forward(z) on the z aixs
        gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.forward * 10;

        //Destroy after a set amount of time
        if (this) { Destroy(gameObject, 1.1f); }
    }
}


