using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxColorChangeTrigger : MonoBehaviour
{
    public Material skyboxMaterial;
    public Color skyboxColorA;
    public Color skyBoxColorB;
    public float transitionTime = 0.5f;
    public bool dayTransition = false;
    public bool nightTransition = false;

    // Update is called once per frame
    void Update()
    {
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
