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
        if (isDead) return; // �l� ise art�k hasar almaz

        enemyHealth -= reduceHealth;

        if (enemyHealth > 0)
        {
            if (enemy != null)
            {
                enemy.Hit();  // Hit de�il, senin �nceki mesaj�nda 'Hurt' trigger varm��
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