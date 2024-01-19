using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_StoryButton : MonoBehaviour
{
    [SerializeField] private GameObject border_white;
    [SerializeField] private GameObject border_green;
    [SerializeField] private GameObject selected_icon;

    [SerializeField] private Texture2D textureSrc2d;
    
    private void Start()
    {
        SetAsNotSelected();
    }
    
    public void SetAsSelected()
    {
        FindObjectOfType<StoryController>().SetNotSelectedForAllButton();
        FindObjectOfType<StoryController>().SetSrcTextureStory(textureSrc2d);
        border_white.SetActive(false);
        border_green.SetActive(true);
        selected_icon.SetActive(true);
    }
    
    public void SetAsNotSelected()
    {
        border_white.SetActive(true);
        border_green.SetActive(false);
        selected_icon.SetActive(false);
    }
}
