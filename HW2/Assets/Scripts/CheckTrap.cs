using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CheckTrap : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Button yesButton;
    public Button noButton;

    private bool isGameOver = false;

    void Start()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isGameOver && collision.gameObject.layer == LayerMask.NameToLayer("Trap"))
        {
            isGameOver = true;
            Time.timeScale = 0;

            gameOverPanel.SetActive(true);
            yesButton.onClick.AddListener(ReloadScene);
            noButton.onClick.AddListener(QuitGame);
        }
    }

    void OnDestroy()
    {
        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();
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
