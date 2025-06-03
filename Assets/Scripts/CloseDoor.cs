using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    //public GameObject actionText;
  //  public GameObject hinge;
    public AudioSource doorSound;
    public GameObject closedDoorText;

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
    }

    void OnMouseOver()
    {
        bool isClose = theDistance <= 2;

        actionKey.SetActive(isClose);
        

        if (isClose && Input.GetButtonDown("Action"))
        {
            actionKey.SetActive(false);
            closedDoorText.SetActive(true);
       
            doorSound.Play();
        }
    }

    void OnMouseExit()
    {
        actionKey.SetActive(false);
       
    }


}
