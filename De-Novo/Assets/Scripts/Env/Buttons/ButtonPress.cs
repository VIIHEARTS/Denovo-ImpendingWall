using UnityEditor;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public bool canPress;
    public bool isPressed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPressed = false;
        canPress = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            canPress = true;
            Debug.Log("Collision with Button detected! You can now press.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canPress)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                isPressed = !isPressed;

                if (isPressed)
                {
                    Debug.Log("Button is pressed");
                }
                else if (!isPressed)
                {
                    Debug.Log("Button is relesed");
                }
            }
            else if (Input.GetButtonUp("Fire2"))
            {
                isPressed = !isPressed;
            }


        }
    }
}
