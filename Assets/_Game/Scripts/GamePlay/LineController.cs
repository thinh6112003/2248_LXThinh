using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;

    public LineRenderer LineRenderer { get => lineRenderer; set => lineRenderer = value; }
    //[SerializeField] private NumberSO numberSO;

    //private Block block;
    //private Block firstBlock;

    //private int index;

    //private void Update()
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    //    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    mousePosition.z = 0;
    //    if (hit.collider != null && Input.GetMouseButtonDown(0))
    //    {
    //        index = hit.collider.GetComponent<Block>().Number;
    //        lineRenderer.enabled = true;
    //        firstBlock = hit.collider.GetComponent<Block>();
    //        Debug.Log(hit.collider.gameObject.name);
    //        lineRenderer.SetPosition(0, firstBlock.transform.position);
    //        lineRenderer.material.color = hit.collider.gameObject.GetComponent<Renderer>().material.color;
    //    }

    //    if (Input.GetMouseButton(0))
    //    {
    //        lineRenderer.enabled = true;
    //        lineRenderer.SetPosition(1, mousePosition);

    //        if(hit.collider!= null && Vector3.Distance( hit.transform.position,lineRenderer.GetPosition(0))>0.01)
    //        {
    //            Debug.Log(1);
    //            if (Mathf.Abs(lineRenderer.GetPosition(0).x - hit.transform.position.x) < 1.9 && Mathf.Abs(lineRenderer.GetPosition(0).y - hit.transform.position.y) < 1.9
    //                && firstBlock.Number== hit.collider.GetComponent<Block>().Number) 
    //            { 
    //                block = hit.collider.GetComponent<Block>();
    //                lineRenderer.SetPosition(1, block.transform.position);  

    //            }
    //        }
    //    }

    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        lineRenderer.enabled = false;
    //        Debug.Log("insdie");

    //        //if (Mathf.Abs(lineRenderer.GetPosition(0).x - hit.transform.position.x) < 1.9 && Mathf.Abs(lineRenderer.GetPosition(0).y - hit.transform.position.y) < 1.9)
    //        //{
    //        //    if (hit.collider != null && Vector3.Distance(firstBlock.transform.position, hit.transform.position) > 0.1f)
    //        //    {
    //        //        index++;
    //        //        Destroy(firstBlock.gameObject);
    //        //        block.NumberText.text = numberSO.listNumber[index].number.ToString();
    //        //        block.GetComponent<SpriteRenderer>().material.color = numberSO.listNumber[index].color;
    //        //    }
    //        //}
    //    }


    //}
}
