using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    public GameObject primerTutoScreen;
    public GameObject segundoTutoScreen;
    public GameObject tercerTutoScreen;
    public GameObject FinalTutoScreen;
    public bool ningunTutoHecho = true;
    public bool primerTutoHecho = false;
    public bool segundoTutoHecho = false;
    public bool tercerTutoHecho = false;
    public bool FinalTutoHecho = false;
    public float timerr = 10;
    // Start is called before the first frame update
    void Start()
    {
        
        //public static PlayerMovement2;
        //primerTutoScreen.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Joystick2Button1)){
            SceneManager.LoadScene("TutorialScene");
        }
        switch (ningunTutoHecho)
        {
            case true:
                primerTutoScreen.SetActive(true);
                PrimerTutorial();
                break;
            case false:
                primerTutoScreen.SetActive(false);
                break;
        }

        switch (primerTutoHecho)
        {
            case true:
                segundoTutoScreen.SetActive(true);
                SegundoTutorial();
                break;
            case false:
                segundoTutoScreen.SetActive(false);
                break;
        }
        switch (segundoTutoHecho)
        {
            case true:
                tercerTutoScreen.SetActive(true);
                TercerTutorial();
                break;
            case false:
                tercerTutoScreen.SetActive(false);
                break;
        }
        switch (tercerTutoHecho)
        {
            case true:
                FinalTutorial();
                FinalTutoScreen.SetActive(true);
                break;
            case false:
                FinalTutoScreen.SetActive(false);
                break;
        }
        
        
    }
    public void PrimerTutorial(){
        if(PlayerMovement2.currentMovement.x != 0 || PlayerMovement2.currentMovement.y != 0 && ningunTutoHecho == true){
            //Destroy(primerTutoScreen);
            //segundoTutoScreen.SetActive(true);
            Debug.Log("PrimerTutorial");
            primerTutoHecho = true;
            ningunTutoHecho = false;
        }
    }

    public void SegundoTutorial(){
        if(primerTutoHecho && Input.GetKey(KeyCode.Joystick1Button0)){
                    //primerTutoScreen.SetActive(false);
                    //Destroy(segundoTutoScreen);
                    //tercerTutoScreen.SetActive(true);
                    Debug.Log("SegundoTutorial");
                    segundoTutoHecho = true;
                    primerTutoHecho = false;
                
        }    
    }

    public void TercerTutorial(){
        if(segundoTutoHecho && Input.GetKey(KeyCode.Joystick1Button2) || Input.GetKey(KeyCode.Joystick1Button3)){
                    //tercerTutoScreen.SetActive(false);
                    //Destroy(FinalTutoScreen);
                    //FinalTutoScreen.SetActive(true);
                    Debug.Log("TercerTutorial");
                    tercerTutoHecho = true;
                    segundoTutoHecho = false;
                
        }    
    }
    public void FinalTutorial(){
        if(tercerTutoHecho){
            FinalTutoHecho = true;
            timerr -= Time.deltaTime;
            if(timerr <= 0){
                SceneManager.LoadScene("PlataformaLoca");
            }        
                
        }    
    }

    


}
