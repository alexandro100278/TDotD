using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private PlayerController2 controller;

    private Vector2 lastDirection = Vector2.down;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController2>();
    }

    void Update()
    {
        Vector2 movement = controller.Movement;

        bool moving = movement != Vector2.zero;

        animator.SetBool("isMoving", moving);
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);

        if (moving)
        {
            lastDirection = movement;

            animator.SetFloat("LastMoveX", lastDirection.x);
            animator.SetFloat("LastMoveY", lastDirection.y);
        }
        /*
        if (movement.x > 0)
            spriteRenderer.flipX = false;
        else if (movement.x < 0)
            spriteRenderer.flipX = true;*/
    }
}