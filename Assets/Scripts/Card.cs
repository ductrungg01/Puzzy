using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int x_real = 0;
    public int y_real = 0;
    public int x_curr = 0;
    public int y_curr = 0;
    public bool isBlankCard = false;

    public void Move()
    {
        FindObjectOfType<PlayZone>().RequestToMove(x_curr, y_curr);
    }

    public bool isExtractLocation()
    {
        return (x_curr == x_real && y_real == y_curr);
    }
}
