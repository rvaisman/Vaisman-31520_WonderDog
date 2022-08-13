using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinObject : MonoBehaviour
{

    public static event Action CoinEvent;

    public Coin moneda;
    public int valor;
    public int cant;
    public float escala;


    
    // Start is called before the first frame update
    void Start()
    {
        valor = moneda.valor;
        cant = moneda.cantidad;
        escala = moneda.scale;
        transform.localScale = new Vector3(escala, escala, escala);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.unicaInstancia.gold += valor * cant;
            CoinEvent?.Invoke();
            Debug.Log("C# Event CoinObject activado");
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
   
}
