using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ShopManager : MonoBehaviour
{

    [SerializeField] protected string[] items = {"Undefined Item"};
    [SerializeField] protected int[] costs = {0};
    protected GameManager gm;
    protected string titleText = "Nameless Shop (error in code)";
    [SerializeField] TMP_Text title;

    protected string[] helperPaths = {};
    protected int[] helperCosts = {};

    // Start is called before the first frame update
    protected virtual void Start()
    {
       gm = FindObjectOfType<GameManager>(); 
       
       title.text = titleText;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual void Buy(int i) {

        Debug.LogWarning("This is the base class, which means that the items aren't defined here.");

        //Debug.Log("bought " + items[i]);
        
    }

    public virtual void Summon(int i) {
        Debug.LogWarning("Summoning people not defined, don't use base class");
    }

    public virtual void Close() {
        gameObject.SetActive(false);
    }
}
