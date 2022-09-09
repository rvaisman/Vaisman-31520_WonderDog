using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject _player;
    public AudioSource musicaFondo;
    public TextMeshProUGUI ScoreTextMesh;
    public TextMeshProUGUI PausaTextMesh;
    public TextMeshProUGUI SalirMenuTextMesh;
    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI GoldText;
    public Slider saludPlayer;
    public int score;
    public int gold;
    public int monedas;
    public int enemigosInstanciados;
    public GameObject destination1;
    public GameObject dialogManager;
    

    public TextMeshProUGUI unityEventsTexto;


    bool gamblerCatFirst;
    bool guard1First;
    bool guard2First;
    bool travellerFirst;
    bool dukeFirst;


    public void sayHit()
    {
        unityEventsTexto.text = "Hit";
        Debug.Log("sayHit Llamado ");
    }

    public void sayAttack()
    {
        unityEventsTexto.text = "Attack";
        Debug.Log("sayAttack Llamado");
    }

    public void sayMoving()
    {
        unityEventsTexto.text = "Moving";
        Debug.Log("sayMoving Llamado");


    }


    public enum armaActual 
    {
        espada = 30, 
        espada_mas1 = 40, 
        espada_x2 = 60 
    }; 
    public enum enemyActual
    {
        slime = 15,
        shell = 30,
        spider = 40
    };

    public static GameManager unicaInstancia;
    public Transform startPoint;

    public armaActual arma;
    public int vida;

    public enemyActual enemigo;

    bool estaPausado;
    bool menuSalirMostrado;
    float timeToGo;


    // ***********************************************************************************************
    //          Entregable Eventos C#
    // ***********************************************************************************************

    public void cuentaMonedas()
    {
        monedas += 1;
        Debug.Log("CuentaMonedas() llamado");
    }


    public void cuentaEnemigos()
    {
        enemigosInstanciados += 1;
        Debug.Log("CuentaEnemigos() llamado");
    }

    // ***********************************************************************************************
    //          Entregable Eventos C#
    // ***********************************************************************************************



    public void SumaPuntos( int puntaje)
    {
        score += puntaje;
    }

    public int GetVida()
    {
        return vida;
    }

    private void Start()
    {
        PausaTextMesh.enabled = false;
        SalirMenuTextMesh.enabled = false;
        GameOverText.enabled = false;
        estaPausado = false;
        //Instantiate(_player, new Vector3(59.19f, 2.54f, 59.91f), true);
        Instantiate(_player, new Vector3(59.19f, 2.54f , 59.91f), Quaternion.Euler(0, -90, 0), this.transform);
        //_player.transform.SetParent(this.transform);
        arma = armaActual.espada;
        vida = 1000;
        score = 0;
        timeToGo = 8f;
        gold = 0;


        gamblerCatFirst = false;
        guard1First = false;
        guard2First = false;
        travellerFirst = false;
        dukeFirst = false;

        //EventoPortal.EntraPortal += cargaEscena2;
        EventoMina.EntraMina += cargaEscena2;
        
        CoinObject.CoinEvent += cuentaMonedas;
        SpawnEnemy.SpawnEnemyEvent += cuentaEnemigos;

        unityEventsTexto.text = "Unity Events";

    }

     


    public void BajaVida(int hp)
    {
        vida -= hp;
    }

    public bool isDead()
    {
        if (vida <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void ChequeaPausa()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (estaPausado)
            {
                Time.timeScale = 1;
                musicaFondo.Play();
                estaPausado = false;
                PausaTextMesh.enabled = false;
                saludPlayer.enabled = true;
                ScoreTextMesh.enabled = true;

            }
            else
            {
                Time.timeScale = 0;
                musicaFondo.Pause();
                estaPausado = true;
                PausaTextMesh.enabled = true;
                saludPlayer.enabled = false;
                ScoreTextMesh.enabled = false;
                
                if (SceneManager.GetSceneByName("LVL TAVERN").isLoaded)
                {
                    if (dialogManager == null)
                    {
                        dialogManager = GameObject.FindWithTag("DialogMan");
                    }
                        
                    dialogManager.GetComponent<DialogueControl>().DialogoGamblerCatActive = false;
                    Debug.Log("DialogoGamblerCatActive = " + dialogManager.GetComponent<DialogueControl>().DialogoGamblerCatActive);
                    dialogManager.GetComponent<DialogueControl>().speechCatPanel.SetActive(false);
                    Debug.Log("speechCatPanel = " + dialogManager.GetComponent<DialogueControl>().speechCatPanel.activeSelf );
                    dialogManager.GetComponent<DialogueControl>().DialogoGuard1Active  = false;
                    Debug.Log("DialogoGuard1Active = " + dialogManager.GetComponent<DialogueControl>().DialogoGuard1Active);
                    dialogManager.GetComponent<DialogueControl>().speechGuard1Panel.SetActive(false);
                    Debug.Log("speechGuard1Panel = " + dialogManager.GetComponent<DialogueControl>().speechGuard1Panel.activeSelf);
                    dialogManager.GetComponent<DialogueControl>().DialogoGuard2Active = false;
                    dialogManager.GetComponent<DialogueControl>().speechGuard2Panel.SetActive(false);
                }

            }

        }
    }

    void ChequearSalirMenu()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            estaPausado = true;
            PausaTextMesh.enabled = false;
            SalirMenuTextMesh.enabled = true;
            saludPlayer.enabled = false;
            ScoreTextMesh.enabled = false;
            Debug.Log("Trace");
            menuSalirMostrado = true;


        }


        if (Input.GetKeyDown(KeyCode.Y) && menuSalirMostrado)
        {
            SceneManager.LoadScene("Menu");
            SalirMenuTextMesh.enabled = false;
            menuSalirMostrado = false;
            Time.timeScale = 1;
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.N) && menuSalirMostrado)
        {
            menuSalirMostrado = false;
            SalirMenuTextMesh.enabled = false;
            Time.timeScale = 1;
            estaPausado = false;
            PausaTextMesh.enabled = false;
            saludPlayer.enabled = true;
            ScoreTextMesh.enabled = true;
        }







    }

    public void DestroyManager()
    {
        SceneManager.LoadScene("Menu");
        //SalirMenuTextMesh.enabled = false;
        //menuSalirMostrado = false;
        //Time.timeScale = 1;
        Destroy(gameObject);
    }

    void Awake()
    {
        if (GameManager.unicaInstancia == null)
        {
            //Primera Instancia del Singleton
            GameManager.unicaInstancia = this;
            DontDestroyOnLoad(gameObject);
            vida = 1000;


        }
        else
        {
            Destroy(gameObject);
        }

        _player.SetActive(true);
        _player.GetComponent<PlayerScript>().enableMovement = true;
        _player.GetComponent<PlayerScript>()._playerAnimator.enabled = true;
        _player.GetComponent<PlayerScript>().enabled = true;
        _player.GetComponent<Animator>().gameObject.SetActive(true);
        //_player.GetComponent<Rigidbody>().WakeUp();
        _player.GetComponent<PlayerScript>().near.enabled = true;
        _player.GetComponent<PlayerScript>().far.enabled = true;
      
    }

    void updateVida()
    {
        saludPlayer.value = vida;
        ScoreTextMesh.text = " Score: " + score.ToString();
    }

    public void ResetearJuego()
    {
        if(isDead())
        {
            timeToGo -= Time.deltaTime;
            GameOverText.enabled = true;
            
            if (timeToGo <= 0)

            {
               
                
               Time.timeScale = 1;
                Destroy(gameObject);
                SceneManager.LoadScene("Menu");
            }
            
        }

    }
    public void cargaEscena2()
    {
        //Debug.Log("LoadScene() llamado");
        SceneManager.LoadScene("LVL 2");
        _player.transform.position = new Vector3(60.23f, 1.8f, 59.55492f);
        


    }

    public void CargaTaverna()
    {
        //Debug.Log("LoadScene() llamado");

        _player.GetComponent<PlayerScript>().enableMovement = false;
        _player.GetComponent<Animator>().gameObject.SetActive(false);
        _player.GetComponent<PlayerScript>()._playerAnimator.enabled = false;
        _player.GetComponent<PlayerScript>().near.enabled = false;
        _player.GetComponent<PlayerScript>().far.enabled = false;
        //_player.GetComponent<Rigidbody>().Sleep();
        //_player.GetComponent<Collider>().enabled = true;
        //_player.GetComponent<Rigidbody>().velocity = Vector3.zero; 
        _player.SetActive(false);
        _player.GetComponent<PlayerScript>().enabled = false;
        //_player.GetComponent<PlayerScript>().cc.enabled = false;
        Time.timeScale = 0;

        //_player.GetComponent<Rigidbody>().position = destination1.transform.position;
        //_player.transform.position = destination1.transform.position;
        Physics.SyncTransforms();
        _player.gameObject.transform.position = destination1.transform.position;
        Physics.SyncTransforms();

       // if (!SceneManager.GetSceneByName("LVL TAVERN").isLoaded)
       // {
       //     SceneManager.LoadScene("LVL TAVERN", LoadSceneMode.Additive);
       // }
            
            

        _player.GetComponent<PlayerScript>().enabled = true;
        Time.timeScale = 1;
        _player.SetActive(true);
        _player.GetComponent<Animator>().gameObject.SetActive(true);
        //_player.GetComponent<Collider>().enabled = true;
        //_player.GetComponent<Rigidbody>().WakeUp();
        _player.GetComponent<PlayerScript>().near.enabled = true;
        _player.GetComponent<PlayerScript>().far.enabled = true;
        _player.GetComponent<PlayerScript>().enableMovement = true;
        _player.GetComponent<PlayerScript>()._playerAnimator.enabled = true;
        //_player.GetComponent<PlayerScript>().cc.enabled = true;







    }

    private void OnDisable()
    {
        EventoMina.EntraMina -= cargaEscena2;
        CoinObject.CoinEvent -= cuentaMonedas;
        SpawnEnemy.SpawnEnemyEvent += cuentaEnemigos;

    }


    public void Update()
    {
        ChequeaPausa();
        ChequearSalirMenu();
        updateVida();
        ResetearJuego();
        GoldText.text   = " Gold: " + gold.ToString();

        if (Input.GetKey(KeyCode.L))
        {
            SceneManager.LoadScene("LVL 2");
            
            
        }
        if (Input.GetKey(KeyCode.K))
        {
            SceneManager.LoadScene("LVL 1");
            
            
        }
        


    }


}
