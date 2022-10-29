using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShop : ShopManager
{
    // Start is called before the first frame update
    protected override void Start()
    {
        titleText = "Test Shop (get your stuff here))";
        base.Start();
        items = new string[] {"Basic Tree", "Sakurai Tree", "Mango Tree"}; // redefining items here for later use
        costs = new int[] {10, 20, 35};
        helperPaths = new string[] {"Helpers/HelperTest", "Helpers/BuilderTest"};
        helperCosts = new int[] {100, 200};
    }

    public override void Buy(int i) {
        //Debug.Log("Bought " + items[i] + " for $" + costs[i] + "!");

        if (costs[i] <= gm.money) {
            Debug.Log($"Bought {items[i]} for ${costs[i]}!");
            gm.money -= costs[i];

            gm.currentPlants[i] += 2;
        } else {
            Debug.Log($"Not enough money to buy {items[i]}!");
        }

    }

    public override void Summon(int i)
    {
        
        if (helperCosts[i] <= gm.money) {

            Debug.Log($"Bought helper for {helperCosts[i]}!");
            GameObject helper = GameObject.Instantiate(Resources.Load<GameObject>(helperPaths[i]));

        } else {
            Debug.Log("not enough money stupid");
        }

    }


}
