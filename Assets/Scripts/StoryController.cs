using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    [SerializeField] private List<GameObject> storyBtns = new List<GameObject>();

    private Texture2D srcTextureStory = null;
    
    public void SetNotSelectedForAllButton()
    {
        foreach (GameObject btn in storyBtns)
        {
            btn.GetComponent<UI_StoryButton>().SetAsNotSelected();
        }
    }

    public void SetSrcTextureStory(Texture2D texture2D)
    {
        Debug.Log(texture2D.name);
        srcTextureStory = texture2D;
    }

    public Texture2D GetSrcTextureStory()
    {
        return this.srcTextureStory;
    }
}
