using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerCtrls : MonoBehaviour
{
    private float movSpeed = 5f;
    float speedX, speedY;
    private Vector2 moveInput;
    Rigidbody2D rb;
    public bool hasMoved;
    public GameObject phaseWall;


    private float currentSpeed;
    public float dashSpeed;
    public float dashDistance = 5f, dashCooldown = 1f;
    private float dashCounter;
    public bool hasDashed;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = movSpeed;
        hasDashed = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        rb.linearVelocity = moveInput * currentSpeed;
        
        Vector2 playerPos = GameObject.Find("Player").transform.position;
        hasMoved = playerPos != Vector2.zero;

        if (Input.GetButtonDown("Fire1"))            
        {
            if (dashCounter <= 0)
            {
                currentSpeed = dashSpeed;
                dashCounter = dashDistance;
                
            }
            hasDashed = true;

        }
        else if (Input.GetButtonUp("Fire1"))
        {
            hasDashed = false;
        }



        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if(dashCounter <= 0)
            {
                currentSpeed = movSpeed;
            }
        }

        if (hasDashed)
        {
            phaseWall.gameObject.SetActive(false);
        }
        else
        {
            phaseWall.gameObject.SetActive(true);
        }
    }
}
