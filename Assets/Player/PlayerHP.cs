using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;


    public Slider slider;



    private void Start()
    {

    }
    private void Update()
    {
        slider.value = player.health;

  
    }

}