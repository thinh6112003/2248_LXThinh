using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawState : IState
{
    public void OnEnter(GameManager gM)
    {
        gM.gameState = 1;
        gM.dem = 0;
    }

    public void OnExecute(GameManager gM)
    {
        gM.DrawProces();
    }

    public void OnExit(GameManager gM)
    {
        gM.gameState = 0;
    }
}
