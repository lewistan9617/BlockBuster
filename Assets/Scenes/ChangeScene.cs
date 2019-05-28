
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {


    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void LoadEasy()
    {
        SceneManager.LoadScene("Easy");
    }
    public void LoadNormal()
    {
        SceneManager.LoadScene("Normal");
    }
    public void LoadHard()
    {
        SceneManager.LoadScene("Hard");
    }
    public void LoadCrazy()
    {
        SceneManager.LoadScene("Crazy");
    }
    // Update is called once per frame
    void Update()
    {
    }


}