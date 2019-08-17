using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float cameraDistance = 4f;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float x = Input.GetAxis("Horizontal"); 
       float y = Input.GetAxis("Vertical"); 
       transform.Translate(new Vector3(x, y, 0) * speed * Time.deltaTime);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, cameraDistance);
    }
}
