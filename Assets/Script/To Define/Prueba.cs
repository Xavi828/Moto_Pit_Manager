using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prueba : MonoBehaviour
{
    public Text[] leaderbordWriter;

    // Start is called before the first frame update
    void Start()
    {
              
        leaderbordWriter[1].text = ("Hola");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
