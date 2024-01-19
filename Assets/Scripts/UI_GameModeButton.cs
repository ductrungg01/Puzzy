using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameModeButton : MonoBehaviour
{
    [SerializeField] private GameObject SelectedIcon;

    public void SetNotSelected()
    {
        SelectedIcon.SetActive(false);
    }
}
