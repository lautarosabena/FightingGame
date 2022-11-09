using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinishedScene : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void update()
    {
        if(Input.GetKeyUp(KeyCode.Joystick1Button0) || Input.GetKeyUp(KeyCode.Joystick2Button0)) 
        {
            VolverAlMenu();
        }
    }
}
