using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void OnEnter(GameManager gM);
    void OnExecute(GameManager gM);
    void OnExit(GameManager gM);
}
