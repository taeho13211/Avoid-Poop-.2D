using UnityEngine;
using TMPro;
public class TimeCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mytext;
    private float _time;
    void Update()
    {
        _time += Time.deltaTime;
        mytext.text = "TIME:" + (int)_time;
    }
}
