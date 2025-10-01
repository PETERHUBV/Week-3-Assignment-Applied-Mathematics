using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MoveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");


        Vector2 movedirection = new Vector2(MoveX, MoveY).normalized;
        transform.Translate(movedirection * speed * Time.deltaTime);
    }
}
