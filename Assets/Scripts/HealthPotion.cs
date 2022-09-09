using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.unicaInstancia.vida += 750;
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
    
}
