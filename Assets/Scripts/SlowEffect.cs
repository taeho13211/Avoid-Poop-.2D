using UnityEngine;

public class SlowEffect : MonoBehaviour
{
    public float slowEffect;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerSlow = other.GetComponent<PlayerMovement>();
            playerSlow.Slow(slowEffect);
        }
    }
}
