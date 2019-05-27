using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossProducer : MonoBehaviour
{
    public bool shouldSpawn;
    public Boss[] enemyPrefabs;
    public float[] moveSpeedRange;
    // public int[] healthRange;
    public int enemyhp;
    public float spawntime;
    public float starttime;



    private Bounds spawnArea;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(shouldSpawn);
        InvokeRepeating("spawnEnemy", starttime , spawntime);

    }

    private void FixedUpdate()
    {

    }
    Vector3 randomSpawnPosition()
    {
        float x = Random.Range(spawnArea.min.x, spawnArea.max.x);
        float z = Random.Range(spawnArea.min.z, spawnArea.max.z);
        float y = 1.0f;

        return new Vector3(x, y, z);
    }

    void spawnEnemy()
    {
        if (shouldSpawn == false || player == null)
        {
            return;
        }

        int index = Random.Range(0, enemyPrefabs.Length);
        var newEnemy = Instantiate(enemyPrefabs[index], randomSpawnPosition(), Quaternion.identity) as Boss;
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
