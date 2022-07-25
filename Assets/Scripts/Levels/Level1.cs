using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    int randomNumber = 1;
    int random = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (randomNumber == 1) {
          transform.Rotate  (5 * Time.deltaTime ,0,0);
          if (randomNumber == 1 && random == 0) {
            Invoke("TEST", 3.0f);
          random = 1;  
          Debug.Log("funca1");
          }
          
          
        }

        if (randomNumber == 2) {
          transform.Rotate  (-5 * Time.deltaTime,0,0 * Time.deltaTime);  
          if (randomNumber == 2 && random == 1) {
            Invoke("TEST2", 3.0f);
          random = 2;  
          Debug.Log("funca2");
          }
          
          
        }

        if (randomNumber == 3) {
          transform.Rotate  (0,5 * Time.deltaTime,0);  
          if (randomNumber == 3 && random == 2) {
            Invoke("TEST3", 3.0f);
          random = 3;  
          Debug.Log("funca3");
          }
          
        }

        if (randomNumber == 4) {
          transform.Rotate  (0,-5 * Time.deltaTime,0); 
          if (randomNumber == 4 && random == 3) {
            Invoke("TEST4", 3.0f);
          random = 0;  
          Debug.Log("funca4");
          }
          
        }
        
        
        
    }

    void TEST() {
        randomNumber = 2;
    }

    void TEST2() {
        randomNumber = 3;
    }

    void TEST3() {
        randomNumber = 4;
    }

    void TEST4() {
        randomNumber = 1;
    }

    
}





    