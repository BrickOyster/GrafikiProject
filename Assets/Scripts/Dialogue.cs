using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    public string Name;

    [TextArea(3, 5)]
    public string[] sentences;

    public Sprite Image;
}