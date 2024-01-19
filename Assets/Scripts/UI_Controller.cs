using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private GameObject home_menu_panel;
    [SerializeField] private GameObject game_screen_panel;
    [SerializeField] private TMP_Text errorText;

    private void Start()
    {
        GoToMenuScreen();
    }

    public void GoToGameScreen()
    {
        home_menu_panel.SetActive(false);
        game_screen_panel.SetActive(true);
    }

    public void GoToMenuScreen()
    {
        home_menu_panel.SetActive(true);
        game_screen_panel.SetActive(false);
    }

    public void SetError(string error)
    {
        errorText.text = error;
        errorText.gameObject.SetActive(true);
        Invoke(nameof(HideError), 3f);
    }

    void HideError()
    {
        errorText.gameObject.SetActive(false);
    }

    public void InitializeGameScreen(GameMode mode, Texture2D story)
    {
        int numOfRows = 0;
        int imgSize = 0;
        
        switch (mode)
        {
            case GameMode.Easy:
                numOfRows = 3;
                imgSize = 300;
                break;
            case GameMode.Normal:
                numOfRows = 4;
                imgSize = 200;
                break;
            case GameMode.Hard:
                numOfRows = 5;
                imgSize = 150;
                break;
        }
        
        FindObjectOfType<PlayZone>().Initalize(numOfRows, imgSize, story);
    }
}
