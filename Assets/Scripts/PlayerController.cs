using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;
    private bool isMoving;
    private Vector2 input;

    private void Update()
    {
        if (isMoving) return;
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (input.x != 0)input.y = 0;
        if (input != Vector2.zero)
        {
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        isMoving = true;
        Vector3 targetPosition = transform.position;
        targetPosition += new Vector3(input.x, input.y, 0);

        while ((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon) {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
                );
            yield return null;
        }
        transform.position = targetPosition;
        isMoving = false;
    }
}
