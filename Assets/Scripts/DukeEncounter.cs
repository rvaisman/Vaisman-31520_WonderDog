using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DukeEncounter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!SceneManager.GetSceneByName("Duke Encounter").isLoaded)
            {
                SceneManager.LoadScene("Duke Encounter", LoadSceneMode.Additive);
            }
        }
    }
}
