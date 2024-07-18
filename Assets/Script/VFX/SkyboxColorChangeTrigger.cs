using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SkyboxColorChangeTrigger : MonoBehaviour
{
    
    public Material skyboxMaterial;
    public Color skyboxColorA;
    public Color skyBoxColorB;
    public float transitionTime = 0.5f;
    public bool dayTransition = false;
    public bool nightTransition = false;
    public bool transitioning = false;
    public bool toDay = false;
    public bool toNight = false;

    private SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (GeometryUtility.TestPlanesAABB(planes, renderer.bounds) && !transitioning)
        {
            if (skyboxMaterial.color == skyboxColorA && toNight)
                nightTransition = true;
            if (skyboxMaterial.color == skyBoxColorB && toDay) dayTransition = true;
            transitioning = true;
        }
        else if (!GeometryUtility.TestPlanesAABB(planes, renderer.bounds))
        {
            if (skyboxMaterial.color == skyboxColorA || skyboxMaterial.color == skyBoxColorB)
                transitioning = false;
        }
        
        if (nightTransition)
        {
            StartCoroutine(CrossFadeSkyboxColor(skyboxColorA, skyBoxColorB, transitionTime));
            nightTransition = false;
        }

        if (dayTransition)
        {
            StartCoroutine(CrossFadeSkyboxColor(skyBoxColorB, skyboxColorA, transitionTime));
            dayTransition = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (nightTransition)
            Gizmos.DrawIcon(transform.position, "Sky Gizmo.tiff", false, skyBoxColorB);
        if (dayTransition)
            Gizmos.DrawIcon(transform.position, "Sky Gizmo.tiff", false, skyboxColorA);
    }
    
    IEnumerator CrossFadeSkyboxColor(Color startingColor, Color endingColor, float duration)
    {
        float timer = 0;
        Color transitionalColor = startingColor;
        while (timer < duration)
        {
            transitionalColor = Color.Lerp(transitionalColor, endingColor, timer / duration);
            skyboxMaterial.color = transitionalColor; 
            timer += Time.deltaTime;
            print(transitionalColor);
            print(timer);
            yield return null;
        }
        skyboxMaterial.color = endingColor;
    }
}