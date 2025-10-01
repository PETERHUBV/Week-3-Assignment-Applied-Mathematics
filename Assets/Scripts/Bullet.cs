using UnityEngine;
using UnityEngine.SceneManagement;
public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 5f;
    public float Lifetime = 5f;
    public float hitDistance = 0.5f;

    private Vector2 moveDirection;
    private float timer;
   public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction.normalized;
        timer = 0f;
    }

    void Update()
    {
        transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);
        timer += Time.deltaTime;

        if (timer >= Lifetime)
        {
            gameObject.SetActive(false);
            return;
        }

        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= hitDistance)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}