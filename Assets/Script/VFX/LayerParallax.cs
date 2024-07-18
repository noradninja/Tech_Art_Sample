using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LayerParallax : MonoBehaviour
{
    private float startingPosX, startingPosY; 
    public float amountOfParallax; 
    public Camera mainCamera; 
    
    private void Start()
    {
        startingPosX = transform.position.x;
        startingPosY = transform.position.y;
    }
    
    private void Update()
    {
        Vector3 position = mainCamera.transform.position;
        float distanceX = position.x * (amountOfParallax * 0.125f);
        float distanceY = position.y * (amountOfParallax * 0.05125f);
        Vector3 parallaxPosition = new Vector3(startingPosX - distanceX, startingPosY - distanceY, transform.position.z);
        transform.position = parallaxPosition;
    }
}

