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
    public GameObject title;
    [SerializeField] private Animator animatorPJ1;

    [SerializeField] private Animator animatorPJ2;
    public GameObject instructionsScreen;

    public GameObject quitScreen;
    public GameObject scenery;

    public TextMeshProUGUI Player1ReadyText;

    public TextMeshProUGUI Player2ReadyText;

    public TextMeshProUGUI StartingText;

    public GameObject ButtonImage;

    public GameObject ButtonImage2;

    public GameObject ButtonImage3;

    public GameObject JoyIcon;

    public GameObject QuitIcon;

    public GameObject Player1ReadyImage;

    public GameObject CirclePlayer1;

    public GameObject CirclePlayer2;

    public GameObject ArrowPlayer1;

    public GameObject ArrowPlayer2;

    private bool ShowPlayer1Ready = false;

    private bool ShowPlayer2Ready = false;

    private bool ShowInstructions = false;

    private bool ShowQuit = false;

    private bool isMenu = false;

    public GameObject Player2ReadyImage;

    public float timeRemaining = 500;
        

    public void InstructionsButton(){

        instructionsScreen.SetActive(true);
        scenery.SetActive(false);
        title.SetActive(false);
        Player1ReadyText.gameObject.SetActive(false);
        Player2ReadyText.gameObject.SetActive(false);
        StartingText.gameObject.SetActive(false);
        //Player1ReadyImage.SetActive(false);
        //Player2ReadyImage.SetActive(false);
        CirclePlayer1.SetActive(false);
        CirclePlayer2.SetActive(false);
        ArrowPlayer1.SetActive(false);
        ArrowPlayer2.SetActive(false);
        ButtonImage.SetActive(false);
        ButtonImage2.SetActive(false);
        ButtonImage3.SetActive(false);
        JoyIcon.SetActive(false);
        QuitIcon.SetActive(false);

    }

    public void InstructionsBackButton(){
        instructionsScreen.SetActive(false);
        scenery.SetActive(true);
        title.SetActive(true);
        Player1ReadyText.gameObject.SetActive(true);
        Player2ReadyText.gameObject.SetActive(true);
        StartingText.gameObject.SetActive(true);
        ButtonImage.SetActive(true);
        //Player1ReadyImage.SetActive(true);
        //Player2ReadyImage.SetActive(true);
        CirclePlayer1.SetActive(true);
        CirclePlayer2.SetActive(true);
        ArrowPlayer1.SetActive(true);
        ArrowPlayer2.SetActive(true);
        ButtonImage2.SetActive(true);
        ButtonImage3.SetActive(true);
        JoyIcon.SetActive(true);
        QuitIcon.SetActive(true);
    }

    public void QuitButton(){
        quitScreen.SetActive(true);
        ButtonImage2.SetActive(false);
        ButtonImage3.SetActive(false);
        JoyIcon.SetActive(false);
        QuitIcon.SetActive(false);      
    }

    public void QuitBackButton(){
        quitScreen.SetActive(false);
        ButtonImage2.SetActive(true);
        ButtonImage3.SetActive(true);
        JoyIcon.SetActive(true);
        QuitIcon.SetActive(true);
    }
    public void TutoScene(){
        SceneManager.LoadScene("TutorialScene");
    }
    public void Salir()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        if (timeRemaining <= 0)
        {
            TutoScene();
        }
        

        if(Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.K)){
            PlayerOneReady = true;
            animatorPJ1.SetBool("PJ1isReady", true);
        }

        if(Input.GetKey(KeyCode.Joystick2Button0) || Input.GetKeyDown(KeyCode.L)){
            PlayerTwoReady = true;
            animatorPJ2.SetBool("PJ2isReady", true);
        }

        if(Input.GetKeyUp(KeyCode.Joystick1Button3) || Input.GetKeyUp(KeyCode.Joystick2Button3) || Input.GetKeyUp(KeyCode.I)){
            ShowInstructions = !ShowInstructions;
            if(ShowInstructions){
            InstructionsButton();
            } else {
            InstructionsBackButton();
            }
            
        }

    
        if(Input.GetKeyUp(KeyCode.Joystick1Button1) || Input.GetKeyUp(KeyCode.Joystick2Button1) || Input.GetKeyUp(KeyCode.B)){
            ShowQuit = !ShowQuit;
            if(ShowQuit){
            QuitButton();
            if(Input.GetKeyUp(KeyCode.Joystick1Button0) || Input.GetKeyUp(KeyCode.K)){
                Salir();
            }            
            } else {
            QuitBackButton();
            }
        }

        if(PlayerOneReady == true){
            ShowPlayer1Ready = true;
            }

        if(PlayerTwoReady == true){
            ShowPlayer2Ready = true;
            }

        if(ShowPlayer1Ready == true){
            Player1ReadyText.text = "Listo";
            Player1ReadyImage.SetActive(true);
            }
        if(ShowPlayer2Ready == true){
            Player2ReadyText.text = "Listo";
            Player2ReadyImage.SetActive(true);
            }

        if(ShowPlayer1Ready == true && ShowPlayer2Ready == true){
            StartingText.text = "Comenzando...";
            ButtonImage.SetActive(false);
        }else{
            StartingText.text = "Presiona    para jugar";
            ButtonImage.SetActive(true);
        }

        if(PlayerOneReady == true && PlayerTwoReady == true){
            timeRemaining = 5;
            PlayerOneReady = false;
            PlayerTwoReady = false;
        } 
    }
    
    
}
