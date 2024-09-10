using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerState : IState
{
    int count;
    float timer;
    Block block;
    Vector3 hammerBeginPos;
    Vector3 hammerEndPos;
    GameObject hammer;
    GameObject outLine;
    GameObject hammerAnim;
    float startTime;
    private float length;
    float speed;
    bool check, checkBlock;
    public void OnEnter(GameManager gM)
    {
        count = 0;
        speed = 10;
        hammerBeginPos = new Vector3(0.300999999f, -1.36199999f, 0);
        check = false;
        checkBlock = false;
    }

    public void OnExecute(GameManager gM)
    {
        if (count < 1)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit)
                {
                    outLine = GameManager.Instantiate(gM.outLine);
                    outLine.transform.position = hit.collider.transform.position;
                    count++;
                    block = hit.collider.GetComponent<Block>();
                    hammer = GameManager.Instantiate(gM.hammer);
                    hammer.transform.position = hammerBeginPos;
                    hammerEndPos = hit.collider.transform.position;
                    startTime = Time.time;
                    length = Vector2.Distance(hammerEndPos, hammerBeginPos);
                }
            }
        }
        else
        {
            if (!check)
            {
                check = Move(hammer.transform, length, hammerBeginPos, hammerEndPos);
                if (check)
                {
                    GameManager.Destroy(hammer);
                    hammerAnim = GameManager.Instantiate(gM.hammerAnim);
                    hammerAnim.transform.position = hammerEndPos;
                    timer = 0;
                }
            }
            else
            {
                timer+=Time.deltaTime;
                if (timer >= 0.5f&& !checkBlock)
                {
                    checkBlock = true;
                    GameManager.Destroy(block.gameObject);
                    GameManager.Destroy(outLine);
                }

                if (timer >= 0.7f) gM.ChangeState(new DropState());
            }
        }
    }

    public void OnExit(GameManager gM)
    {
        GameManager.Destroy(hammerAnim);
        UIManager.Instance.TurnOnBottonButtons();
    }
    bool Move(Transform tr, float length, Vector3 startPosition, Vector3 endPosition)
    {
        float journeyTime = Time.time - startTime;
        float t = Mathf.Clamp01(journeyTime / length * speed);
        tr.position = Vector3.Lerp(startPosition, endPosition, t);
        if (t >= 1.0f)
        {
            return true;
        }
        return false;
    }
}
