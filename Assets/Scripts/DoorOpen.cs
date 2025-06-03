using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject actionText;
    public GameObject hinge;
    public AudioSource doorSound;
  

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
    }

    void OnMouseOver()
    {
        bool isClose = theDistance <= 2;

        actionKey.SetActive(isClose);
        actionText.SetActive(isClose);

        if (isClose && Input.GetButtonDown("Action"))
        {
            actionKey.SetActive(false);
            actionText.SetActive(false);
            hinge.GetComponent<Animation>().Play("dooranim");
            doorSound.Play();
        }
    }

    void OnMouseExit()
    {
        actionKey.SetActive(false);
        actionText.SetActive(false);
    }

    
}
