using UnityEngine;

public class Poop : MonoBehaviour
{
    private Rigidbody2D rb;

    public float Speed;
    public float damage;
    public void Init(Vector2 dir)
    { 
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(dir.x, dir.y)*Speed;
        Destroy(gameObject,3.5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Contact");
            PlayerHP playerHp = other.GetComponent<PlayerHP>();
            if (playerHp != null)
            {
                playerHp.TakeDamage(damage);
            }
            
            Destroy(gameObject);
        }
    }
    
    
}
