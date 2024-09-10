using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private Animation anim;
    [SerializeField] private TextMeshProUGUI numberText;
    [SerializeField] private int number;
    private Vector3 exactLocation;
    private bool isExactLocation;

    private bool isDrag;

    public TextMeshProUGUI NumberText { get => numberText; set => numberText = value; }
    public int Number { get => number; set => number = value; }
    public bool IsDrag { get => isDrag; set => isDrag = value; }
    public Vector3 ExactLocation { get => exactLocation; set => exactLocation = value; }
    public bool IsExactLocation { get => isExactLocation; set => isExactLocation = value; }
    public Animation Anim { get => anim; set => anim = value; }
}
