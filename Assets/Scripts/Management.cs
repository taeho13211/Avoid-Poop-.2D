using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Management : MonoBehaviour
{
    public static bool IsgameOver;
    public GameObject player;
    [SerializeField] private TextMeshProUGUI gameOver;

    void Awake()
    {
        IsgameOver = false;
        gameOver.gameObject.SetActive(false);
    }
    void Update()
    {
        if (player == null)
        {
            gameOver.gameObject.SetActive(true);
            IsgameOver = true;
            Time.timeScale = 0f;
             if (Input.GetKeyDown(KeyCode.R)) 
             {
                 Time.timeScale = 1f; 
                 SceneManager.LoadScene("GameScene");
             } 
        }
    }
}
