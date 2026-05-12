using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    #region
    public static PlayerHP Instance;
    [Header("HP")]
    [SerializeField] private Slider slider;
    private float _currentHp;
    private float _maxHp = 100f;
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
        _currentHp = _maxHp;
        slider.value = _currentHp;
    }
    public void TakeDamage(float damage)
    {
        _currentHp -= damage;
        slider.value = _currentHp;
        if (_currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    
}
