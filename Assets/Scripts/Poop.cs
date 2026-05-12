using UnityEngine;

public class Poop : MonoBehaviour
{
    #region 
    [Header("Poop")]
    public float speed;
    public float damage = 15f;
    public float existTime = 3f;
    private float _existTimeCount;
    private Rigidbody2D _rb;
    public PoopPool myPool;
    
    [Header("SadPoopOnly")]
    public float slowEffect;
    #endregion
    public void Init(Vector2 dir)
    { 
        _rb = GetComponent<Rigidbody2D>();
        _rb.linearVelocity = new Vector2(dir.x, dir.y)*speed;
    }

    void Update()
    {
        _existTimeCount += Time.deltaTime;
        if (_existTimeCount >= existTime)
        {
            ReturnPoop();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHP playerHp = other.GetComponent<PlayerHP>();
            if (playerHp != null)
            {
                playerHp.TakeDamage(damage);
                if (slowEffect > 0)
                {
                    PlayerMovement playerSlow = other.GetComponent<PlayerMovement>();
                    playerSlow.Slow(slowEffect);
                }
            }
            ReturnPoop();
        }
    }

    void ReturnPoop()
    {
        _existTimeCount = 0f;
        myPool.Return(gameObject);
    }
    
    
}
