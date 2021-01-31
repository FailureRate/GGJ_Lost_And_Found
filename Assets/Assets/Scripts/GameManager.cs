using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {
    private static GameManager instance = new GameManager();
    private GameStates currentState;
 
    // make sure the constructor is private, so it can only be instantiated here
    private GameManager() {
    //    DontDestroyOnLoad(this.gameObject);
    }
 
    public static GameManager Instance {
        get { return instance; }
    }
 
    public void Pause(bool paused) {
        if (paused) {
            // pause the game/physics
            Time.timeScale = 0.0f;
        } else {
            // resume
            Time.timeScale = 1.0f;
        }
    }
     public GameStates GetCurrentState (){
        // only update state if it has been changed
        
        return currentState;
   }

    public GameStates CurrentState (GameStates value){
        // only update state if it has been changed
        if (currentState != value) {
            currentState = value;
 
            switch(value) {
                case GameStates.MENU:
                   
                     break;
                case GameStates.LEVEL:
                  
                    break;
                default:
                    // Do this when none of the cases above fit
                   
                    break;
            }
        }
        return currentState;
   }
}
 
public enum GameStates {
    MENU,
    LEVEL
}
