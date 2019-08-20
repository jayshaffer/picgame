using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public float remaining;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
       text = GetComponent<Text>(); 
       text.text = ""; 
    }

    // Update is called once per frame
    void Update()
    {
       text.text = remaining.ToString(); 
    }
}
