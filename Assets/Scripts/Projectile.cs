using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage;

    Vector3 shootDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Translate(shootDirection * speed, Space.World);
    }

    // 2
    public void FireProjectile(Ray shootRay)
    {
        this.shootDirection = shootRay.direction;
        this.transform.position = shootRay.origin;
        rotateInShootDirection();
    }

    // 3
    void OnCollisionEnter(Collision col)
    {
        Destroy(this.gameObject);
        Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();
        Player player = col.collider.gameObject.GetComponent<Player>();
        Boss boss = col.collider.gameObject.GetComponent<Boss>();
        Target target = col.collider.gameObject.GetComponent<Target>();
        if (enemy)
        {
            enemy.TakeDamage(damage);
            
        }
        if (boss)
            boss.TakeDamage(damage);
        if (target)
            target.TakeDamage(damage);



    }
    void rotateInShootDirection()
    {
        Vector3 newRotation = Vector3.RotateTowards(transform.forward, shootDirection, 0.01f, 0.0f);
        transform.rotation = Quaternion.LookRotation(newRotation);
    }
}
