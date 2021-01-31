using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_PauseMenu : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private GameObject panel;

    [Header("Generics")]
    [SerializeField] private KeyCode pauseButton;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(pauseButton))
        {
            if(panel.active == true)
            {
                panel.SetActive(false);
                GameManager.Instance.CurrentState(GameStates.MENU);
                GameManager.Instance.Pause(false);
            }
            else
            {
                panel.SetActive(true);
                GameManager.Instance.CurrentState(GameStates.LEVEL);
                GameManager.Instance.Pause(true);
            }
        }
    }
    
    public void ResumeOnClick()
    {
        panel.SetActive(false);
        GameManager.Instance.CurrentState(GameStates.LEVEL);
        GameManager.Instance.Pause(false);
    }
}
