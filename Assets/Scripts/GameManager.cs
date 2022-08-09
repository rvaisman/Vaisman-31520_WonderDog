using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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
    
    public enum armaActual 
    {
        espada = 30, 
        espada_mas1 = 40, 
        espada_x2 = 60 
    }; 
    public enum enemyActual
    {
        slime = 15,
        shell = 30
    };

    public static GameManager unicaInstancia;
    public Transform startPoint;

    public armaActual arma;
    public static int vida;

    public enemyActual enemigo;

    bool estaPausado;
    bool menuSalirMostrado;
    float timeToGo;

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
        Instantiate(_player, startPoint);
        arma = armaActual.espada;
        vida = 1000;
        score = 0;
        timeToGo = 8f;
        gold = 0;
        
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

        SceneManager.LoadScene("LVL 2");
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
