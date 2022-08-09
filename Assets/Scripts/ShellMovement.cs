using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellMovement : EnemyMovement
{


    public ShellMovement()
    {
        speed = 2.5f;
    }

    public void SeguirJugador()
    {
        _enemigoAnim.SetBool("isGolpeado", false);
        Mirar();
        _enemigoAnim.SetBool("isAlert", true);
        _enemigoAnim.SetBool("isRunning", true);
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.Translate(new Vector3(0, 0, 1) * (speed * 1.25f) * Time.deltaTime);



    }

    public void WalkAround()
    {
        Ray myRay = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, new Vector3(0, 0, 3), Color.red);
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        _enemigoAnim.SetBool("isAlert", false);
        _enemigoAnim.SetBool("isRunning", false);
        _enemigoAnim.SetBool("isAttackingNear", false);
        _enemigoAnim.SetBool("isAttackingFar", false);
        _enemigoAnim.SetBool("isWalking", true);
        transform.Translate(new Vector3(0, 0, 1) * (speed * 0.75f) * Time.deltaTime);





    }
    public void AtacarJugadorCerca()
    {
        Mirar();
        _enemigoAnim.SetBool("isAttackingNear", true);
        transform.Translate(new Vector3(0, 0, 1) * (speed * 0.25f) * Time.deltaTime);


    }

    public void enemigoBatalla()
    {
        if (!_enemigoAnim.GetBool("isDead"))
        {
            switch (ChequearDistancia())
            {
                case float dist when dist <= 8 && dist > 3:

                    SeguirJugador();
                    //Debug.Log("Distancia " + ChequearDistancia());
                    break;
                case float dist when dist <= 3 && dist > 2:
                    AtacarJugadorFar();
                    Debug.Log("Distancia " + ChequearDistancia());
                    break;
                case float dist when dist <= 2: // && dist > 1.5:
                    AtacarJugadorCerca();
                    Debug.Log("Distancia " + ChequearDistancia());
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
