using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CheckPlayerKeyFall : MonoBehaviour
{
    public Transform keyObject;
    public GameObject gameOverPanel;
    public Button yesButton;
    public Button noButton;

    private bool isGameOver = false;

    void Start()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    void OnDestroy()
    {
        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();
    }

    void Update()
    {
        if((keyObject.position.y < -5 || transform.position.y < -5) && !isGameOver)
        {
            isGameOver = true;
            Time.timeScale = 0;

            gameOverPanel.SetActive(true);
            yesButton.onClick.AddListener(ReloadScene);
            noButton.onClick.AddListener(QuitGame);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
