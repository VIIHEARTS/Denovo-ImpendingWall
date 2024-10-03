using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCtrls : MonoBehaviour
{


    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;
    public bool hasMoved;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.linearVelocity = new Vector2(speedX, speedY);
        
        Vector2 playerPos = GameObject.Find("Player").transform.position;

        if (playerPos.x > 0f)
        {
            hasMoved = true;
        }
        else
        {
            hasMoved = false;
        }

    }
}
