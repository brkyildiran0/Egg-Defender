using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] int maxHP = 10;
    [SerializeField] int currentHP = 0;

    void OnEnable()
    {
        currentHP = maxHP;    
    }

    void OnParticleCollision(GameObject other)
    {
        currentHP--;

        if (currentHP <= 0)
        {
            gameObject.SetActive(false);
        } 
    }
}
