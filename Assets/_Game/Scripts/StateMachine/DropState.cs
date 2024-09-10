using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropState : IState
{
    public int[] dem = new int[5];
    public List<Block>[] listBlock = new List<Block>[5];

    private float timer;
    private bool checkSetDestination;
    public void OnEnter(GameManager gM)
    {
        checkSetDestination = false;
    }

    public void OnExecute(GameManager gM)
    {
        bool isCompleted = true;

        timer += Time.deltaTime;

        if (timer >= 0.5f)
        {
            if (!checkSetDestination)
            {
                checkSetDestination = true;

                for (int i = 0; i < 5; i++)
                {
                    listBlock[i] = new List<Block>();
                    dem[i] = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        RaycastHit2D hit = Physics2D.Raycast(new Vector2(i, j), Vector2.zero);
                        if (!hit)
                        {
                            dem[i]++;
                        }
                        else
                        {
                            Block block = hit.collider.gameObject.GetComponent<Block>();
                            block.ExactLocation = new Vector2(i, j - dem[i]);
                            if (dem[i] == 0) block.IsExactLocation = true;
                            else block.IsExactLocation = false;
                            listBlock[i].Add(block);
                        }
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < dem[i]; j++)
                    {
                        Block blockTmp = GameManager.Instantiate(gM.block, gM.blockParent);
                        blockTmp.IsDrag = false;
                        blockTmp.transform.position = new Vector2(i, j + 8);
                        int numberType = Random.Range(gM.minNum, gM.maxNum);
                        blockTmp.NumberText.text = gM.numberSO.listNumber[numberType].number.ToString();
                        blockTmp.GetComponent<SpriteRenderer>().material.color = gM.numberSO.listNumber[numberType].color;
                        blockTmp.Number = numberType;
                        blockTmp.IsExactLocation = false;
                        blockTmp.ExactLocation = new Vector2(i, j + 8 - dem[i]);
                        listBlock[i].Add(blockTmp);
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Block block = listBlock[i][j];
                    if (block.IsExactLocation == false)
                    {
                        block.transform.position = Vector2.MoveTowards(block.transform.position, block.ExactLocation, 0.2f);
                        if (block.transform.position.y - block.ExactLocation.y > 0.01) isCompleted = false;
                    }
                }
            }
            if (isCompleted) gM.ChangeState(new DrawState());
        }

    }

    public void OnExit(GameManager gM)
    {

    }
}
