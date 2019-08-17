using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public int travelDistance = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = new Vector3(transform.position.x + 1, transform.position.y);
       Vector3 endpoint = new Vector3(transform.position.x + travelDistance, transform.position.y);
    }
}
