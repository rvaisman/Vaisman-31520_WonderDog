using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEnemyDamage : MonoBehaviour
{
    public Animator _enemigoAnim;
    public int vida;
    float timeToGo = 7;
    int enemyScore = 15;
    bool puntajeEnviado = false;

    private void OnTriggerEnter(Collider other)
    {
       if (!isDead())
        {
            int damage = (int)GameManager.unicaInstancia.arma;
            //Debug.Log("Slime se comerá " + damage + " hp de " + GameManager.unicaInstancia.arma);
            if (other.gameObject.tag == "espadaColl")
            {
                _enemigoAnim.SetBool("isGolpeado", true);
                BajaVida(damage);
                Debug.Log("Slime tiene vida: " + vida);
            }
        }
        
    }

    public void BajaVida( int hp)
    {
        vida -= hp;
    }

    public bool isDead()
    {
        if (vida <= 0)
        {
            return true;
        } else
        {
            return false;
        }
    }
    void Start()
    {
        vida = 100;
        
    }



    // Update is called once per frame
    void Update()
    {
        if (isDead())
        {
            _enemigoAnim.SetBool("isGolpeado", true);
            _enemigoAnim.SetBool("isDead", true);
            if (!puntajeEnviado)
            {
                GameManager.unicaInstancia.SumaPuntos(enemyScore);
                puntajeEnviado = true;
            }
            
            timeToGo -= Time.deltaTime;
            if (timeToGo <= 0)
            {
                
                Destroy(this.gameObject);
            }
            

        }
    }
}
