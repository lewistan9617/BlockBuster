using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {


        Player player = col.collider.gameObject.GetComponent<Player>();

        if (player)
        {
            PlayerShooting playerShooting;
            playerShooting=player.GetComponent<PlayerShooting>();

            playerShooting.upgrade = true;


            Destroy(this.gameObject);

        }
    }

}
