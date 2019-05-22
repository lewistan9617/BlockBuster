using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{

    public int damage;


    //public Player player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }



    public void Attack(Player player)
    {
        player.health -= this.damage;
        //Destroy(this.gameObject);
    }
}
