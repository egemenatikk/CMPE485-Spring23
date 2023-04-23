using UnityEngine;
using TMPro;

public class SoundButtonManager : MonoBehaviour
{
    private SoundManager soundManager;
    public TextMeshProUGUI soundButtonText;

    
    void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        UpdateSoundButtonText();   
    }

    public void ToggleSound()
    {
        soundManager.ToggleSound();
        UpdateSoundButtonText();
    }

    void UpdateSoundButtonText()
    {
        if (soundManager.audioSource.mute)
        {
            soundButtonText.text = "Sound: OFF";
        }
        else
        {
            soundButtonText.text = "Sound: ON";
        }
    }
}
