using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;
    EnemyAI enemy;
    bool isDead = false;

    void Start()
    {
        enemy = GetComponent<EnemyAI>();
    }

    public void ReduceHealth(float reduceHealth)
    {
        if (isDead) return; // Ölü ise artýk hasar almaz

        enemyHealth -= reduceHealth;

        if (enemyHealth > 0)
        {
            if (enemy != null)
            {
                enemy.Hit();  // Hit deðil, senin önceki mesajýnda 'Hurt' trigger varmýþ
            }
        }
        else
        {
            isDead = true;
            if (enemy != null)
            {
                enemy.Dead();
            }
            Dead();
        }
    }

    void Dead()
    {
        Destroy(gameObject);
    }
}