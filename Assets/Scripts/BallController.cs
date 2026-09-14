using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
  private Rigidbody2D rb;
    public Vector2 startyVelocity = new Vector2(5f, 5f);

    public float speedUp = 10f;

    public GameManager gameManager;
    public void ResetBall()
    {
        transform.position = Vector3.zero;

        if (rb == null) rb = GetComponent<Rigidbody2D>();

        float xDirection = Random.Range(0, 2) == 0 ? -1f : 1f;
    
        rb.velocity = new Vector2(xDirection * 5f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = rb.velocity;

            newVelocity.y = -newVelocity.y;
            rb.velocity = newVelocity;
        }
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            float xDirection = transform.position.x < collision.transform.position.x ? -1f : 1f;

           
            float yDirection = (transform.position.y - collision.transform.position.y) / collision.collider.bounds.size.y;

        
            Vector2 direction = new Vector2(xDirection, yDirection).normalized;

           
            direction.y += Random.Range(-0.1f, 0.1f);

           
            float speed = rb.velocity.magnitude;
            if (speed < 10f) speed = 10f; 

            rb.velocity = direction * speed;
        }
        if (collision.gameObject.CompareTag("WallEnemy"))
        {
            gameManager.ScorePlayer();
            ResetBall();
        }
        if (collision.gameObject.CompareTag("WallPlayer"))
        {
            gameManager.ScoreEnemy();
            ResetBall();
        }
    }
}
