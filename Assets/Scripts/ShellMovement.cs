using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellMovement : EnemyMovement
{
    float cuentaRegresiva = 4;

    public ShellMovement()
    {
        speed = 5f;
    }

    public void SeguirJugador()
    {
        _enemigoAnim.SetBool("isGolpeado", false);
        Mirar();
        _enemigoAnim.SetBool("isAlert", true);
        _enemigoAnim.SetBool("isRunning", true);

        transform.Translate(new Vector3(0, 0, 1) * (speed * 1.25f) * Time.deltaTime);



    }

    public void WalkAround()
    {
        float randomTime = Random.Range(1f, 3f);


        Ray myRay = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward, Color.red);

        _enemigoAnim.SetBool("isAlert", false);
        _enemigoAnim.SetBool("isRunning", false);
        _enemigoAnim.SetBool("isAttackingNear", false);
        _enemigoAnim.SetBool("isAttackingFar", false);
        _enemigoAnim.SetBool("isWalking", true);
        transform.Translate(new Vector3(0, 0, 1) * (speed * 0.75f) * Time.deltaTime);

        if (cuentaRegresiva <= 0)
        {
            cuentaRegresiva = randomTime;
            Invoke("RandomTurn", randomTime);
        }
        else
        {
            cuentaRegresiva -= Time.deltaTime;
        }





    }

    public void RandomTurn()
    {


        float randomGiro = Random.Range(135f, -135f);
        transform.Rotate(0, randomGiro, 0);


    }
    public void AtacarJugadorCerca()
    {
        Mirar();
        GameManager.unicaInstancia.enemigo = GameManager.enemyActual.shell;
        _enemigoAnim.SetBool("isAttackingNear", true);
        transform.Translate(new Vector3(0, 0, 1) * (speed * 0.25f) * Time.deltaTime);


    }

    public void enemigoBatalla()
    {
        if (!_enemigoAnim.GetBool("isDead"))
        {
            switch (ChequearDistancia())
            {
                case float dist when dist <= 12 && dist > 3:

                    SeguirJugador();
                    //Debug.Log("Distancia " + ChequearDistancia());
                    break;
                case float dist when dist <= 3 && dist > 2:
                    AtacarJugadorFar();
                    //Debug.Log("Distancia " + ChequearDistancia());
                    break;
                case float dist when dist <= 2: // && dist > 1.5:
                    AtacarJugadorCerca();
                    //Debug.Log("Distancia " + ChequearDistancia());
                    break;
                default:
                    WalkAround();
                    //Debug.Log("Distancia " + ChequearDistancia());
                    break;

            }
        }




    }
    public void AtacarJugadorFar()
    {
        Mirar();
        GameManager.unicaInstancia.enemigo = GameManager.enemyActual.shell;
        _enemigoAnim.SetBool("isAttackingFar", true);
        transform.Translate(new Vector3(0, 0, 1) * (speed * 0.5f) * Time.deltaTime);


    }

    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        enemigoBatalla();
    }
}
