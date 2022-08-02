using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public int levelGenerate;

    public GameObject optionsScreen;
    public GameObject title;
    public GameObject playButton;
    public GameObject optionsButton;
    public GameObject quitButton;
    public GameObject optionsFirstButton, optionsClosedButton;

    public void LoadTheLevel()
    {
        levelGenerate = Random.Range(1, 3);
        SceneManager.LoadScene(levelGenerate);
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
        title.SetActive(false);
        playButton.SetActive(false);
        optionsButton.SetActive(false);
        quitButton.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
        title.SetActive(true);
        playButton.SetActive(true);
        optionsButton.SetActive(true);
        quitButton.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsClosedButton);
    }   


    public void EscenaJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void EscenaOpcioness()
    {
        SceneManager.LoadScene("Options");
    }
    public void Salir()
    {
        Application.Quit();
    }
}
