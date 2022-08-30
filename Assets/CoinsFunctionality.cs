using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsFunctionality : MonoBehaviour
{
    public static int PointsPJN = 0;
    public static int PointsPJR = 0;
    [SerializeField] private GameObject Explosion;
    public static bool Explotadisimo;
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
            Debug.Log("MONEDA NEGRO");
            Instantiate(Explosion, this.transform.position, Quaternion.identity);
            Explotadisimo = true;
            Destroy(gameObject);
        }

        if (other.gameObject.name == "PjRojo")
        {
            PointsPJR++;
            Debug.Log(PointsPJN);
            Debug.Log("MONEDA ROJO");
            Instantiate(Explosion, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
