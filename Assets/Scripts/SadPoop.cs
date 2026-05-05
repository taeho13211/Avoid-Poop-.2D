using System;
using UnityEngine;

public class SadPoop : MonoBehaviour
{
    private Rigidbody2D rb;

    public float damage;
    public float slow;

    public float Speed;
    public void Init(Vector2 dir)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(dir.x, dir.y)* Speed;
        Destroy(gameObject,3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHP playerHp = other.GetComponent<PlayerHP>();
            playerHp.TakeDamage(damage);
            PlayerMovement playerMove = other.GetComponent<PlayerMovement>();
            playerMove.Slow(slow);
            
            Destroy(gameObject);
        }
    }
}
