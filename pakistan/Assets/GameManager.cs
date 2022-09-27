using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{


    [SerializeField] TMP_Text UI;

    int infastructureFixed = 0;
    int sectionsFixed = 0;

    [SerializeField] public int money = 0; // keeps track of money

    List<Actor> currentCharacters; // contains all actors (players and helpers)

    [SerializeField] public int[] currentResources;

    [SerializeField] public int[] currentPlants;

    Camera camera;

    #region ResourceGuy

    public int resourceTimeToRecharge = 20 * 60;
    public int resourceTimeTaken = 20 * 60;


    #endregion

    // Start is called before the first frame update
    void Start()
    {

        currentResources = new int[] {
            50, //bricks
            60 // concrete
        };

        currentPlants = new int[] {
            5, // basic trees
            3, // sakurai trees
            2 // mango trees
        };


        camera = FindObjectOfType<Camera>();    

        foreach (Actor actor in FindObjectsOfType<Actor>())
        {
           // currentCharacters.Add(actor);
        }
        //print(currentCharacters);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
        UpdateResourceGuy();
    }

    void UpdateUI() {

        UI.text = "Gold: " + money + "\nResources:\n- Bricks: " + currentResources[0] + "\n- Concrete: " + currentResources[1]
            + "\nPlants:\n- Basic Trees: " + currentPlants[0] + "\n- Sakurai Trees: " + currentPlants[1] + "\n- Mango Trees: " + currentPlants[2];

    }

    void UpdateResourceGuy() {

        resourceTimeTaken += 1;
        

    }

}
