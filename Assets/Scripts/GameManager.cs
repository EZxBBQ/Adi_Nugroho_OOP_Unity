using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance {get; private set;}
    public LevelManager LevelManager {get; private set;}
    
    void Awake() 
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        LevelManager = GetComponentInChildren<LevelManager>();

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(GameObject.Find("Player"));
        DontDestroyOnLoad(GameObject.Find("Main Camera"));
    }
}
