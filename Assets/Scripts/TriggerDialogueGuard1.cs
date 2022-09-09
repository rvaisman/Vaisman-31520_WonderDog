using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogueGuard1 : MonoBehaviour
{
    public GameObject dialogueController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueController.GetComponent<DialogueControl>().currentIndex = 0;
            dialogueController.GetComponent<DialogueControl>().DialogoGuard1Active = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueController.GetComponent<DialogueControl>().currentIndex = 0;
            dialogueController.GetComponent<DialogueControl>().DialogoGuard1Active = false;
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
