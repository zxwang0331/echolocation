using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Vector2 targetPosition;
    private Rigidbody2D rb;
    void Start()
    {
        targetPosition = new Vector2(-2.87f, 3.92f);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowRotate();
        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void FixedUpdate()
    {
        FollowMove();
    }
    private void FollowRotate()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = mouse - obj;
        direction.z = 0f;
        direction = direction.normalized;
        transform.up = direction;
    }
    private void FollowMove()
    {
        Vector2 currentPosition = rb.position;
        Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);
    }
}
