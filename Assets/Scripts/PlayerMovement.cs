using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region
    [Header("Movement")]
    public float speed;
    private Rigidbody2D _rb;
    
    [Header("Animation")]
    public Animator ani;
    
    [Header("Slow")]
    public float slowTerm;
    private float _slowTermTimer;
    private float _slowEffect;
    private bool _slowOn;

    public static PlayerMovement Instance;
    #endregion

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _slowEffect = 1;
        _slowOn = false;
    }
    void Update()
    {
        
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        
        Vector2 dir =  speed * _slowEffect * new Vector2(xInput, yInput).normalized;

        if (xInput < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (xInput > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        
        if (xInput != 0 || yInput != 0)
        {
            _rb.linearVelocity = dir;
            ani.SetBool("run", true);
        }
        else
        {
            _rb.linearVelocity = new Vector2(0f, 0f);
            ani.SetBool("run",false);
        }
        
        
        //slow
        if (_slowOn)
        {
            _slowTermTimer += Time.deltaTime;
            if (_slowTermTimer >= slowTerm)
            {
                _slowEffect = 1;
                _slowTermTimer = 0f;
                _slowOn = false;
            }
        }

    }

    public void Slow(float slow)
    {
        _slowEffect = slow;  
        _slowOn = true;
        _slowTermTimer = 0f;
    }
}
