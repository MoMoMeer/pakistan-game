using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BGManager : MonoBehaviour
{

    List<Infrastructure> buildings;
    List<Plant> plants;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddBuilding(Infrastructure building) {

        //buildings.Add(building);
        GameObject bgBuilding = new GameObject();
        bgBuilding.transform.SetParent(gameObject.transform);
        
        bgBuilding.transform.localPosition = new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), .65f);
        bgBuilding.AddComponent<SpriteRenderer>();

        bgBuilding.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;
        bgBuilding.GetComponent<SpriteRenderer>().sortingOrder = UnityEngine.Random.Range(-3, -1);

    }
    public void AddPlant(Plant plant) {
       // plants.Add(plant);
        GameObject bgPlant = new GameObject();
        bgPlant.transform.SetParent(gameObject.transform);
        
        bgPlant.transform.localPosition = new Vector3(UnityEngine.Random.Range(-0.5f, 0.55f), .65f);
        bgPlant.AddComponent<SpriteRenderer>();

        bgPlant.GetComponent<SpriteRenderer>().sprite = plant.GetComponent<SpriteRenderer>().sprite;
        bgPlant.GetComponent<SpriteRenderer>().sortingOrder = UnityEngine.Random.Range(-5, -1);

    }

    void LoadStuff() {

    }

}
