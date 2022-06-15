using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] int maxHP = 3;
    [SerializeField] int currentHP = 0;

    Enemy enemy;

    void Awake()
    {
        enemy = GetComponent<Enemy>();  
    }

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
            enemy.RewardGold();
        } 
    }
}
