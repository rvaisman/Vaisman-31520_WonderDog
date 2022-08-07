using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject _Player;
    public Animator _playerAnimator;
    public float speed; 

    public void resetGolpeado()
    {
        _playerAnimator.SetBool("isGolpeado", false);
    }
    public void MovimientoPlayer()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 inputPlayer = new Vector3(hor, 0, ver);

        

        if (inputPlayer == Vector3.zero)
        {


            _playerAnimator.SetBool("isIdle", true);
            _playerAnimator.SetBool("isRunning", false);
            _playerAnimator.SetBool("isWalking", false);


        }
        else
        {


            if (ver > 0 && Input.GetKey(KeyCode.LeftShift))
            {
                _playerAnimator.SetBool("isRunning", true);
                _playerAnimator.SetBool("isWalking", false);
                speed = 6;
            }
            else if (ver > 0 )
            {
                _playerAnimator.SetBool("isWalking", true);
                _playerAnimator.SetBool("isRunning", false);
                speed = 2;
            }

            //Debug.Log("Hor: " + hor);
            //Debug.Log("Ver: " + ver);
            _Player.transform.Translate(new Vector3(0, 0, ver) * speed * Time.deltaTime);
            _Player.transform.Rotate(new Vector3(0, hor, 0) * speed * 15 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            _playerAnimator.SetBool("isAttacking1", true);

        }
        else
        {
            _playerAnimator.SetBool("isAttacking1", false);

        }

        


    }

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.unicaInstancia.isDead())
        {
            MovimientoPlayer();
        }
        
        
    }
}
