using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private GameObject car2;
    [SerializeField] private GameObject car3;
    private bool started = true;
    private int aut = 0;
    private float cont = 5;
    void Start()
    {
        //carSpawn();
    }

    
    void Update()
    {
        //car.transform.position = transform.position + Vector3.right * 10f * Time.deltaTime;
        cont -= Time.deltaTime;
        Timer();

        if (started == true)
        {
            switch (aut)
            {
                case 1:
                    car.transform.position = car.transform.position + Vector3.right * 10f * Time.deltaTime;
                    //Debug.Log("asd");
                    break;
                case 2:
                    car2.transform.position = car2.transform.position + Vector3.right * 10f * Time.deltaTime;
                    //Debug.Log("asd");
                    break;
                case 3:
                    car3.transform.position = car3.transform.position + Vector3.right * 10f * Time.deltaTime;
                    //Debug.Log("asd");
                    break;
            }
        }
        
       
        if (car.transform.position.x >= 15)
        {
            car.transform.position = new Vector3(-30, car.transform.position.y, car.transform.position.z);
            started = false;
        }

        if (car2.transform.position.x >= 15)
        {
            car2.transform.position = new Vector3(-30, car2.transform.position.y, car2.transform.position.z);
            started = false;
        }

        if (car3.transform.position.x >= 15)
        {
            car3.transform.position = new Vector3(-30, car3.transform.position.y, car3.transform.position.z);
            started = false;
        }

        /*void carSpawn()
        {
            spawners = GameObject.FindGameObjectsWithTag("spawners");

            foreach (GameObject cars in spawners)
            {
                if (aut == true)
                {
                    Instantiate(car, transform.position, Quaternion.identity);
                    aut = false;
                }

            }
        }
        */




    }



    public void Timer()
    {
        if (cont <= 0)
        {
            started = true;
            aut = Random.Range(1, 4);
            Debug.Log(aut);
            cont = 6;
        }
    }

    private void OnTriggerExit(Collider car)
    {

        
            Debug.Log("tiragoma");
            //transform.position = new Vector3(-30, transform.position.y, transform.position.z);
            aut = 0;
        
    }
}
