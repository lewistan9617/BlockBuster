using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float moveSpeed;
    public int health;
    public Transform targetTransform;
   // public Cube floor;
    private Animator bossAnim;
    
    //public Player player;
    public void Initialize(Transform target, float moveSpeed, int health)
    {
        this.targetTransform = target;
        this.moveSpeed = moveSpeed;
        this.health = health;
    }
    // Start is called before the first frame update
    void Start()
    {

        //Physics.IgnoreCollision(GetComponent<Collider>(),);
        bossAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (targetTransform != null )
        {

            this.transform.position = Vector3.MoveTowards(this.transform.position, targetTransform.transform.position, Time.deltaTime * moveSpeed);
            this.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        }
        if (Vector3.Distance(this.transform.position,GameObject.FindGameObjectWithTag("Player").transform.position)<4)
        {
            bossAnim.SetTrigger("isNear");
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    /*public void Attack(Player player)
    {
        player.health -= this.damage;
        //Destroy(this.gameObject);
    }*/
}
