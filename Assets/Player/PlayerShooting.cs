using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Projectile projectilePrefab;
    public Projectile projectilePrefab2;
    public Projectile projectilePrefab3;
    public Player player;
    public LayerMask mask;
    public bool isCrazy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void raycastOnMouseClick()
    {
        RaycastHit hit;
        Ray rayToFloor = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(rayToFloor.origin, rayToFloor.direction * 100.1f, Color.red, 2);

        if (Physics.Raycast(rayToFloor, out hit, 100.0f, mask, QueryTriggerInteraction.Collide))
        {
            
            shoot(hit);
        }
    }

    // 2
    void Update()
    {
        bool mouseButtonDown = Input.GetMouseButtonDown(0);
        if (mouseButtonDown)
        {
            raycastOnMouseClick();
        }
    }
    void shoot(RaycastHit hit)
    {
        // 1
        var projectile = Instantiate(projectilePrefab).GetComponent<Projectile>();



        
        // 2
        var pointAboveFloor = hit.point + new Vector3(0, this.transform.position.y, 0);

        // 3
        var direction = pointAboveFloor - transform.position;
        transform.LookAt(direction+this.transform.position);
        Vector3 temp = new Vector3(0, 1, 0);

        // 4
        var shootRay = new Ray(this.transform.position, direction);
        if (isCrazy)
        {
            var projectile2 = Instantiate(projectilePrefab2).GetComponent<Projectile>();
            var projectile3 = Instantiate(projectilePrefab3).GetComponent<Projectile>();
            var shootRay2 = new Ray(this.transform.position, direction + Vector3.Cross(temp, direction));
            var shootRay3 = new Ray(this.transform.position, direction - Vector3.Cross(temp, direction));
            Debug.DrawRay(shootRay2.origin, shootRay2.direction * 100.1f, Color.green, 2);
            Debug.DrawRay(shootRay3.origin, shootRay3.direction * 100.1f, Color.green, 2);
            Physics.IgnoreCollision(GetComponent<Collider>(), projectile2.GetComponent<Collider>());
            Physics.IgnoreCollision(GetComponent<Collider>(), projectile3.GetComponent<Collider>());
            Physics.IgnoreCollision(player.GetComponent<Collider>(), projectile2.GetComponent<Collider>());
            Physics.IgnoreCollision(player.GetComponent<Collider>(), projectile3.GetComponent<Collider>());
            projectile2.FireProjectile(shootRay2);
            projectile3.FireProjectile(shootRay3);
        }
        
        Debug.DrawRay(shootRay.origin, shootRay.direction * 100.1f, Color.green, 2);
        

        // 5
        Physics.IgnoreCollision(GetComponent<Collider>(), projectile.GetComponent<Collider>());
        
        Physics.IgnoreCollision(player.GetComponent<Collider>(), projectile.GetComponent<Collider>());
        


        // 6
        projectile.FireProjectile(shootRay);
        
    }

}
