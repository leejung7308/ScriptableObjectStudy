using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public VoidEventChannelSO gameStart;
    public Vector2EventChannelSO gameOver;

    public Transform rockParent;
    public Transform scissorParent;
    public Transform paperParent;

    public Button gameStartBtn;

    private void Update()
    {
        CheckEndGame();
    }

    public void StartGame()
    {
        gameStart.RaiseEvent();
        gameStartBtn.gameObject.SetActive(false);
    }

    public void CheckEndGame()
    {
        if (rockParent.childCount != 0 && scissorParent.childCount == 0 && paperParent.childCount == 0)
        {
            gameOver.RaiseEvent(rockParent.GetChild(0).position);
        }
        else if (rockParent.childCount == 0 && scissorParent.childCount != 0 && paperParent.childCount == 0)
        {
            gameOver.RaiseEvent(scissorParent.GetChild(0).position);
        }
        else if (rockParent.childCount == 0 && scissorParent.childCount == 0 && paperParent.childCount != 0)
        {
            gameOver.RaiseEvent(paperParent.GetChild(0).position);
        }
    }
}
