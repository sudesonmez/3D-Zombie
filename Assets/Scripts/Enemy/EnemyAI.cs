using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    Transform target;
    public bool isDead = false;
    public float damage = 25f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            target = player.transform;
        else
            Debug.LogWarning("Player tag'ine sahip obje bulunamadý!");
    }

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < 10 && distance > 2 && !isDead)
        {
            agent.updatePosition = true;
            agent.SetDestination(target.position);
            if (anim != null)
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("Attack", false);
            }
        }
        else if (distance <= 2)
        {
            agent.updatePosition = false;
            if (anim != null)
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("Attack", true);
            }
        }
        else
        {
            if (anim != null)
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("Attack", false);
            }
        }
    }

    void AttackPlayer()
    {
        agent.updateRotation = false;
        anim.SetBool("isWalking", false);
        anim.SetBool("Attack", true);

        PlayerHealth.PH.DamagePlayer(damage);
    }

    public void Hit()
    {
        if (anim != null)
        {
            anim.SetTrigger("Hit");
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
    }
}