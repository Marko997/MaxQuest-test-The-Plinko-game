using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PyramidBoundry : MonoBehaviour
{
    private CircleCollider2D ballCollider;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player (Clone)");
        ballCollider = player.GetComponent<CircleCollider2D>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Calculate the point of intersection between the ball and the pyramid's edges
            Vector2 intersectionPoint = collision.ClosestPoint(transform.position);

            // Reflect the ball's velocity across the intersection point to simulate a realistic bounce
            Rigidbody2D ballRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 velocity = ballRigidbody.velocity;
            Vector2 normal = intersectionPoint - (Vector2)transform.position;
            Vector2 reflectedVelocity = Vector2.Reflect(velocity, normal);
            ballRigidbody.velocity = reflectedVelocity;

            // Move the ball inside the pyramid to prevent it from getting stuck on the edge
            Vector2 offset = normal.normalized * (collision.bounds.size.magnitude / 2f + ballCollider.radius);
            collision.transform.position = intersectionPoint + offset;
        }
    }
}
