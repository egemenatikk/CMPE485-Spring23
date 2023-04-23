using UnityEngine;
using TMPro;

public class SoundManager : MonoBehaviour
{

    private static SoundManager instance;
    public AudioSource audioSource;
    public TextMeshProUGUI buttonText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleSound()
    {
        audioSource.mute = !audioSource.mute;
        if (audioSource.mute)
        {
            buttonText.text = "Sound: OFF";
        } else
        {
            buttonText.text = "Sound: ON";
        }
    }
}
