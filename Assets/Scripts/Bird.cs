using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = .5f;
    public float startleRadius;
    bool startled = false;
    Vector3 startleOrigin;
    LayerMask playerMask;
    Collider2D[] startleColliders;
    void Start()
    {
        playerMask = LayerMask.GetMask("Player");
    }

    // Update is called once per frame
    void Update()
    {
       if(startled){
           StartleMove();
       } 
       else{
           startleColliders = Physics2D.OverlapCircleAll(transform.position, startleRadius, playerMask);
           if(startleColliders.Length > 0){
               Debug.Log("Startled");
               Startle(startleColliders[0].gameObject.transform.position);
           }
       }
    }

    void StartleMove(){
        var heading = (transform.position - startleOrigin);
        var normalized = Vector3.Normalize(heading);
        normalized.y = Vector3.Normalize(transform.position).y;
        normalized.z = 0;
        transform.Translate(normalized * speed * Time.deltaTime);
    }

    void Startle(Vector3 sO){
        if(startled){
            return;
        }
        startleOrigin = sO;
        startled = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, startleRadius);
    }
}
