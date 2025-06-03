using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public static PlayerHealth PH;
    public bool isdead = false;
    
    void Awake()
    {
        PH = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    { if(currentHealth <=0) {
        currentHealth=0;
        
        }}
    public void DamagePlayer( float damage)
    {
        if (isdead) return;

        currentHealth -= damage;
     ;
    }

    void Dead()
    {
        isdead = true;
        Debug.Log("öldüm");
    }
}
