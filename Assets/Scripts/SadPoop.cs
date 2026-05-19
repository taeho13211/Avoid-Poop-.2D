using UnityEngine;

public class SadPoop : Poop
{
    [Header("SadPoop")]
    public float slowEffect;
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (slowEffect > 0)
        {
            PlayerMovement.Instance.Slow(slowEffect);
        }
        base.OnTriggerEnter2D(other);
    }
}
