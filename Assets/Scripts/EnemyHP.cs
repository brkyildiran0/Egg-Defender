using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] int HP = 10;

    void OnParticleCollision(GameObject other)
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
        HP--;
    }
}
