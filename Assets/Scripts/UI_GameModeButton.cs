using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameModeButton : MonoBehaviour
{
    [SerializeField] private GameObject SelectedIcon;
    [SerializeField] private GameMode gameMode;
    
    public void SetNotSelected()
    {
        SelectedIcon.SetActive(false);
    }

    public void SetGameMode()
    {
        FindObjectOfType<GameModeController>().SetGameMode(gameMode);
    }
}
