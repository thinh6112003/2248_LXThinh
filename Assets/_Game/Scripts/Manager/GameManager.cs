using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : Singleton<GameManager>
{
    public Block endBlock;
    public Block block;
    public int gameState;
    public int maxNum;
    public int minNum;
    public int dem;
    public NumberSO numberSO;
    public RectTransform targetRectTransform;
    public Camera mainCamera;
    public Transform blockParent;
    public GameObject outLine;
    public GameObject hammer;
    public GameObject hammerAnim;

    [SerializeField] private Block blockPreview;
    [SerializeField] private LineController lineController;
    [SerializeField] private Transform lineParent;
    [SerializeField] private GameObject popUpScore;
    [SerializeField] private GameObject popUpCombo;
    [SerializeField] private Transform popUpScoreParent;
    [SerializeField] private Transform popUpIncDyamonParent;
    [SerializeField] private Transform canvasForParticleImage;
    [SerializeField] private Transform canvasForCombo;
    [SerializeField] private AlignToDirection mergeParticle;

    private Color endBlockColor;
    private Block blockPreviewInstance;
    private Block currentBlock;
    private Block preBlock;
    private LineController line;
    private int blockCount;
    private List<LineController> lineList = new List<LineController>();
    private List<Block> listDeleteBlock = new List<Block>();

    private IState currentState;

    private int totalScore;

    public int TotalScore { get => totalScore; set => totalScore = value; }
    private void Awake()
    {
        gameState = 0;
        TotalScore = 0;

        //tranh viec nguoi choi cham da diem vao man hinh
        Input.multiTouchEnabled = false;
        //target frame rate ve 60 fps
        Application.targetFrameRate = 60;
        //tranh viec tat man hinh
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //xu tai tho
        int maxScreenHeight = 1280;
        float ratio = (float)Screen.currentResolution.width / (float)Screen.currentResolution.height;
        if (Screen.currentResolution.height > maxScreenHeight)
        {
            Screen.SetResolution(Mathf.RoundToInt(ratio * (float)maxScreenHeight), maxScreenHeight, true);
        }
    }
    private void Start()
    {
        Init();
        ChangeState(new DrawState());
    }
    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }
    public void Init()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Block blockTmp = Instantiate(block, blockParent);
                blockTmp.IsDrag = false;
                blockTmp.transform.position = new Vector2(i, j);
                int numberType = Random.Range(minNum, maxNum);
                blockTmp.NumberText.text = numberSO.listNumber[numberType].number.ToString();
                blockTmp.GetComponent<SpriteRenderer>().material.color = numberSO.listNumber[numberType].color;
                blockTmp.Number = numberType;
            }
        }
    }
    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    public void DrawProces()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        if (hit.collider != null && Input.GetMouseButtonDown(0))
        {

            blockCount++;
            line = Instantiate(lineController, lineParent);
            lineList.Add(line);
            //index = hit.collider.GetComponent<Block>().Number;
            //line.LineRenderer.enabled = true;
            preBlock = hit.collider.GetComponent<Block>();
            preBlock.Anim.Play("MergeBlock");
            listDeleteBlock.Add(preBlock);
            preBlock.IsDrag = true;
            line.LineRenderer.material.color = hit.collider.gameObject.GetComponent<Renderer>().material.color;
            line.LineRenderer.positionCount = 1;
            line.LineRenderer.SetPosition(0, preBlock.transform.position);
            dem += numberSO.listNumber[preBlock.Number].number;
        }

        if (Input.GetMouseButton(0) && blockCount > 0)
        {
            line.LineRenderer.positionCount = 2;
            line.LineRenderer.SetPosition(1, mousePosition);

            if (hit.collider != null && Vector3.Distance(hit.transform.position, line.LineRenderer.GetPosition(0)) > 0.01)
            {
                currentBlock = hit.collider.GetComponent<Block>();

                if (Mathf.Abs(line.LineRenderer.GetPosition(0).x - hit.transform.position.x) < 1.9 && Mathf.Abs(line.LineRenderer.GetPosition(0).y - hit.transform.position.y) < 1.9
                    && currentBlock.IsDrag == false)
                {
                    if (preBlock.Number == hit.collider.GetComponent<Block>().Number)
                    {
                        currentBlock.Anim.Play("MergeBlock");
                        blockCount++;
                        line.LineRenderer.SetPosition(1, currentBlock.transform.position);
                        line = Instantiate(lineController, lineParent);
                        lineList.Add(line);
                        line.LineRenderer.positionCount = 1;
                        line.LineRenderer.SetPosition(0, currentBlock.transform.position);
                        line.LineRenderer.material.color = hit.collider.gameObject.GetComponent<Renderer>().material.color;
                        currentBlock.IsDrag = true;
                        preBlock = currentBlock;
                        listDeleteBlock.Add(preBlock);
                        dem += numberSO.listNumber[preBlock.Number].number;
                        if (blockCount == 2) blockPreviewInstance = Instantiate(blockPreview);
                    }
                    else
                    {
                        if (blockCount >= 2 && preBlock.Number + 1 == currentBlock.Number)
                        {
                            currentBlock.Anim.Play("MergeBlock");
                            blockCount++;
                            line.LineRenderer.SetPosition(1, currentBlock.transform.position);
                            line = Instantiate(lineController, lineParent);
                            lineList.Add(line);
                            line.LineRenderer.positionCount = 1;
                            line.LineRenderer.SetPosition(0, currentBlock.transform.position);
                            line.LineRenderer.material.color = hit.collider.gameObject.GetComponent<Renderer>().material.color;
                            currentBlock.IsDrag = true;
                            preBlock = currentBlock;
                            listDeleteBlock.Add(preBlock);
                            dem += numberSO.listNumber[preBlock.Number].number;
                            if (blockCount == 2) blockPreviewInstance = Instantiate(blockPreview);
                        }
                    }
                }
                else
                {
                    if (lineList.Count >= 2 && currentBlock.IsDrag == true && Mathf.Abs(line.LineRenderer.GetPosition(0).x - hit.transform.position.x) < 1.9
                        && Mathf.Abs(line.LineRenderer.GetPosition(0).y - hit.transform.position.y) < 1.9 && Vector3.Distance(hit.transform.position, lineList[lineList.Count - 2].LineRenderer.GetPosition(0)) < 0.1)
                    {
                        dem -= numberSO.listNumber[listDeleteBlock[ listDeleteBlock.Count - 1].Number].number;
                        Destroy(lineList[lineList.Count - 1].gameObject);
                        Destroy(lineList[lineList.Count - 2].gameObject);
                        listDeleteBlock.RemoveAt(listDeleteBlock.Count - 1);
                        lineList.RemoveAt(lineList.Count - 1);
                        lineList.RemoveAt(lineList.Count - 1);
                        blockCount--;
                        line = Instantiate(lineController, lineParent);
                        lineList.Add(line);
                        line.LineRenderer.positionCount = 1;
                        line.LineRenderer.SetPosition(0, currentBlock.transform.position);
                        line.LineRenderer.material.color = hit.collider.gameObject.GetComponent<Renderer>().material.color;
                        preBlock.IsDrag = false;
                        preBlock = currentBlock;
                        if (blockCount == 1) Destroy(blockPreviewInstance.gameObject); ;
                    }
                }
                if (blockCount >= 2)
                {
                    blockPreviewInstance.NumberText.text = numberSO.listNumber[ScoreCaculate()].number.ToString();
                    blockPreviewInstance.GetComponent<SpriteRenderer>().material.color = numberSO.listNumber[ScoreCaculate()].color;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (blockCount > 0)
            {
                listDeleteBlock[blockCount -1].IsDrag = false;
                if (blockCount >= 2)
                {                    
                    endBlockColor = listDeleteBlock[blockCount - 1].GetComponent<SpriteRenderer>().material.color;
                    endBlock= listDeleteBlock[blockCount - 1];
                    endBlock.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
                    endBlock.gameObject.GetComponentInChildren<Canvas>().sortingOrder = 11;
                    listDeleteBlock[blockCount -1].Number= ScoreCaculate();
                    if(listDeleteBlock[blockCount - 1].Number> DataManager.Instance.dataDynamic.CurrentHighBlock)
                    {
                        DataManager.Instance.dataDynamic.CurrentHighBlock = listDeleteBlock[blockCount - 1].Number;
                    }
                    TotalScore += numberSO.listNumber[ScoreCaculate()].number;
                    if (totalScore > DataManager.Instance.dataDynamic.CurrentHighScore) DataManager.Instance.dataDynamic.CurrentHighScore = totalScore;
                    UIManager.Instance.UpdateTotalScore();
                    PopUpIncScore(numberSO.listNumber[ScoreCaculate()].number, blockCount, listDeleteBlock[blockCount - 1].transform);
                }
                Vector3 endpos = listDeleteBlock[blockCount - 1].transform.position;
                for (int i = lineList.Count - 1; i >= 0; i--)
                {
                    Destroy(lineList[i].gameObject);
                    lineList.RemoveAt(i);
                    if (i != blockCount - 1)
                    {   
                        AlignToDirection t = Instantiate(mergeParticle, canvasForParticleImage);
                        t.startPoint.position = listDeleteBlock[i].transform.position;
                        t.EndPoint.position = endpos;
                        Destroy(listDeleteBlock[i].gameObject);
                        listDeleteBlock.RemoveAt(i);
                    }
                }
                if(blockPreviewInstance!= null) Destroy(blockPreviewInstance.gameObject);
            }
            listDeleteBlock.Clear();
            lineList.Clear();

            if(blockCount>= 2) ChangeState(new MergeState());
            blockCount = 0;
        }
    }
    private void PopUpIncScore(int score, int count, Transform currentBlock)
    {
        if(count>=6)
        {
            
            GameObject x = Instantiate(popUpCombo,canvasForCombo);
            Vector3 offset =new Vector2(0, 0) ;
            if (currentBlock.transform.position.x <= 1) offset = new Vector2(1, 0);
            if (currentBlock.transform.position.x >= 4) offset = new Vector2(-1, 0);
            x.transform.position = currentBlock.position+ offset;
            x.GetComponent<TextMeshProUGUI>().text = "Combo X" + count;
            GameObject y = Instantiate(popUpScore, popUpIncDyamonParent);
            y.transform.localPosition = new Vector3(60, 87 , 0);
            y.GetComponent<TextMeshProUGUI>().text = "+1" ;
            DataManager.Instance.dataDynamic.CurrentDynament++;
            UIManager.Instance.UpdateScoreDyamon();
        }
        GameObject t= Instantiate(popUpScore, popUpScoreParent);
        t.transform.localPosition = new Vector3(125, 35, 0);
        t.GetComponent<TextMeshProUGUI>().text = "+" + score.ToString();
    }
    private int ScoreCaculate()
    {
        int ScoreTMP = 4;
        int demtmp = 1;
        while(ScoreTMP < dem)
        {
            ScoreTMP *= 2;
            demtmp++;
        }
        return demtmp;
    }
}
