using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueControl : MonoBehaviour
{
    //public TextMeshProUGUI mainText;
    string[] dialoguePagesCat1 = new string[8];
    string[] dialoguePagesCat2 = new string[3];
    string[] dialoguePagesGuard11 = new string[3];
    string[] dialoguePagesGuard12 = new string[2];
    string[] dialoguePagesGuard21 = new string[3];
    string[] dialoguePagesGuard22 = new string[3];
    string[] dialoguePagesGuard33 = new string[3];
    string[] dialoguePagesTraveller1 = new string[3];
    string[] dialoguePagesTraveller2 = new string[3];
    string[] dialoguePagesDuke1 = new string[5];
    string[] dialoguePagesDuke2 = new string[3];

    bool catFirst;
    bool guard1First;
    bool guard2First;
    bool travellerFirst;
    bool dukeFirst;

    public bool DialogoGamblerCatActive;
    public bool DialogoGuard1Active;
    public bool DialogoGuard2Active;
    public bool DialogoTravellerActive;
    public bool DialogoDuketActive;

    public TextMeshProUGUI speechCat;
    public TextMeshProUGUI speechGuard1;
    public TextMeshProUGUI speechGuard2;
    public TextMeshProUGUI speechTraveller;
    public TextMeshProUGUI speechDuke;

    public GameObject speechCatPanel;
    public GameObject speechGuard1Panel;
    public GameObject speechGuard2Panel;
    public GameObject speechTravellerPanel;
    public GameObject speechDukePanel;

    public int currentIndex;

    private bool spawned = false;
    private float decay;

    public enum personajeActual
    {
        cat,
        guard1,
        guard2,
        traveler,
        whiteDuke
    };

    void inicializarDialogos()
    {
        catFirst = true;
        guard1First = true;
        guard2First = true;
        travellerFirst = true;
        dukeFirst = true;

        dialoguePagesCat1[0] = "Welcome noble Dog to the last standing tavern in Minas Ratón. Few are the survivors and I am afraid that the situation in Bicho Land Royal City is not at its best.";
        dialoguePagesCat1[1] = "I'm afraid that food and rest cannot be provided, but please drink this beverage that will restore you anew. Feel free to come for more, it the least we can do for our heroes. Perhaps in next version we may charge you";
        dialoguePagesCat1[2] = "As you can see we are under siege. Minas Raton is a small town, the last post before Bicho Land Royal City and we handled an small but fructiferous mining operation";
        dialoguePagesCat1[3] = "But everything changed in the last week. The pink crystal mine, where we extract raw material for the Pink Dust, the main ingredient for opening magic portals in Bicho Land, started to crumble and some quakes were felt";
        dialoguePagesCat1[4] = "Then the horror. Monster of all kind started to emerge from the mines. The valiant guard of the White Duke fought gallantly but they were slew by the dark hordes";
        dialoguePagesCat1[5] = "Only a few invader creatures remain at Minas Ratón, most of them regrouped and marched to storm the Royal City, but many cratures remain and once the King fell, we will for sure have them here again";
        dialoguePagesCat1[6] = "I would recommend you to leave Kingdom of Bicho Land, but if you still want to reach de Royal City you may access the castle using an already open portal in the mine that leads to the Castle yards. In the Castle, look for the White Duke, he will be able to open a portal to the city outskirts. Good Luck!";
        dialoguePagesCat1[7] = "<END>";
        catFirst = true;
        Debug.Log(dialoguePagesCat1[0]);
               

        dialoguePagesCat2[0] = "Welcome back Noble Hero. Please feel free to drink on the house to restore your strenght after fighting the evil forces from the deep";
        dialoguePagesCat2[1] = "Godspeed!";
        dialoguePagesCat2[2] = "<END>";

        dialoguePagesGuard11[0] = "Hooray warrior Dog! All help is Welcome! Before the Castle doors were closed I saw the Duke himself fighting the monsters from the deep. He left his office to fight along the guard ";
        dialoguePagesGuard11[1] = "Hope you find him well and able to he you";
        dialoguePagesGuard11[2] = "<END>";
        dialoguePagesGuard12[0] = "Hurry up! If you want to reach the Royal City you must find the Duke!";
        dialoguePagesGuard12[1] = "<END>";

        dialoguePagesGuard21[0] = "The Duke himself led the defense, my platoon was trapped outside the Castle walls but the last thing I remember is seeing the White Duke imparting orders from the northern tower ";
        dialoguePagesGuard21[1] = "He is the bravest one in the kingdom";
        dialoguePagesGuard21[2] = "<END>";
        dialoguePagesGuard22[0] = "We are running out of time. Get to the Duke!";
        dialoguePagesGuard22[1] = "<END>";

        dialoguePagesTraveller1[0] = "I was leaving for Parrot Valley when the invasion started. Total Chaos and unspeakable monsters coming from te mountains. Many escaped but some of us were caugth before we were able to flee. We are waiting the final evacuation now fewer monsters are in the town. ";
        dialoguePagesTraveller1[1] = "Take care Wonder Warrior!";
        dialoguePagesTraveller1[2] = "<END>";
        dialoguePagesTraveller2[0] = "Take care in the mines, you may find major evils there!";
        dialoguePagesTraveller2[1] = "<END>";


        dialoguePagesDuke1[0] = "Your services will always be remembered valiant dog. I am afraid that time is at stake at this moment. I am leading the final but I think that all is lost here";
        dialoguePagesDuke1[1] = "The Rulers of all towns are regrouping whats left of their troops to secure refugees. We expect to have a fortified settlement ready by the end of next week. Only then we will be able to prepare a counter assault";
        dialoguePagesDuke1[2] = "If you are heading to Bicho Land Royal City you must use this portal. All roads are infested with thise invader vermin. If you are able to reach the Palace, tell the King and the Princess we will march to the Capital when ready";
        dialoguePagesDuke1[3] = "Thanks for your service. You are really a Wonder Dog. Now get to the portal before a new wave of monsters comes";
        dialoguePagesDuke1[4] = "<END>";
        dialoguePagesDuke2[0] = "Get into the portal Noble Dog! Hurry!";
        dialoguePagesDuke2[1] = "<END>";
    }
        
    public personajeActual personaje;

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



    public void DialogoGamblerCat()
    {
        Debug.Log("Dialogo Gambler Cat antes del set active, el panel esta:  " + speechCatPanel.activeSelf);
        speechCatPanel.SetActive(true);
        Debug.Log("Dialogo Gambler Cat, el pane esta: " + speechCatPanel.activeSelf);
        
        if (catFirst)
        {
            if (currentIndex == 0)
            {
                speechCat.text = dialoguePagesCat1[0];
            }


            if (dialoguePagesCat1[currentIndex + 1] != "<END>")
            {
                if (Input.GetKey(KeyCode.Return) && !spawned)
                {
                    currentIndex++;
                    decay = 1f;
                    spawned = true;
                    speechCat.text = dialoguePagesCat1[currentIndex];
                }
            }
            else
            {
                speechCatPanel.SetActive(false);
                DialogoGamblerCatActive = false;
                GameManager.unicaInstancia.vida = 1000;
                //catFirst = false;

            } 
        } else
        {
            if (currentIndex == 0)
            {
                speechCat.text = dialoguePagesCat2[0];
            }


            if (dialoguePagesCat2[currentIndex + 1] != "<END>")
            {
                if (Input.GetKey(KeyCode.Return) && !spawned)
                {
                    currentIndex++;
                    decay = 1f;
                    spawned = true;
                    speechCat.text = dialoguePagesCat2[currentIndex];
                }
            }
            else
            {
                DialogoGamblerCatActive = false;
                speechCatPanel.SetActive(false);
               


            }
        }
        
        
        
    }


    public void DialogoGuard1()
    {
        
        speechGuard1Panel.SetActive(true);
        

        if (guard1First)
        {
            if (currentIndex == 0)
            {
                speechGuard1.text = dialoguePagesGuard11[0];
            }


            if (dialoguePagesGuard11[currentIndex + 1] != "<END>")
            {
                if (Input.GetKey(KeyCode.Return) && !spawned)
                {
                    currentIndex++;
                    decay = 1f;
                    spawned = true;
                    speechGuard1.text = dialoguePagesGuard11[currentIndex];
                }
            }
            else
            {
                speechGuard1Panel.SetActive(false);
                DialogoGuard1Active = false;
                //catFirst = false;

            }
        }
        else
        {
            if (currentIndex == 0)
            {
                speechGuard1.text = dialoguePagesGuard12[0];
            }


            if (dialoguePagesGuard12[currentIndex + 1] != "<END>")
            {
                if (Input.GetKey(KeyCode.Return) && !spawned)
                {
                    currentIndex++;
                    decay = 1f;
                    spawned = true;
                    speechGuard1.text = dialoguePagesGuard12[currentIndex];
                }
            }
            else
            {
                DialogoGuard1Active = false;
                speechGuard1Panel.SetActive(false);



            }
        }



    }

    public void DialogoGuard2()
    {

        speechGuard2Panel.SetActive(true);


        if (guard2First)
        {
            if (currentIndex == 0)
            {
                speechGuard2.text = dialoguePagesGuard21[0];
            }


            if (dialoguePagesGuard21[currentIndex + 1] != "<END>")
            {
                if (Input.GetKey(KeyCode.Return) && !spawned)
                {
                    currentIndex++;
                    decay = 1f;
                    spawned = true;
                    speechGuard2.text = dialoguePagesGuard21[currentIndex];
                }
            }
            else
            {
                speechGuard2Panel.SetActive(false);
                DialogoGuard2Active = false;
                //catFirst = false;

            }
        }
        else
        {
            if (currentIndex == 0)
            {
                speechGuard2.text = dialoguePagesGuard22[0];
            }


            if (dialoguePagesGuard22[currentIndex + 1] != "<END>")
            {
                if (Input.GetKey(KeyCode.Return) && !spawned)
                {
                    currentIndex++;
                    decay = 1f;
                    spawned = true;
                    speechGuard1.text = dialoguePagesGuard22[currentIndex];
                }
            }
            else
            {
                DialogoGuard2Active = false;
                speechGuard2Panel.SetActive(false);



            }
        }



    }

    public void DialogoTraveller()
    {

        speechTravellerPanel.SetActive(true);
        


        if (travellerFirst)
        {
            if (currentIndex == 0)
            {
                speechTraveller.text = dialoguePagesTraveller1[0];
            }


            if (dialoguePagesTraveller1[currentIndex + 1] != "<END>")
            {
                if (Input.GetKey(KeyCode.Return) && !spawned)
                {
                    currentIndex++;
                    decay = 1f;
                    spawned = true;
                    speechTraveller.text = dialoguePagesTraveller1[currentIndex];
                }
            }
            else
            {
                speechTravellerPanel.SetActive(false);
                DialogoGuard2Active = false;
                //catFirst = false;

            }
        }
        else
        {
            if (currentIndex == 0)
            {
                speechTraveller.text = dialoguePagesTraveller2[0];
            }


            if (dialoguePagesTraveller2[currentIndex + 1] != "<END>")
            {
                if (Input.GetKey(KeyCode.Return) && !spawned)
                {
                    currentIndex++;
                    decay = 1f;
                    spawned = true;
                    speechTraveller.text = dialoguePagesTraveller2[currentIndex];
                }
            }
            else
            {
                DialogoTravellerActive = false;
                speechTravellerPanel.SetActive(false);



            }
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
                DialogoGuard2Active = false;
                //catFirst = false;

            }
        }
        else
        {
            if (currentIndex == 0)
            {
                speechDuke.text = dialoguePagesDuke2[0];
            }


            if (dialoguePagesDuke2[currentIndex + 1] != "<END>")
            {
                if (Input.GetKey(KeyCode.Return) && !spawned)
                {
                    currentIndex++;
                    decay = 1f;
                    spawned = true;
                    speechDuke.text = dialoguePagesTraveller2[currentIndex];
                }
            }
            else
            {
                DialogoTravellerActive = false;
                speechDukePanel.SetActive(false);



            }
        }



    }

    public void MostrarCanvas(string personaje)
    {

        switch (personaje)
        {
            case string per when per == "cat":
                break;
            case string per when per == "guard1":
                break;
            case string per when per == "guard2":
                break;
            case string per when per == "traveller":
                break;
            case string per when per == "duke":
                break;

            default:
                
                break;

        }

    }

    // Start is called before the first frame update

    private void Awake()
    {
        inicializarDialogos();
        DialogoGamblerCatActive = false;
        speechCatPanel.SetActive(false);
        Debug.Log("Cat Pane Start is: " + speechCatPanel.activeSelf);
        speechGuard1Panel.SetActive(false);
        speechGuard2Panel.SetActive(false);
        speechTravellerPanel.SetActive(false);
        speechDukePanel.SetActive(false);
        currentIndex = 0;
        
    }

    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogoGamblerCatActive) {
            Reset();
            DialogoGamblerCat(); 

        } else
        {
            speechCatPanel.SetActive(false);
        }
        if (DialogoGuard1Active)
        {
            Reset();
            DialogoGuard1();
        } else
        {
            speechGuard1Panel.SetActive(false);
        }
        
        if (DialogoGuard2Active)
        {
            Reset();
            DialogoGuard2();
        } else
        {
            speechGuard2Panel.SetActive(false);
        }
        if (DialogoTravellerActive)
        {
            Reset();
            DialogoTraveller();
        } else
        {
            speechTravellerPanel.SetActive(false);
        }

        if (DialogoDuketActive)
        {
            Reset();
            DialogoDuke();
        } else
        {
            speechDukePanel.SetActive(false); 
        }
    }
}
