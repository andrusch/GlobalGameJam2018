using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState  {
    // public modifiers
    #region Singleton Methods
    private static GameState _instance = null;
    public static GameState Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameState();
            return _instance;
        }
    }
    #endregion
    public GameState()
    {

    }
    public bool CameraIsMoving = false;
    public int MaxX;
    public int MaxY;
}
