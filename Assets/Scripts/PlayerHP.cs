using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Slider slider;
    public float hp = 100f;

    void Start()
    {
        slider.maxValue = hp;
        slider.value = hp;
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
        slider.value = hp;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    
}
