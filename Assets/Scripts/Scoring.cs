using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    // Start is called before the first frame update
    public int score = 0;
    Text text;
    void Start()
    {
       text = GetComponent<Text>(); 
       text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
    }
}
