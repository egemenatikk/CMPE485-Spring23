using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenController : MonoBehaviour
{
    private int selectedCharacterIndex = 0;
    private TextMeshProUGUI selectedCharacterText;
    private string[] names = { "Jonathon", "Jamie", "Jay" };

    private void Start()
    {
        selectedCharacterText = GameObject.Find("CharacterName").GetComponent<TextMeshProUGUI>();
        selectedCharacterText.text = names[selectedCharacterIndex];
    }
    public void NextCharacter()
    {
        selectedCharacterIndex = (selectedCharacterIndex + 1) % 3;
        selectedCharacterText.text = names[selectedCharacterIndex];
    }

    public void PreviousCharacter()
    {
        selectedCharacterIndex -= 1;
        if (selectedCharacterIndex < 0) {
            selectedCharacterIndex = 2;
        }
        selectedCharacterText.text = names[selectedCharacterIndex];
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacterIndex", selectedCharacterIndex);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
