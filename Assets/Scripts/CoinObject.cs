using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObject : MonoBehaviour
{
    
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.unicaInstancia.gold += valor * cant;
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
   
}
