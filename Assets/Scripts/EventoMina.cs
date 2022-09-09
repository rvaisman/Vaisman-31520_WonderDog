using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EventoMina : MonoBehaviour
{
    public static event Action EntraMina;
    [SerializeField] private UnityEvent onEntraMina;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EntraMina?.Invoke();
            onEntraMina.Invoke(); 


        }
    }





}
