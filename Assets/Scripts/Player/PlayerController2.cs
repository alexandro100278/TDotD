using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public Vector2 Movement { get; private set; }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Prevent diagonal movement
        if (x != 0)
            y = 0;
        if (y != 0)
            x = 0;

        Movement = new Vector2(x, y).normalized;
    }
}