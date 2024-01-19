using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeController : MonoBehaviour
{
    [SerializeField] private List<GameObject> gamemodeBtns = new List<GameObject>();

    private GameMode gameMode = GameMode.None;
    
    public void SetNotSelectedForAllButton()
    {
        foreach (GameObject btn in gamemodeBtns)
        {
            btn.GetComponent<UI_GameModeButton>().SetNotSelected();
        }
    }

    public void SetGameMode(GameMode mode)
    {
        this.gameMode = mode;
    }

    public GameMode GetGameMode()
    {
        return this.gameMode;
    }
}
