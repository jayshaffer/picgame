using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public float followSpeed = 4f;
    GameObject player;
    float calculatedSpeed = 0f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void FixedUpdate(){
        float dist = Vector3.Distance(transform.position, player.transform.position) / 100;
        float interpolation = (dist + (followSpeed / 100));
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        Vector3 newTrans = Vector3.Lerp(transform.position, player.transform.position, interpolation);
        newTrans.z = transform.position.z;
        transform.position = newTrans;
    }
}
