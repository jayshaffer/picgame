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
    public float maxSpeed = 5;
    public float jetPackForce = 5;
    public float jumpDelay = 1f;
    public GameObject pictureBox;
    Jump jump;
    bool jumping = false;
    float nextJumpAction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpDetect = GameObject.FindWithTag("jumpdetect");
        jump = jumpDetect.GetComponent<Jump>();
        nextJumpAction = Time.time;
        if(pictureBox == null){

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.ClampMagnitude(new Vector3(x, 0, 0) * speed * Time.deltaTime, maxSpeed));
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        HandleJump();
    }

    void Jetpack()
    {
        rb.AddForce(transform.up * jetPackForce);
    }

    void HandleJump()
    {
        if (!Input.GetButton("Jump"))
        {
            return;
        }
        if (jump.onGround)
        {
            Jump();
            nextJumpAction = Time.time + jumpDelay;
        }
        else if (Time.time > nextJumpAction)
        {
            Jetpack();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, cameraDistance);
    }
}
