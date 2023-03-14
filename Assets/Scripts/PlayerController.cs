using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    public float forceMagnitude = 0.34f;

    void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 direction = collision.contacts[0].normal;
        Vector2 target = new Vector2(0f, -3f);
        Vector2 force = direction * forceMagnitude;
        GetComponent<Rigidbody2D>().AddForce(force,ForceMode2D.Impulse);

        // Calculate the direction vector to the target
        Vector2 directionToTarget = target - (Vector2)transform.position;

        // Scale the vector by the force magnitude
        Vector2 forceVector = directionToTarget.normalized * forceMagnitude;

        // Add a random vector to the force vector for randomness
        Vector2 randomVector = Random.insideUnitCircle;
        forceVector += randomVector.normalized * forceMagnitude;

        // Apply the force to the object
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(forceVector, ForceMode2D.Impulse);
    }

}