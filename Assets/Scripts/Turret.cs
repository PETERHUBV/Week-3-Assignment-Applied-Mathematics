using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Transform player;
    private GameObject bullet;

    public float range = 8f;
    public float fireCooldown = 2f;

    private float lastFireTime = -Mathf.Infinity;

    void Start()
    {
        
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        
        bullet = GameObject.Find("Bullet");
        if (bullet != null)
            bullet.SetActive(false); 
    }

    void Update()
    {
        if (player == null || bullet == null)
            return;

        Vector2 toPlayer = player.position - transform.position;
        float distance = toPlayer.magnitude;

 
        float angle = Mathf.Atan2(toPlayer.y, toPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

      
        if (distance <= range && Time.time >= lastFireTime + fireCooldown)
        {
            Fire();
            lastFireTime = Time.time;
        }
    }

    void Fire()
    {
        bullet.SetActive(true);
        bullet.transform.position = transform.position; 
        bullet.transform.rotation = transform.rotation;

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDirection(transform.right); 
        }
    }
}