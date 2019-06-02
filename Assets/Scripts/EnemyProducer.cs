using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyProducer : MonoBehaviour
{
    public bool shouldSpawn;
    public Enemy[] enemyPrefabs;
    public float[] moveSpeedRange;
    // public int[] healthRange;
    public int enemyhp;
    public float spawntime;
    public bool isCrazy;
    public float crazyperiod;//which time to reduce the spawntime


    private Bounds spawnArea;
    private GameObject player;
    private float timespend;
    private int periodtimes;
    private int crazyreducing;//reducing timeS

    // Start is called before the first frame update
    void Start()
    {
        timespend = 0.0f;
        periodtimes = 0;
        crazyreducing = 0;
        spawnArea = this.GetComponent<BoxCollider>().bounds;
        SpawnEnemies(shouldSpawn);
        //InvokeRepeating("spawnEnemy", 1.0f, spawntime);
        //if (isCrazy)
        //    InvokeRepeating("Crazymode", 1.0f, spawntime);
    }
    /*void Crazymode()
    {
        if (spawntime>0.2f)
        spawntime -= 0.1f;
    }*/
    private void FixedUpdate()
    {
        timespend += Time.deltaTime;
        if (isCrazy)
        {
            if (spawntime>0.3f&&timespend/crazyperiod-crazyreducing>-0.01f)
            {
                spawntime -= 0.1f;
                crazyreducing++;
            }//time to reduce period
        }
        if (timespend / spawntime - periodtimes > -0.01f)
        {
            spawnEnemy();
            periodtimes++;
        }
    }
    Vector3 randomSpawnPosition()
    {
        Vector3 temp = new Vector3();
        temp = player.transform.position;
        while (Vector3.Distance(temp, player.transform.position) < 5)
        {
            temp.x = Random.Range(spawnArea.min.x, spawnArea.max.x);
            temp.z = Random.Range(spawnArea.min.z, spawnArea.max.z);
            temp.y = 0;
        }
        return temp;
    }

    void spawnEnemy()
    {
        if (shouldSpawn == false || player == null)
        {
            return;
        }

        int index = Random.Range(0, enemyPrefabs.Length);
        var newEnemy = Instantiate(enemyPrefabs[index], randomSpawnPosition(), Quaternion.identity) as Enemy;
        newEnemy.Initialize(player.transform,
            Random.Range(moveSpeedRange[0], moveSpeedRange[1]),
            enemyhp);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnEnemies(bool shouldSpawn)
    {
        if (shouldSpawn)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        this.shouldSpawn = shouldSpawn;
    }


}
