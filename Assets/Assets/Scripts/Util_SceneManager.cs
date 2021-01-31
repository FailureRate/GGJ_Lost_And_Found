using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Util_SceneManager : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] private Util_AudioManager audioManager;
    private Scene currentScene;
    public string nextScene;

    void Awake(){
        DontDestroyOnLoad(gameObject);
       GameManager.Instance.CurrentState(GameStates.MENU); 
    }
    // Start is called before the first frame update
    void Start()
    {
         audioManager.SceneChange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void LoadNextScene(){
       GameManager.Instance.CurrentState(GameStates.LEVEL); 
       audioManager.SceneChange();
        SceneManager.LoadScene(nextScene);
    }
    public void ShowOptions(){
  //GOTO OPTIONS SCENE OR ENEABLE OPTIONS CANVAS
    }
}
