using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : MonoBehaviour
{
    public float maxValue = 0f;
    public float bonusRadius = 3f;
    
    float bonusMultiplier = 1.2f;
    public float value = 0f;
    

    int degredationPercentage = 9;

    // Start is called before the first frame update
    void Start()
    {
       maxValue = value; 
    }

    // Update is called once per frame
    void Update()
    {
    }

    public float CalculateValue(){
        if(value == 0){
            return 0;
        }
        LayerMask mask = LayerMask.GetMask("poi");
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, bonusRadius, mask);
        Debug.Log(hitColliders.Length);
        float newVal = value * bonusMultiplier;
        value = value / degredationPercentage;
        if(value < 1){
            value = 0;
        }
        return newVal;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, bonusRadius);
    }
}
