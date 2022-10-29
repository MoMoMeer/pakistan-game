using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

    [SerializeField] float maxScale = 1.5f;
    [SerializeField] float currentScale = 1f;
    [SerializeField] float speed = 0.05f;
    [SerializeField] public bool done = false;
    

    SpriteRenderer sprite;

    public enum PlantType {

        BASIC_TREE,
        SAKURAI_TREE,
        MANGO_TREE

    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Grow();
        if (done) {
            sprite.color = Color.white;
            if (!GetComponent<ParticleSystem>().isPlaying) {
                GetComponent<ParticleSystem>().Play();
            }
        }
    }

    void Grow() {

        if (transform.localScale.x > maxScale) {done = true; return;}
        transform.localPosition += new Vector3(0, speed/2 * Time.deltaTime);
        transform.localScale = new Vector2(transform.localScale.x + speed * Time.deltaTime, transform.localScale.y + speed * Time.deltaTime);

    }



}
