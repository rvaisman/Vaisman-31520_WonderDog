using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManagerEnding : MonoBehaviour
{
    //public TextMeshProUGUI mainText;
  
    string[] dialoguePagesDuke1 = new string[5];
    
  
    bool dukeFirst;

  
    public bool DialogoDuketActive;

 
    public TextMeshProUGUI speechDuke;

 
    public GameObject speechDukePanel;

    public int currentIndex;

    private bool spawned = false;
    private float decay;

    public Image endImage;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    void inicializarDialogos()
    {
       
        dukeFirst = true;

     
        dialoguePagesDuke1[0] = "Your services will always be remembered valiant dog. I am afraid that time is at stake at this moment. I am leading the final but I think that all is lost here";
        dialoguePagesDuke1[1] = "The Rulers of all towns are regrouping whats left of their troops to secure refugees. We expect to have a fortified settlement ready by the end of next week. Only then we will be able to prepare a counter assault";
        dialoguePagesDuke1[2] = "If you are heading to Bicho Land Royal City you must use this portal. All roads are infested with thise invader vermin. If you are able to reach the Palace, tell the King and the Princess we will march to the Capital when ready";
        dialoguePagesDuke1[3] = "Thanks for your service. You are really a Wonder Dog. Now get to the portal before a new wave of monsters comes";
        dialoguePagesDuke1[4] = "<END>";
        
    }

 

    private void Reset()
    {
        if (spawned && decay > 0)
        {
            decay -= Time.deltaTime;
        }
        if (decay < 0)
        {
            decay = 0;
            spawned = false;
        }
    }



 

    public void DialogoDuke()
    {
        speechDukePanel.SetActive(true);


        if (dukeFirst)
        {
            if (currentIndex == 0)
            {
                speechDuke.text = dialoguePagesDuke1[0];
            }


            if (dialoguePagesDuke1[currentIndex + 1] != "<END>")
            {
                if (Input.GetKey(KeyCode.Return) && !spawned)
                {
                    currentIndex++;
                    decay = 1f;
                    spawned = true;
                    speechDuke.text = dialoguePagesDuke1[currentIndex];
                }
            }
            else
            {
                speechDukePanel.SetActive(false);
                DialogoDuketActive = false;
                endImage.color = Color.white; 
                 endImage.CrossFadeAlpha(1f, 2f, false);
                Invoke("showText1", 2);
                Invoke("showText2", 6);
                Invoke("Salir", 9);
                //catFirst = false;

            }
        }
       


    }

    void showText1()
    {
        text1.color = Color.white;
    }


    void showText2()
    {
        text2.color = Color.white;
    }

    void Salir()
    {
        GameManager.unicaInstancia.DestroyManager();
    }
    // Start is called before the first frame update

    private void Awake()
    {
        inicializarDialogos();
 
        speechDukePanel.SetActive(false);
        currentIndex = 0;

    }

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
  
      
            Reset();
            DialogoDuke();
        
       
            //speechDukePanel.SetActive(false);
        
    }
}
