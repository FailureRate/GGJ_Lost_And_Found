using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENV_DarknessRises : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] Light worldLight;

    [Header("Generics")]
    [SerializeField] float transitionTime;
    [SerializeField] string transitionTag;
    private float initialLightIntensity;
    // Start is called before the first frame update
    void Awake()
    {
        if (!worldLight)
        {
            worldLight = GameObject.FindGameObjectWithTag("WorldLight").GetComponent<Light>();
            if (!worldLight)
            {
                Debug.LogError("Create World Light or tag the World Light");
            }
        }
        initialLightIntensity = worldLight.intensity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(transitionTag))
        {
            StartCoroutine(LightsOut());
            Debug.Log("Kill the lights!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(transitionTag))
        {
            Debug.Log("Start The Lights!");
            StartCoroutine(LightsOn());
        }
    }
    private IEnumerator LightsOut()
    {
        float timer = 0.0f;
        // Gets linear of time and intesity 
        float diffrence = initialLightIntensity / transitionTime;
        while(timer < transitionTime)
        {
            // removes light on the linear 
            worldLight.intensity -= diffrence * Time.deltaTime;
            timer += Time.deltaTime;
            yield return null;
        }
        // Fixes if not precise
        worldLight.intensity = 0.0f;
       yield return null;
    }
    private IEnumerator LightsOn()
    {
        float timer = 0.0f;
        // get's the linear between time and inensity
        float diffrence = initialLightIntensity / transitionTime;
        while (timer < transitionTime)
        {
            //Adds light over time
            worldLight.intensity += diffrence * Time.deltaTime;
            timer += Time.deltaTime;
            yield return null;
        }
        // Fixes if off 
        worldLight.intensity = initialLightIntensity;
        yield return null;
    }
}
