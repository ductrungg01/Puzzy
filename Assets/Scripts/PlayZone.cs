using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayZone : MonoBehaviour
{
    [SerializeField] private GameObject card;
    
    [SerializeField] GridLayoutGroup layout;

    private List<GameObject> cards = new List<GameObject>();
    private int row = 0;

    public void Initalize(int numOfRow, int imgSize, Texture2D sourceTexture)
    {
        layout.cellSize = new Vector2(imgSize, imgSize);
        layout.constraintCount = numOfRow;

        this.row = numOfRow;

        int spriteWidth = sourceTexture.width / numOfRow;
        int spriteHeight = sourceTexture.height / numOfRow;

        int row_index = 0;
        
        for (int i = numOfRow - 1; i >= 0; i--)
        {
            for (int j = 0; j < numOfRow; j++)
            {
                Rect rect = new Rect(j * spriteWidth, i * spriteHeight, spriteWidth, spriteHeight);
                Sprite sprite = Sprite.Create(sourceTexture, rect, new Vector2(0.5f, 0.5f));
                
                GameObject go = Instantiate(card);
                go.name = $"Card {row_index}, {j}";

                Card card_comp = go.GetComponent<Card>();
                card_comp.x_real = row_index;
                card_comp.y_real = j;

                if (!(row_index == row - 1 && j == row - 1))
                {
                    go.GetComponent<Image>().sprite = sprite;
                }
                else
                {
                    go.GetComponent<Card>().isBlankCard = true;
                }
                
                cards.Add(go);
            }

            row_index++;
        }

        SetRandomLocationForCard();
        DrawToPlayZone();
    }

    void SetRandomLocationForCard()
    {
        List<bool> isUsed = new List<bool>();
        for (int i = 0; i < row * row; i++) isUsed.Add(false);
        
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < row; j++)
            {
                bool isOk = false;
                while (!isOk)
                {
                    int index = Random.Range(0, row * row);
                    if (!isUsed[index])
                    {
                        isUsed[index] = true;
                        isOk = true;
                        GameObject go = cards[index];
                        Card card_comp = go.GetComponent<Card>();
                        card_comp.x_curr = i;
                        card_comp.y_curr = j;
                    }
                }
            }
        }
    }

    GameObject GetCardAt(int x, int y)
    {
        foreach (GameObject go in cards)
        {
            Card card = go.GetComponent<Card>();
            if (card.x_curr == x && card.y_curr == y)
            {
                return go;
            }
        }

        return null;
    }
    
    void DestroyAllChildren()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    
    void DrawToPlayZone()
    {
        DestroyAllChildren();
        
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < row; j++)
            {
                GameObject cardIns = GetCardAt(i, j);
                Instantiate(cardIns, this.gameObject.transform);
            }
        }

        CheckIsAnswer();
    }

    void CheckIsAnswer()
    {
        bool isAnswer = true;
        
        foreach (GameObject go in cards)
        {
            Card card = go.GetComponent<Card>();
            if (card.isExtractLocation() == false)
            {
                isAnswer = false;
                break;
            }
        }

        if (isAnswer)
        {
            SuccessfulSequence();
        }
    }

    void SuccessfulSequence()
    {
        FindObjectOfType<UI_Controller>().ShowSuccessfulPopup();
    }

    void Move(int x, int y)
    {
        GameObject cardNeedToMove = GetCardAt(x, y);
        GameObject blankCard = GetBlankCard();

        Card card_comp = cardNeedToMove.GetComponent<Card>();
        Card blank_card_comp = blankCard.GetComponent<Card>();
        
        Swap(ref card_comp.x_curr, ref blank_card_comp.x_curr);   
        Swap(ref card_comp.y_curr, ref blank_card_comp.y_curr);   
        
        DrawToPlayZone();
    }
    
    void Swap<T>(ref T first, ref T second)
    {
        T temp = first;
        first = second;
        second = temp;
    }
    
    public void RequestToMove(int x, int y)
    {
        if (isBesideBlankCard(x, y))
        {
            Move(x, y);    
        }
        else
        {
            Debug.Log("Not beside the blank card");
        }
    }

    GameObject GetBlankCard()
    {
        foreach (GameObject go in cards)
        {
            if (go.GetComponent<Card>().isBlankCard)
            {
                return go;
            }
        }

        return null;
    }

    bool isBeside(int x1, int y1, int x2, int y2)
    {
        return (Math.Abs(x1 - x2) + Math.Abs(y1 - y2)) == 1;
    }
    
    bool isBesideBlankCard(int x, int y)
    {
        GameObject blankCard = GetBlankCard();

        Card blankCardComp = blankCard.GetComponent<Card>();
        
        Debug.Log($"BlankCard: {blankCardComp.x_curr} {blankCardComp.y_curr} | Curr card {x} {y}");

        bool foo = isBeside(blankCardComp.x_curr, blankCardComp.y_curr, x, y);
        return foo;
    }
}
