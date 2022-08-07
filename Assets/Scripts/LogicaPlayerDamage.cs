using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPlayerDamage : MonoBehaviour
{
    public Animator _playerAnim;
    public static int vida;
    

    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.unicaInstancia.isDead())
        {
            int damage = (int)GameManager.unicaInstancia.enemigo;

            if (other.gameObject.tag == "enemyColl")
            {
                _playerAnim.SetBool("isRunning", false);
                _playerAnim.SetBool("isWalking", false);
                _playerAnim.SetBool("isGolpeado", true);
                Debug.Log("Hit on Player");
                GameManager.unicaInstancia.BajaVida(damage);
                Debug.Log("Damage " + GameManager.unicaInstancia.GetVida());

            }
            if (other.gameObject.tag == "Portal_a_LVL2")
            {
                GameManager.unicaInstancia.cargaEscena2();

            }
        }
        
    }


    void Update()
    {  
        
        if (GameManager.unicaInstancia.isDead())
        {
            _playerAnim.SetBool("isGolpeado", true);
            _playerAnim.SetBool("isDead", true);
        }


    }
}
