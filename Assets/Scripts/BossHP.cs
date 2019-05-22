using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    private Boss boss;
    public UnityEngine.UI.Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        boss = gameObject.GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = boss.health;
    }
}
