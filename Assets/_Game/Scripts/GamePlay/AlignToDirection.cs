using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AlignToDirection : MonoBehaviour
{
    public Transform startPoint;
    public Transform EndPoint;
    private void Start()
    {
        Destroy(gameObject, 1.2f);
    }
}
