using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float cameraDistance = 4f;
    public float speed = 2f;
    public Rigidbody2D rb;
    public GameObject jumpDetect;
    public float jumpForce = 5;
    
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
       jumpDetect = GameObject.FindWithTag("jumpdetect");
    }

    // Update is called once per frame
    void Update()
    {
       float x = Input.GetAxis("Horizontal"); 
       transform.Translate(new Vector3(x, 0, 0) * speed * Time.deltaTime);
       if(Input.GetButton("Jump") && JumpAllowed()){
           Jump();
       }
    }

    bool JumpAllowed(){
        Jump jump = jumpDetect.GetComponent<Jump>();
        return jump.JumpAllowed();
    }

    void Jump(){
        rb.velocity = new Vector2 (rb.velocity.x, jumpForce);    
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, cameraDistance);
    }
}
