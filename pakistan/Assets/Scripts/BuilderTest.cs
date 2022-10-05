using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderTest : Actor
{

    [SerializeField] Vector3 randomPos;
    Vector3 startPos;
    bool isGoing = false;

    [SerializeField] int maxcooldown = 5 * 30;
    int currentcooldown = 0;

    [SerializeField] int buildingType;

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

            buildingType = Random.Range(0, 3); // the 3 trees

        }
        if (isGoing && currentcooldown <= 0) {
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

                GameObject building = GameObject.Instantiate(Resources.Load<GameObject>("Infrastructure/InfastructureTest"));
                building.transform.position = new Vector3(randomPos.x, 1);
                isGoing = false;
                currentcooldown = maxcooldown;
            }
        }

        currentcooldown--;
    }
}
