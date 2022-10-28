using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Actor
{
    
    GameManager gm;
    

    public override void Start()
    {
        base.Start();
        gm = FindObjectOfType<GameManager>();
    }

    public override void Update()
    {
        base.Update();
        PlaceInfastructure();
    }


    void OnTriggerStay2D(Collider2D collider) {
        //print("lol");
        if (Input.GetKeyDown(KeyCode.E)) {
            if (collider.name.Contains("Tree") && collider.GetComponent<Plant>().done) {

                GameObject.Destroy(collider.gameObject);
                FindObjectOfType<BGManager>().AddPlant(collider.GetComponent<Plant>());
                gm.money += 50;

            }

            if (collider.name.Contains("Inf") && collider.GetComponent<Infrastructure>().built) {

                gm.money += 100;
                FindObjectOfType<BGManager>().AddBuilding(collider.GetComponent<Infrastructure>());
                Destroy(collider.gameObject);

            }
        

            if (collider.name.Contains("AGK")) {

                if (gm.resourceTimeTaken >= gm.resourceTimeToRecharge) {
                    gm.resourceTimeTaken -= gm.resourceTimeToRecharge;

                    gm.currentResources[0] += 20; gm.currentResources[1] += 10;

                } else {

                    GameObject.Find("ResourceGuyText").GetComponent<TMP_Text>().text = "You gotta wait a bit for resources!";

                }

            }

            if (collider.name.Contains("Shopkeeper")) {
                //gm.money -= 100;
                //gm.currentPlants[0] += 15; gm.currentPlants[1] += 10; gm.currentPlants[2] += 5;
                //GameObject.Find("ShopkeeperText").GetComponent<TMP_Text>().text = "You bought plants for 100g!";
               
                // This is just place holder code since there's a better way to implement
                //GameObject.Find("Shopkeeping").SetActive(true);
                //Debug.Log(GameObject.Find("littlemac"));
                GameObject canvas = GameObject.Find("Canvas");
                canvas.transform.Find("ShopKeeping").gameObject.SetActive(true);

            }

        }


    }

    void PlaceInfastructure() {
        if (Input.GetKeyDown(KeyCode.Space) && (gm.currentResources[0] > 5 && gm.currentResources[1] > 5)) {

            gm.currentResources[0] -= 5; gm.currentResources[1] -= 5;
            GameObject infastructure = Object.Instantiate(Resources.Load<GameObject>("Infrastructure/InfastructureTest"));
            infastructure.transform.position = transform.position;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt)) {
            if (gm.currentPlants[0] > 0) {
                gm.currentPlants[0]--;
                GameObject plant = Object.Instantiate(Resources.Load<GameObject>("Infrastructure/Plants/BasicTree"));
                plant.transform.position = new Vector3(transform.position.x, -0.4f);;
                return;
            }
            if (gm.currentPlants[1] > 0) {
                gm.currentPlants[1]--;
                GameObject plant = Object.Instantiate(Resources.Load<GameObject>("Infrastructure/Plants/SakuraiTree"));
                plant.transform.position = new Vector3(transform.position.x, -0.4f);
                return;
            }
            if (gm.currentPlants[2] > 0) {
                gm.currentPlants[2]--;
                GameObject plant = Object.Instantiate(Resources.Load<GameObject>("Infrastructure/Plants/MangoTree"));
                plant.transform.position = new Vector3(transform.position.x, -0.4f);;
                return;
            }
        }
        
    }

}
