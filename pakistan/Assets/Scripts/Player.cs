using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{

    public override void Start()
    {
        base.Start();
        
    }

    public override void Update()
    {
        base.Update();
        PlaceInfastructure();
    }


    void PlaceInfastructure() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject infastructure = Object.Instantiate(Resources.Load<GameObject>("Infrastructure/InfastructureTest"));
            infastructure.transform.position = transform.position;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt)) {
            GameObject plant = Object.Instantiate(Resources.Load<GameObject>("Infrastructure/PlantTest"));
            plant.transform.position = transform.position;
        }
        
    }

}
