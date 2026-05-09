using UnityEngine;
using UnityEngine.UI;

public class TimeScore : MonoBehaviour
{
    
    private Text score;
    private float time;
    void Start()
    {
        score = GetComponent<Text>();
        time = 0f;
    }
    
    void Update()
    {
        time += Time.deltaTime;
        score.text = "Time: " + (int)time;
    }
}
