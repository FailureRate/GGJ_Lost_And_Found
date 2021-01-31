using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GUI_DarknessChange : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] Image[] onScreenSprites;

    [Header("Generics")]
    [Tooltip("The amount of time it takes to shift colors")]
    [SerializeField] private float shiftTime;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private Color diffrence;
    // Start is called before the first frame update
    void Start()
    {
        //diffrence = startColor - endColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 12)
        {
            Debug.Log("ShiftCall");
            if(onScreenSprites == null)
            {
                Debug.LogError("Missing Sprite Refrence");
            }
            else
            {
                foreach (Image image in onScreenSprites)
                {
                    image.color = new Color(1, 1, 1);
                }
                foreach (Image image in onScreenSprites)
                {
                    image.CrossFadeColor(endColor, shiftTime, false, false, true);
                }
            }
     
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (onScreenSprites == null)
        {
            Debug.LogError("Missing Sprite Refrence");
        }
        else
        {
            if (other.gameObject.layer == 12)
            {
                Debug.Log("DeShift");
                foreach (Image image in onScreenSprites)
                {
                    image.CrossFadeColor(startColor, shiftTime, false, false, true);
                }
            }
        }
    }

}
