using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUI_PauseButton : MonoBehaviour
{
    public Text text_;
    public Color textColorOnHover;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnHover()
    {
        Debug.Log("HOVER");
        text_.color = textColorOnHover;
    }
    public void OnHoverExit()
    {
        text_.color = Color.white;
    }
}
