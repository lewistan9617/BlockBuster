using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHP : MonoBehaviour
{
    public int health;
    public Slider slider;
    private Target target;
    // Start is called before the first frame update
    void Start()
    {
        target = gameObject.GetComponent<Target>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = target.health;
    }
}
