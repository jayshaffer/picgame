using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //How long the camera has to wait to recharge
    public float picDelay = 1f;
    Collider2D coll;
    List<GameObject> pointsOfInterest = new List<GameObject>();
    Vector3 mousePosition;
    int width = 3;
    int height = 2;
    GameObject player;
    PlayerController playerController;
    Scoring scoring;

    // Start is called before the first frame update
    void Start()
    {
       if(player == null){
           player = GameObject.FindWithTag("Player");
           playerController = player.GetComponent<PlayerController>();
       }
       if(scoring == null){
           scoring = GameObject.FindWithTag("score").GetComponent<Scoring>();
       }
        coll = GetComponent<Collider2D>();
        transform.localScale = new Vector3(width, height, 0);
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 newPos; 
       float radius = playerController.cameraDistance;
       mousePosition = Input.mousePosition;
       mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
       mousePosition.z = 0f;
       Vector3 v = mousePosition - player.transform.position;
       v = Vector3.ClampMagnitude(v, radius);
       newPos = player.transform.position + v;
       transform.position = newPos;  
       if(Input.GetButtonDown("Fire1")){
           SnapPhoto();
       }
    }

    void SnapPhoto(){
        float total = 0f;
        foreach(GameObject obj in pointsOfInterest){
            PointOfInterest poi = obj.GetComponent<PointOfInterest>();
            total += poi.CalculateValue();
        }
        scoring.score += (int)total;
    }

    void OnTriggerExit2D(Collider2D other) {
       pointsOfInterest.Remove(other.gameObject); 
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "poi"){
            pointsOfInterest.Add(other.gameObject);
        }
    }
}
