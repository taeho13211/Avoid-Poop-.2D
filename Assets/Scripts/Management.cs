using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Collections;
public class Management : MonoBehaviour
{
    public GameObject player;
    private bool _isGameOver;

    void Awake()
    {
        _isGameOver = false;
    }
    void Update()
    {
        if (player)
        {
            
        }
        else
        {
            Time.timeScale = 0f;
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}
