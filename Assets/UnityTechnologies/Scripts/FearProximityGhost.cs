using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearProximityGhost : MonoBehaviour
{
    // Reference to the player's transform
    public Transform player;
    public float maxFearDistance = 20f;
    public float minFearDistance = 5f; 

    [HideInInspector] public float currentFearLevel;

    void Update()
    {
        if (player != null)
        {
           
            float distance = Vector3.Distance(transform.position, player.position);

         
            float distanceNormalized = Mathf.InverseLerp(maxFearDistance, minFearDistance, distance);

        
            currentFearLevel = Mathf.Clamp01(distanceNormalized);

            
        }
    }
}