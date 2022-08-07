using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaEspada : MonoBehaviour
{

    public BoxCollider espadaColl;

    // Start is called before the first frame update
    
    public void ActivarEspada()
    {
        espadaColl.enabled = true;
    }
    
    public void DesactivarEspada()
    {
        espadaColl.enabled = false;
    }

    private void Start()
    {
        DesactivarEspada();
    }
}
