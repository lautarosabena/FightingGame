using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private GameObject car2;
    [SerializeField] private GameObject car3;
    [SerializeField] private GameObject car4;
    private bool started = true;
    private bool started2 = true;
    private int aut = 0;
    private int aut2 = 0;
    private float cont = 5;
    [SerializeField] private GameObject[] cars;

    
    void Start()
    {
        //carSpawn();
    }

    
    void Update()
    {
        cars = GameObject.FindGameObjectsWithTag("car");
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
               
                
            }
        }

        if (started2 == true)
        {
            switch (aut2)
            {
                
                case 1:
                    car3.transform.position = car3.transform.position + Vector3.left * 10f * Time.deltaTime;
                    //Debug.Log("asd");
                    break;
                case 2:
                    car4.transform.position = car4.transform.position + Vector3.left * 10f * Time.deltaTime;
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

        if (car3.transform.position.x <= -30)
        {
            car3.transform.position = new Vector3(3, car3.transform.position.y, car3.transform.position.z);
            started2 = false;
        }

        if (car4.transform.position.x <= -30)
        {
            car4.transform.position = new Vector3(3, car4.transform.position.y, car4.transform.position.z);
            started2 = false;
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
            started2 = true;
            aut = Random.Range(1, 3);
            aut2 = Random.Range(1, 3);
            Debug.Log(aut);
            Debug.Log(aut2);
            cont = 6;
        }
    }
    
    

    



        


}
