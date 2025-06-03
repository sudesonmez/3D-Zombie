using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public bool isKeyObtained;
    public GameObject key;
    void Start()
    {
        isKeyObtained = false;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key1")
        {
            isKeyObtained = true;
            Destroy(key);

        }
    }


}
