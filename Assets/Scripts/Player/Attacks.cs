using UnityEngine;

public class Attacks : MonoBehaviour
{

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
        IDamage Enemy = Other.GetComponent<IDamage>();

        if (Enemy == null) {return;} 
        Enemy.TakeDamage(1);
    }
}


