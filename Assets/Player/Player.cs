using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public int health = 100;
    public event Action<Player> onPlayerDeath;
    public GetTime time;
    public GameObject die;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void collidedWithEnemy(Enemy enemy)
    {
        enemy.Attack(this);
        if (health <= 0)
        {
            Time.timeScale = 0;
            string temp;
            temp = "您坚持了 ";
            temp += time.text_timeSpend.text;
            //onPlayerDeath(this);
            //UnityEditor.EditorUtility.DisplayDialog("游戏结束",temp , "确认");
            die.SetActive(true);

            //Time.timeScale = 1;
            
            //jump();
            
        }
    }
    void collidedWithEnemy(BossWeapon bossweapon)
    {
        bossweapon.Attack(this);
        if (health <= 0)
        {
            Time.timeScale = 0;
            string temp;
            temp = "您坚持了 ";
            temp += time.text_timeSpend.text;
            //onPlayerDeath(this);
            //UnityEditor.EditorUtility.DisplayDialog("游戏结束", temp, "确认");
            die.SetActive(true);
            //Time.timeScale = 1;

            //jump();

        }
    }
    public void jump()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }

    void OnCollisionEnter(Collision col)
    {
        Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            collidedWithEnemy(enemy);
        }
        BossWeapon bossweapon = col.collider.gameObject.GetComponent<BossWeapon>();
        if (bossweapon)
            collidedWithEnemy(bossweapon);

    }
}
