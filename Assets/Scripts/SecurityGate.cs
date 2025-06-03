using UnityEngine;

public class SecurityGate : MonoBehaviour
{

    public float theDistance;
    public GameObject actionKey;
    public GameObject actionText;
    public GameObject doorAnim;
    public AudioSource doorSound;
    public GameObject closedDoorText;
    KeyManager key;

    void Update()
    {
        key = FindObjectOfType<KeyManager>();
    }

    void OnMouseOver()
    {
        void OnMouseOver()
        {
            if (theDistance <= 2)
            {



                actionKey.SetActive(true);
                actionText.SetActive(true);

            }
            else
            {
                actionKey.SetActive(false);
                actionText.SetActive(false);

            }
        }

        if (Input.GetButtonDown("Action") && key.isKeyObtained==true)
        {
            actionKey.SetActive(false);
            actionText.SetActive(false);
            doorAnim.GetComponent<Animation>().Play("");
            doorSound.Play();
        }
    }

    void OnMouseExit()
    {
        actionKey.SetActive(false);
        actionText.SetActive(false);
    }

}
