using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int infastructureFixed = 0;
    int sectionsFixed = 0;

    [SerializeField] int money = 0; // keeps track of money

    List<Actor> currentCharacters; // contains all actors (players and helpers)

    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = FindObjectOfType<Camera>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
