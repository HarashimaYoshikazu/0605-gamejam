using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WinText : MonoBehaviour
{
    Text _text = null;
    [SerializeField]
    Color[] _colors ;
    private void Start()
    {
        _text = GetComponent<Text>();
    }
    private void Update()
    {
        foreach(var i in _colors)
        {
            _text.color = i;
        }
    }
}
