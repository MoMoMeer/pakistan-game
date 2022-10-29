using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{

    // variables
    [SerializeField] public float speed = 6f;
    protected Animator animator;



    // Start is called before the first frame update
    public virtual void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Movement();
    }


    public virtual void Movement() {

        if (Input.GetKey(KeyCode.D)) {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
    }

}
