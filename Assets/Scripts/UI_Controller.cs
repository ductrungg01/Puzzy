using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private GameObject home_menu_panel;
    [SerializeField] private GameObject game_screen_panel;
    [SerializeField] private TMP_Text errorText;
    [SerializeField] private GameObject preview_img;
    [SerializeField] private TMP_Text timeRemainText;

    [SerializeField] private GameObject gameover_popup;
    [SerializeField] private GameObject successful_popup;
    
    private float timeRemain = 0;
    private bool isPlaying = false;
    private GameMode mode = GameMode.None;
    
    private void Start()
    {
        GoToMenuScreen();
    }

    private void Update()
    {
        if (isPlaying)
        {
            timeRemain -= Time.deltaTime;
            int foo = (int)timeRemain;
            timeRemainText.text = foo.ToString();

            if (timeRemain < 0)
            {
                ShowGameoverPopup();
            }
        }
    }

    public void ShowSuccessfulPopup()
    {
        successful_popup.SetActive(true);
    }

    public void ShowGameoverPopup()
    {
        gameover_popup.SetActive(true);
    }

    public void GoToGameScreen()
    {
        isPlaying = true;
        SetupTimeRemain();
        home_menu_panel.SetActive(false);
        game_screen_panel.SetActive(true);
        gameover_popup.SetActive(false);
        successful_popup.SetActive(false);
    }

    void SetupTimeRemain()
    {
        switch (mode)
        {
            case GameMode.Easy:
                timeRemain = 60f;
                break;
            case GameMode.Normal:
                timeRemain = 180f;
                break;
            case GameMode.Hard:
                timeRemain = 360f;
                break;
        }
    }

    public void GoToMenuScreen()
    {
        isPlaying = false;
        home_menu_panel.SetActive(true);
        game_screen_panel.SetActive(false);
        gameover_popup.SetActive(false);
        successful_popup.SetActive(false);
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
        this.mode = mode;
        SetupTimeRemain();
        
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

        float spriteWidth = story.width;
        float spriteHeight = story.height;
        Rect rect = new Rect(0, 0, spriteWidth, spriteHeight);
        Sprite sprite = Sprite.Create(story, rect, new Vector2(0.5f, 0.5f));
        
        preview_img.GetComponent<Image>().sprite = sprite;
    }
}
