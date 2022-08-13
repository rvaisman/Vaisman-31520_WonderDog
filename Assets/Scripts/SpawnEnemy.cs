using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnEnemy : MonoBehaviour
{

    public static event Action SpawnEnemyEvent;


    public GameObject enemigo;
    public Transform spawnPoint;

    int cantEnemigos = 0;
    float timerSecs = 7f;

    public void soltarEnemigo()
    {
        Debug.Log("Inst");
        Instantiate(enemigo, spawnPoint.position, spawnPoint.rotation);
        SpawnEnemyEvent?.Invoke();
        Debug.Log("C# Event SpawnEnemy activado");
    }


    private void Start()
    {
        GameManager.unicaInstancia.enemigo = GameManager.enemyActual.slime;
    }

    // Update is called once per frame
    void Update()
    {
        timerSecs -= Time.deltaTime;
        //Debug.Log("Timer " + timerSecs);
        if (timerSecs <= 0 && cantEnemigos <= 3)

        {
            soltarEnemigo();
            Debug.Log("Cant Enemigos " + cantEnemigos);
            timerSecs = 7f;
            cantEnemigos += 1;
        }
    }
}
