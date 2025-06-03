using System.Collections;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    RaycastHit hit;

    public ParticleSystem muzzleFlash;

    AudioSource pistolAs;
    public AudioClip shootAC;

    [SerializeField]
    int currentAmmo;
    [SerializeField]
    float rateOffire;
    float nextFire;
    [SerializeField]
    float weaponRange;
    public float damage = 20f;

    public Transform shootPoint;

    EnemyHealth enemy;

    void Start()
    {
        pistolAs = GetComponent<AudioSource>();
        muzzleFlash.Stop();
        enemy = FindObjectOfType<EnemyHealth>();
    }


    void Update()
    {
        if (Input.GetButton("Fire1") && currentAmmo > 0)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + rateOffire;
            pistolAs.PlayOneShot(shootAC);
            currentAmmo--;

            if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, weaponRange))
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
                    if (enemy != null)
                    {
                        enemy.ReduceHealth(damage);
                    }
                }
                else
                {
                    Debug.Log("Something Else");
                }
            }
        }
    }


}