using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement; 
using Cinemachine; 

public class PlayerScript : MonoBehaviour
{
    public GameObject _Player;
    //public CharacterController cc;
    public Animator _playerAnimator;
    public float speed;
    public CinemachineVirtualCamera near;
    public CinemachineVirtualCamera far;
    public bool enableMovement = true;
    float hor;
    float ver;
    Vector3 inputPlayer;
    public GameObject Taverna;
    public Transform destination1;
    public GameObject SalidaTaverna;
    public Transform destination2;
    public GameObject PortalBack;
    public Transform destination3;

    public float jumpVelocity = 10f;

    [SerializeField] private UnityEvent onAttack;
    [SerializeField] private UnityEvent onPlayer;


    private void OnTriggerEnter(Collider other)
    {
        
            if (other.gameObject.tag == "Interior")
            {
            near.Priority = 10;
            far.Priority = 0;
            
            }

        if (other.gameObject.tag == "Taverna")
        {
            enableMovement = false;
            //_playerAnimator.gameObject.SetActive(false);
            _playerAnimator.enabled = false;
            near.enabled = false;
            far.enabled = false;
            CargaTaverna();
            Physics.SyncTransforms();
        }


        if (other.gameObject.tag == "AlCastillo")
        {
            enableMovement = false;
            //_playerAnimator.gameObject.SetActive(false);
            _playerAnimator.enabled = false;
            near.enabled = false;
            far.enabled = false;
            AlCastillo();
            Physics.SyncTransforms();
        }

        if (other.gameObject.tag == "SalidaTaverna")
        {
            enableMovement = false;
            //_playerAnimator.gameObject.SetActive(false);
            _playerAnimator.enabled = false;
            near.enabled = false;
            far.enabled = false;
            DescargaTaverna();
            Physics.SyncTransforms();
        }
    }

    private void OnTriggerStay (Collider other)
    {

        if (other.gameObject.tag == "Taverna")
        {
            CargaTaverna();

        }
        if (other.gameObject.tag == "SalidaTaverna")
        {
            DescargaTaverna();

        }

       

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Interior")
        {
            near.Priority = 0;
            far.Priority = 10;

        }

        if (other.gameObject.tag == "Taverna")
        {
            ReactivatePlayer();

        }

        if (other.gameObject.tag == "SalidaTaverna")
        {
            ReactivatePlayer();

        }
        if (other.gameObject.tag == "AlCastillo")
        {
            ReactivatePlayer();

        }
    }

    void ReactivatePlayer()
    {
        //_player.GetComponent<PlayerScript>().enabled = true;

        //_player.SetActive(true);
        _playerAnimator.gameObject.SetActive(true);
        //_player.GetComponent<Collider>().enabled = true;
        //_player.GetComponent<Rigidbody>().WakeUp();
        near.enabled = true;
        far.enabled = true;
        enableMovement = true;
        _playerAnimator.enabled = true;
        //_player.GetComponent<PlayerScript>().cc.enabled = true;

    }

    public void resetGolpeado()
    {
        _playerAnimator.SetBool("isGolpeado", false);
    }

    /*public void InputPlayer()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        inputPlayer = new Vector3(hor, 0, ver);
    } */
    public void MovimientoPlayer()
    {

        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        inputPlayer = new Vector3(hor, 0, ver);

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
                else if (ver > 0)
                {
                    _playerAnimator.SetBool("isWalking", true);
                    _playerAnimator.SetBool("isRunning", false);
                    speed = 2;
                    
                }

            //Debug.Log("Hor: " + hor);
            //Debug.Log("Ver: " + ver);
            _Player.transform.Translate(new Vector3(0, 0, ver) * speed * Time.deltaTime);
            _Player.transform.Rotate(new Vector3(0, hor, 0) * speed * 25 * Time.deltaTime);
            // cc.Move(new Vector3(hor, 0, ver ) * speed * Time.deltaTime);
           //cc.transform.Rotate(Vector3.up * hor * (100f * Time.deltaTime));
           // cc.Move(cc.transform.forward * ver * speed * Time.deltaTime);

           
                
        }

            if (Input.GetKey(KeyCode.LeftAlt))
            {
                _playerAnimator.SetBool("isAttacking1", true);
                onAttack.Invoke();

            }
            else
            {
                _playerAnimator.SetBool("isAttacking1", false);

            }

        if (Input.GetKey(KeyCode.V))
        {
            GameManager.unicaInstancia.vida += 150 ;
            

        }




    }


    public void CargaTaverna()
    {
        //Debug.Log("LoadScene() llamado");

        if (!SceneManager.GetSceneByName("LVL TAVERN").isLoaded)
        {
            SceneManager.LoadScene("LVL TAVERN", LoadSceneMode.Additive);
        }
        //_player.GetComponent<Rigidbody>().Sleep();
        //_player.GetComponent<Collider>().enabled = true;
        //_player.GetComponent<Rigidbody>().velocity = Vector3.zero; 
        //this.SetActive(false);
        //_player.GetComponent<PlayerScript>().enabled = false;
        //_player.GetComponent<PlayerScript>().cc.enabled = false;
        

        //_player.GetComponent<Rigidbody>().position = destination1.transform.position;
        //_player.transform.position = destination1.transform.position;
        Physics.SyncTransforms();
        transform.position = destination1.transform.position;
        Physics.SyncTransforms();





       





    }

    public void DescargaTaverna()
    {
        //Debug.Log("LoadScene() llamado");

       
        
        Physics.SyncTransforms();
        transform.position = destination2.transform.position;
        Physics.SyncTransforms();

        if (SceneManager.GetSceneByName("LVL TAVERN").isLoaded)
        {
            SceneManager.UnloadScene("LVL TAVERN");   
        }









    }


    public void AlCastillo()
    {
        //Debug.Log("LoadScene() llamado");
        Physics.SyncTransforms();
        transform.position = destination3.transform.position;
        Physics.SyncTransforms();

        if (!SceneManager.GetSceneByName("LVL 1").isLoaded)
        {
            SceneManager.LoadScene("LVL 1");
        }
        //_player.GetComponent<Rigidbody>().Sleep();
        //_player.GetComponent<Collider>().enabled = true;
        //_player.GetComponent<Rigidbody>().velocity = Vector3.zero; 
        //this.SetActive(false);
        //_player.GetComponent<PlayerScript>().enabled = false;
        //_player.GetComponent<PlayerScript>().cc.enabled = false;


        //_player.GetComponent<Rigidbody>().position = destination1.transform.position;
        //_player.transform.position = destination1.transform.position;
        











    }

    // Start is called before the first frame update

    private void Awake()
    {
        _playerAnimator.gameObject.SetActive(true);
        //_player.GetComponent<Collider>().enabled = true;
        //_player.GetComponent<Rigidbody>().WakeUp();
        near.enabled = true;
        far.enabled = true;
        enableMovement = true;
        _playerAnimator.enabled = true;
        //_player.GetComponent<PlayerScript>().cc.enabled = true;
 
            //Taverna = GameObject.FindGameObjectsWithTag("Taverna");
            destination1 = Taverna.transform;
        

        Debug.Log("Found Taverna at " + destination1.position);
        destination2 = SalidaTaverna.transform;
        destination3 =  PortalBack.transform;


        Debug.Log("Found Salida Taverna at " + destination2.position);
    }

    void Start()
    {
        near.Priority = 0;
        far.Priority = 10;
       

    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameManager.unicaInstancia.isDead())
        {
            if (enableMovement)
            {
                MovimientoPlayer();
            } else
            {
                if (!enableMovement)
                {
                    hor = 0;
                    ver = 0;
                }
            }
        }
        
        
    }
}
