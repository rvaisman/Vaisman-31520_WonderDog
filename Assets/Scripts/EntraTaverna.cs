using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntraTaverna : MonoBehaviour
{

    [SerializeField] private UnityEvent onEntraTaverna;
    // Start is called before the first frame update
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //onEntraTaverna.Invoke();
            //this.enabled = false;

        }
    }
}
