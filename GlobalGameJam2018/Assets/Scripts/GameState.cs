using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
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
    public int PlayerHealth = 10;
    public int EnemiesKilled = 0;
    public bool IsPlayerInvincible = false;
    public int NucleiDestroyed = 0;
    public float SpeedBoost = 0;
    public AudioHelpers AudioHelper
    {
        get
        {
            return (AudioHelpers)GameObject.Find("AudioHelpers").GetComponent(typeof(AudioHelpers));
        }
    }

    public GameObject Player
    {
        get
        {
            return GameObject.Find("PlayerPrefab");
        }
    }
    
}
