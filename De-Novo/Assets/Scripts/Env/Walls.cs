using UnityEngine;

public class Walls : MonoBehaviour
{
    public float wallSpeed;
    float wallMoveX;
    bool isActive;

    public PlayerCtrls playerControls;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isActive = false;
        playerControls = FindAnyObjectByType<PlayerCtrls>();

        if (playerControls == null)
        {
            Debug.LogError("Player controls component not found in the scene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControls != null && playerControls.hasMoved)
        {
            isActive = true;
        }

        if (isActive == true)
        {
            transform.Translate(Vector2.right * wallSpeed * Time.deltaTime);
        }
    }


}
