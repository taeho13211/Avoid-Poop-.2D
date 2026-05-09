using UnityEngine;

public class Poop : MonoBehaviour
{
    private Rigidbody2D _rb;

    public float speed;
    public float damage = 15f;
    public void Init(Vector2 dir)
    { 
        Debug.Log("O");
        _rb = GetComponent<Rigidbody2D>();
        _rb.linearVelocity = new Vector2(dir.x, dir.y)*speed;
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
