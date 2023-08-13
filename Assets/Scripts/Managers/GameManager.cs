using GeometryDash.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode {Ground,Fly}
public class GameManager : MonoBehaviour
{
    [SerializeField] GameMode CurrentGameMode;

    public GameMode GetCurrentGameMode { get => CurrentGameMode; set => CurrentGameMode = value; }

    private void Awake()
    {
        CurrentGameMode = GameMode.Ground;
    }

    public void ChangeMode()
    {
        if (CurrentGameMode == GameMode.Ground)
            CurrentGameMode = GameMode.Fly;
        else if (CurrentGameMode == GameMode.Fly)
            CurrentGameMode = GameMode.Ground;
    }
}
