using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeController : MonoBehaviour
{
    [SerializeField] private List<GameObject> gamemodeBtns = new List<GameObject>();
    
    public void SetNotSelectedForAllButton()
    {
        foreach (GameObject btn in gamemodeBtns)
        {
            btn.GetComponent<UI_GameModeButton>().SetNotSelected();
        }
    }
}
