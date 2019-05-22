using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHP : MonoBehaviour
{
    public Enemy enemy;
    public Slider slider;
   // int maxhealth;
    // Start is called before the first frame update
    void Start()
    {
        //maxhealth = enemy.health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = enemy.health;
    }
}
