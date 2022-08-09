using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public Animator _enemigoAnim;
    public GameObject _playerObj;
    public float speed = 1f;

    public  void Awake()
    {
        _playerObj = GameObject.FindWithTag("Player");

    }
    public void Mirar()
    {

        //Vector3 direccionMirar = _playerObj.transform.position - transform.position; 
        transform.LookAt(_playerObj.transform);
        //transform.rotation = Quaternion.LookRotation(direccionMirar);

        //Debug.Log("X Euler " + player.rotation.x + " / Y Euler " + player.rotation.y + " / Z Euler " + player.rotation.z);

    }

    public float ChequearDistancia()
    {

        float dist = Vector3.Distance(transform.position, _playerObj.transform.position);
        //Debug.Log(dist);
        return dist;

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
