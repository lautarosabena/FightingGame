using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsFunctionality : MonoBehaviour
{
    public static int PointsPJN = 0;
    [SerializeField] private GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        //PointsPJN = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PjNegro")
        {
            PointsPJN++;
            Debug.Log(PointsPJN);
            Debug.Log("ASD");
            Instantiate(Explosion, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
