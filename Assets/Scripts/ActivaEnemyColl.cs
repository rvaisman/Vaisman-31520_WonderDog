using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaEnemyColl : MonoBehaviour
{

    public BoxCollider enemyColl;
   
    public void activarEnemyColl()
    {

        enemyColl.enabled = true;

    }

    public void desactivarEnemyColl()
    {
        enemyColl.enabled = false;

    }

    private void Start()
    {
        enemyColl.enabled = false;
    }

}
