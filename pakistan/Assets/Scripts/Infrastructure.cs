using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infrastructure : MonoBehaviour
{
    
    [SerializeField] int timeToBuild = 5 * 60;
    [SerializeField] int timeTaken = 0;
    [SerializeField] public bool built= false;

    SpriteRenderer sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        // modify alpha until it's built
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 125f/255f); 

    }

    // Update is called once per frame
    void Update()
    {
        ManageTime();
    }

    void OnTriggerStay2D(Collider2D c) {

        /*if (c.name == "Player" && Input.GetKeyDown(KeyCode.Z))  {
            if (built) {

                FindObjectOfType<GameManager>().money += 100;
                FindObjectOfType<BGManager>().AddBuilding(gameObject.GetComponent<Infrastructure>());
                Destroy(this.gameObject);

            }
        }*/

    }

    void ManageTime() {

        if (built) return;
        timeTaken += 1;

        if (timeTaken >= timeToBuild) {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f); 
            built = true;
        }

    }
}
