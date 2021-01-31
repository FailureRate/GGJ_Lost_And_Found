using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {
    private static GameManager instance = new GameManager();
    private GameStates currentState;
    public static bool playerHasLantern = false;
    public static bool playerHasGun = false;
    public static bool playerHasBomb = false;
    public static bool playerHasHook = false;

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
    public void SetItem(itemState state_)
    {
        if(state_ == itemState.Lantern)
        {
            playerHasLantern = true;
        }
        if(state_ == itemState.Gun)
        {
            playerHasGun = true;
        }
        if(state_ == itemState.Bomb)
        {
            playerHasBomb = true;
        }
        if(state_ == itemState.Hook)
        {
            playerHasHook = true;
        }
    }
}

public enum itemState
{
    None,
    Lantern,
    Gun,
    Bomb,
    Hook
}

public enum GameStates {
    MENU,
    LEVEL
}
