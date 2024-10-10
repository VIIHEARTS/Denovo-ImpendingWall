using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonPress : MonoBehaviour
{
    public bool canPress;
    public bool isPressed;

    public GameObject Door;

    [SerializeField]
    private TextMeshProUGUI controllerPressText, keyboardPressText;
    Controls KeyboardSelected;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPressed = false;
        canPress = false;

        keyboardPressText.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            canPress = true;
            keyboardPressText.gameObject.SetActive(true);
            Debug.Log("Collision with Button detected! You can now press.");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canPress = false;
            keyboardPressText.gameObject.SetActive(false);
            Debug.Log("Away from button!");
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
                    Door.gameObject.SetActive(false);
                    Debug.Log("Button is pressed");
                }
                else if (!isPressed)
                {
                    Door.gameObject.SetActive(true);
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
