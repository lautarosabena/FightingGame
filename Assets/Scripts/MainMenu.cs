using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public int levelGenerate;
    
    public GameObject optionsScreen;
    public GameObject title;
    public GameObject playButton;
    public GameObject optionsButton;
    public GameObject quitButton;
    public GameObject optionsFirstButton, optionsClosedButton;
    public GameObject instructionsScreen;
    public TextMeshProUGUI TimerText;

    public float timeRemaining = 500;
        

    public void JugarButton(){

        instructionsScreen.SetActive(true);
        timeRemaining = 15;
        //TimerText.text = timeRemaining.ToString("00");
        title.SetActive(false);
        playButton.SetActive(false);
        optionsButton.SetActive(false);
        quitButton.SetActive(false);
        //timeText.text = string.Format("El juego comienza en: " + timeRemaining.ToString("10"));
        
    }

    public void TutoScene(){
        SceneManager.LoadScene("TutorialScene");
    }

    public void LoadTheLevel()
    {
        
        levelGenerate = Random.Range(3, 7);
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

    void Update()
    {
        //timeRemaining == 5;
        timeRemaining -= Time.deltaTime;
        TimerText.text = string.Format("El juego comienza en: " +  timeRemaining.ToString("00"));
        //Debug.Log(timeRemaining);
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            //Debug.Log(timeRemaining);
        }
        if (timeRemaining <= 0)
        {
            TutoScene();
        }
    }
    
    
}
