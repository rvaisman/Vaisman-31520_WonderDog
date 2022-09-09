using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EventoPortal : MonoBehaviour
{
    public static event Action EntraPortal;
    [SerializeField] private UnityEvent onEntraPortal;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EntraPortal?.Invoke();
            Debug.Log("C# Event Portal activado");

        }
    }




  
}
