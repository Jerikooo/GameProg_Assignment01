using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float Score = 0;
    public float CurrentScore = 0;
    
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    public void IncrementScore()
    {
        Score += 50;
    }
}
