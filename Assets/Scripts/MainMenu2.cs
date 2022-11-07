using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class MainMenu2 : MonoBehaviour
{    
    private bool PlayerOneReady = false;
    private bool PlayerTwoReady = false;
    public GameObject optionsScreen;
    public GameObject title;
    
    public GameObject quitButton;
    public GameObject optionsFirstButton, optionsClosedButton;
    public GameObject instructionsScreen;
    public GameObject scenery;
    public TextMeshProUGUI TimerText;

    public float timeRemaining = 500;
        

    public void JugarButton(){

        instructionsScreen.SetActive(true);
        scenery.SetActive(false);
        timeRemaining = 15;
        //TimerText.text = timeRemaining.ToString("00");
        title.SetActive(false);
        quitButton.SetActive(false);
        //timeText.text = string.Format("El juego comienza en: " + timeRemaining.ToString("10"));
        
    }

    public void TutoScene(){
        SceneManager.LoadScene("TutorialScene");
    }

    

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
        title.SetActive(false);
        quitButton.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
        title.SetActive(true);
        quitButton.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsClosedButton);
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
        Debug.Log(timeRemaining);

        if(Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.K)){
            PlayerOneReady = true;
            Debug.Log("Player 1 Ready");
        }

        if(Input.GetKey(KeyCode.Joystick2Button0) || Input.GetKeyDown(KeyCode.L)){
            PlayerTwoReady = true;
            Debug.Log("Player 2 Ready");
        }

        if(PlayerOneReady == true && PlayerTwoReady == true){
            JugarButton();
            PlayerOneReady = false;
            PlayerTwoReady = false;
        }


        
    }
    
    
}
