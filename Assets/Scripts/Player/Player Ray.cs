using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    public static float distanceFromTarget;
    public float toTarget;




    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
            toTarget = hit.distance;
            distanceFromTarget = toTarget;

        }
  
  } 
}

