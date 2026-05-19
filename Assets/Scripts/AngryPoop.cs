using UnityEngine;

public class AngryPoop : Poop
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Boom(other);
        }
        base.OnTriggerEnter2D(other);
    }

    void Boom(Collider2D other)
    {
        Debug.Log(other);
    }
}
