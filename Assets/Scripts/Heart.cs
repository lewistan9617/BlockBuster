using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
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
            player.health += 10;
            Destroy(this.gameObject);

        }




    }
}
