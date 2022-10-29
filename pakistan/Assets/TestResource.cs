using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestResource : ShopManager
{

    Player player;
    [SerializeField] int moneyForSpeed = 400;

    protected override void Start() {
        titleText = "Resource Shop (get bricks and boxers with bricks for fists)";
        base.Start();
        items = new string[] {"Concrete", "Brick", "Bubsedian"};
        costs = new int[] {30, 15, 100};
        helperPaths = new string[] {"Helpers/LittleMac"};
        helperCosts = new int[] {500};
    }

    // Start is called before the first frame update
    public override void Buy(int i)
    {
        if (costs[i] <= gm.money) {
            Debug.Log($"Bought {items[i]} for ${costs[i]}!");
            gm.money -= costs[i];

            gm.currentResources[i] += 10;
        } else {
            Debug.Log($"Not enough money to buy {items[i]}!");
        }
    }

    public override void Summon(int i)
    {
        if (helperCosts[i] <= gm.money) {
            GameObject helper = GameObject.Instantiate(Resources.Load<GameObject>(helperPaths[i]));
        }
    }

    public void SpeedChange() {
        if (moneyForSpeed<=gm.money) {

            gm.money -= moneyForSpeed;
            player = FindObjectOfType<Player>();
            player.speed += 3f;

        }
    }

}
