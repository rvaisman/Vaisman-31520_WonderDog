using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventoPortal : MonoBehaviour
{
    public static event Action EntraPortal;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EntraPortal?.Invoke();
            Debug.Log("C# Event Portal activado");

        }
    }




  
}
