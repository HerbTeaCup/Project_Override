using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObject : MonoBehaviour
{
    Canvas _canvas;

    private void Start()
    {
        _canvas = GetComponent<Canvas>();
    }
    public void Pop(int value)
    {
        if (_canvas == null)
        {
            _canvas = GetComponent<Canvas>();
        }
        _canvas.sortingOrder = value;
    }
    public void Push()
    {
        if (_canvas == null)
        {
            _canvas = GetComponent<Canvas>();
        }
        _canvas.sortingOrder = -1;
    }
}
