using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private GameObject home_menu_panel;
    [SerializeField] private GameObject game_screen_panel;
    [SerializeField] private TMP_Text errorText;

    public void GoToGameScreen()
    {
        home_menu_panel.SetActive(false);
        game_screen_panel.SetActive(true);
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
}
