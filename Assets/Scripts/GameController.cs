using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    GameMode GetGameMode()
    {
        GameModeController gameModeController = FindObjectOfType<GameModeController>();
        return gameModeController.GetGameMode();
    }

    Texture2D GetStory()
    {
        StoryController storyController = FindObjectOfType<StoryController>();
        return storyController.GetSrcTextureStory();
    }
    
    public void StartGame()
    {
        GameMode mode = GetGameMode();
        if (mode == GameMode.None)
        {
            ShowError("Vui long chon Game mode");
            return;
        }

        Texture2D story = GetStory();
        if (story == null)
        {
            ShowError("Vui long chon Story");
            return;
        }
        
        FindObjectOfType<UI_Controller>().GoToGameScreen();
    }

    void ShowError(String error)
    {
        UI_Controller uiController = FindObjectOfType<UI_Controller>();
        uiController.SetError(error);
    }
}
