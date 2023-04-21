using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CheckPlayerWon : MonoBehaviour
{
    public GameObject keyObject;
    public GameObject gameWonPanel;
    public Button yesButton;
    public Button noButton;

    private bool isGameWon = false;

    void Start()
    {
        gameWonPanel.SetActive(false);
        Time.timeScale = 1;
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isGameWon && collision.gameObject == keyObject)
        {
            isGameWon = true;
            Time.timeScale = 0;
            transform.rotation = Quaternion.Euler(0f, 270f, 0f);

            gameWonPanel.SetActive(true);
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
        gameWonPanel.SetActive(false);
    }
}
