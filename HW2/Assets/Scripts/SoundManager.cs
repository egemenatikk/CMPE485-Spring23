using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private static SoundManager instance;
    public AudioSource audioSource;

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
    }
}
