using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogueGuard2 : MonoBehaviour
{
    public GameObject dialogueController;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueController.GetComponent<DialogueControl>().currentIndex = 0;
            dialogueController.GetComponent<DialogueControl>().DialogoGuard2Active = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueController.GetComponent<DialogueControl>().currentIndex = 0;
            dialogueController.GetComponent<DialogueControl>().DialogoGuard2Active = false;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
