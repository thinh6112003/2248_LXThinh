using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    [SerializeField] private NumberSO numberSO;
    [SerializeField] private LineController lineController;
    [SerializeField] private Transform lineParent;

    private Block currentBlock;
    private Block preBlock;
    private LineController line;
    private int index;
    private int blockCount;

    private List<LineController> lineList = new List<LineController>();
    private List<Block> listDeleteBlock= new List<Block>();

}
