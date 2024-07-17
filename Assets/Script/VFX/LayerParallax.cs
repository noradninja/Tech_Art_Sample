using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        float distanceX = position.x * (amountOfParallax * 0.250f);
        float distanceY = position.y * (amountOfParallax * 0.125f);
        Vector3 newPosition = new Vector3(startingPosX + distanceX, startingPosY + distanceY, transform.position.z);
        transform.position = newPosition;
    }
}

