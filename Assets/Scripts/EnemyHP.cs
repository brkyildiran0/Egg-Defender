using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHP : MonoBehaviour
{
    [SerializeField] int maxHP = 3;

    [Tooltip("Adds amount to maxHP on rim destruction")]
    [SerializeField] int difficultyRamp = 1;
    int currentHP = 0;

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
            maxHP += difficultyRamp;
            enemy.RewardGold();
        } 
    }
}
