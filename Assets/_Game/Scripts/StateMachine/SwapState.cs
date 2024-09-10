using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapState : IState
{
    int count;
    List<GameObject> outline;
    List<Block> block;
    float length1, length2;
    Vector3 startpoint1, startpoint2;
    Vector3 endPoint1, endPoint2;
    float startTime;
    float speed;
    public void OnEnter(GameManager gM)
    {
        count = 0;
        outline = new List<GameObject>();
        block = new List<Block>();
        speed = 7f;
    }

    public void OnExecute(GameManager gM)
    {
        if(count<2)
        {
            if (Input.GetMouseButtonDown(0)|| Input.GetMouseButtonDown(1))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit)
                {
                    GameObject t= GameManager.Instantiate(gM.outLine);
                    t.transform.position = hit.collider.transform.position;
                    outline.Add(t);
                    block.Add(hit.collider.GetComponent<Block>());
                    count++;
                    if (count == 2)
                    {
                        block[1].ExactLocation = block[0].transform.position;
                        block[0].ExactLocation = block[1].transform.position;
                        block[0].GetComponent<SpriteRenderer>().sortingOrder = 3;
                        block[1].GetComponent<SpriteRenderer>().sortingOrder = 3;
                        startTime = Time.time;
                        startpoint1 = block[0].ExactLocation;
                        startpoint2 = block[1].ExactLocation;
                        endPoint1 = block[0].transform.position;
                        endPoint2 = block[1].transform.position;
                        length1 = Vector2.Distance(startpoint1,endPoint1);
                        length2 = Vector2.Distance(startpoint2,endPoint2);
                    }
                }
            }
        }
        else
        {
            Transform trans1 = block[0].transform;
            Transform trans2 = block[1].transform;
            bool check = true;
            check= Move(trans1, length1, startpoint1, endPoint1, gM);
            check= Move(trans2, length2, startpoint2, endPoint2, gM);
            if (check) gM.ChangeState(new DropState());
        }
    }

    public void OnExit(GameManager gM)
    {
        block[0].transform.position = block[0].ExactLocation;
        block[1].transform.position = block[1].ExactLocation;
        UIManager.Instance.TurnOnBottonButtons();
        GameManager.Destroy(outline[0]);
        GameManager.Destroy(outline[1]);
    }
    bool Move(Transform tr, float length, Vector3 startPosition, Vector3 endPosition, GameManager gM)
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
