using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util_AudioManager : MonoBehaviour
{
//       private static Util_AudioManager instance = new Util_AudioManager();

//   private Util_AudioManager() {
//        // DontDestroyOnLoad(this.gameObject);
//     }

//  public static Util_AudioManager Instance {
//         get { return instance; }
//     }
    [Header("Music")]
    public AudioClip levelMusic;
    public AudioClip menuMusic;
    [Header("Sfx")]
    
    public AudioClip button;

    [Header("audio sources")]
    public AudioSource musicPLayer;
    public AudioSource sfxPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange(){
          switch(GameManager.Instance.GetCurrentState()) {
                case GameStates.MENU:
                 musicPLayer.clip = menuMusic;
                     musicPLayer.Play();
                     break;
                case GameStates.LEVEL:
                    musicPLayer.clip = levelMusic;
                    musicPLayer.Play();
                    break;
                default:
                    // Do this when none of the cases above fit
                   musicPLayer.Stop();
                    break;
            }
    }
  
    public void ButtonSound(){
        sfxPlayer.clip = button;
        sfxPlayer.Play();
    }
}
