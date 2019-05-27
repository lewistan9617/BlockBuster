using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DietimeText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("CameraRig/Main Camera/Canvas/Button/Die").GetComponent<Text>().text =
            GameObject.Find("CameraRig/Main Camera/Canvas/Text").GetComponent<Text>().text;
    }
}
