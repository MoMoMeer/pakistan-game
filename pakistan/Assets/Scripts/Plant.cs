using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

    [SerializeField] float maxScale = 1.5f;
    [SerializeField] float currentScale = 1f;
    [SerializeField] float speed = 0.05f;
    [SerializeField] bool done = false;

    SpriteRenderer sprite;

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
        }
    }

    void Grow() {

        if (transform.localScale.x > maxScale) {done = true; return;}

        transform.localScale = new Vector2(transform.localScale.x + speed * Time.deltaTime, transform.localScale.y + speed * Time.deltaTime);

    }



}
