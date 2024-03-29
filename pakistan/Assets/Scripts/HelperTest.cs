using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperTest : Actor
{

    [SerializeField] Vector3 randomPos;
    Vector3 startPos;
    bool isGoing = false;

    [SerializeField] int plantType;

    Transform ground;

    public override void Start()
    {
        base.Start();
        ground = GameObject.Find("Ground").transform;
        speed = 8f;
    }

    public override void Update()
    {
        // base.Update(); has the player movement stuff you dont want that

        if (!isGoing) {

            randomPos = new Vector3(Random.Range(-35f, 35f), -0.26f);
            startPos = transform.position;

            isGoing = true;

            plantType = Random.Range(0, 3); // the 3 trees

        }
        if (isGoing) {
            //Debug.Log(1 - Mathf.Abs(transform.position.x - randomPos.x)/speed);
            //Vector2.Lerp(startPos, randomPos, 1 - Mathf.Abs(transform.position.x - randomPos.x)/speed);

            if (transform.position.x > randomPos.x) {

                transform.position += new Vector3(-speed * Time.deltaTime, 0);

            }
            if (transform.position.x < randomPos.x) {

                transform.position += new Vector3((speed * Time.deltaTime), 0);

            }

            //if (transform.position.x + (speed * Time.deltaTime) < randomPos.x  || transform.position.x - (speed * Time.deltaTime) > randomPos.x) {
             //   transform.position = randomPos;
           // }

            if (Mathf.Abs(transform.position.x - randomPos.x) <= 0.5f) {//(transform.position.x == randomPos.x) {

                GameObject plant;
                switch (plantType)
                {
                    case ((int)Plant.PlantType.BASIC_TREE):
                        plant = Object.Instantiate(Resources.Load<GameObject>("Infrastructure/Plants/BasicTree"));
                        break;
                    case ((int) Plant.PlantType.SAKURAI_TREE):
                    plant = Object.Instantiate(Resources.Load<GameObject>("Infrastructure/Plants/SakuraiTree"));
                        break;
                    case ((int) Plant.PlantType.MANGO_TREE):
                        plant = Object.Instantiate(Resources.Load<GameObject>("Infrastructure/Plants/MangoTree"));
                        break;
                    default:
                        plant = Object.Instantiate(Resources.Load<GameObject>("Infrastructure/Plants/SakuraiTree"));
                        break;
                }


                
                plant.transform.position = randomPos;

                isGoing = false;
            }
        }
    }
}
