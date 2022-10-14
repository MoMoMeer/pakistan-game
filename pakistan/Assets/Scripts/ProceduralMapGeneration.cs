using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMapGeneration : MonoBehaviour
{

    public GameObject groundPrefab;
    public GameObject infrastructure;
    public GameObject deadPlant;
    public GameObject bridge;
    public Transform player;

    private float nextRightSideLandSectionPos;
    private float nextLeftSideLandSectionPos;

    void Start()
    {
        GenerateLandSection();
        GenerateLandSection("right");
        GenerateLandSection("left");
    }

    // Update is called once per frame
    void Update()
    {

    }

    //checks for any parts of the map that are close to the player but do not yet have generated land.
    void CheckForUngeneratedLand()
    {

    }

    //generates a new land section, side parameter is for which side of the map(right/left) the new section should be added to
    //the parameter defaults to middle to generate the first section of land
    void GenerateLandSection(string side = "middle")
    {
        float newLandSectionXPos;
        if (side == "middle")
        {
            GameObject newLandSection = Instantiate(groundPrefab, new Vector2(0, -4.5f), Quaternion.identity);
            newLandSectionXPos = newLandSection.transform.position.x;

            nextRightSideLandSectionPos = groundPrefab.transform.position.x + groundPrefab.transform.localScale.x;
            nextLeftSideLandSectionPos = groundPrefab.transform.position.x - groundPrefab.transform.localScale.x;
        }
    }

    //generating stuff on top of the ground
    void GenerateOverLand(float landPos, GameObject obj)
    {
        float placementStartPos = (landPos - groundPrefab.transform.localScale.x / 2) + obj.transform.localScale.x / 2;
        float placementEndPos = (landPos + groundPrefab.transform.localScale.x / 2) - obj.transform.localScale.x / 2;
        float currentPos = placementStartPos;

        while (placementEndPos > currentPos)
        {
            if (Random.Range(1, 4) == 2)
            {
                GameObject newObj = Instantiate(obj, new Vector2(currentPos, (-4.5f + groundPrefab.transform.localScale.y / 2)), Quaternion.identity);
                currentPos += 1 + (newObj.transform.localScale.x / 2);
            }
            else
            {
                currentPos += 1;
            }
        }
    }
}