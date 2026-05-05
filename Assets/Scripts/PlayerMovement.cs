using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public Animator Ani;

    private float sloweffect;
    private Rigidbody2D rb;

    private float timer;
    public float time;
    private bool settime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sloweffect = 1;
        settime = false;
    }


    void Update()
    {
        
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        
        Vector2 dir = new Vector2(xInput, yInput).normalized *Speed *sloweffect;

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
            rb. linearVelocity = dir;
            Ani.SetBool("run", true);
        }
        else
        {
            rb.linearVelocity = new Vector2(0f, 0f);
            Ani.SetBool("run",false);
        }
        
        
        //slow
        if (settime)
        {
            timer += Time.deltaTime;
            if (timer >= time)
            {
                sloweffect = 1;
                timer = 0f;
                settime = false;
            }
        }

    }

    public void Slow(float slow)
    {
        sloweffect = slow;  
        settime = true;
    }
}
