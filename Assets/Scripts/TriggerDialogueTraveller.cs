using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogueTraveller : MonoBehaviour
{
    public GameObject dialogueController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueController.GetComponent<DialogueControl>().currentIndex = 0;
            dialogueController.GetComponent<DialogueControl>().DialogoTravellerActive = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueController.GetComponent<DialogueControl>().currentIndex = 0;
            dialogueController.GetComponent<DialogueControl>().DialogoTravellerActive = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
