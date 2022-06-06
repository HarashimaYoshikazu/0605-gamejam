using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    GameObject _panel;

    public void ActivePanel(bool isActive)
    {
        _panel.SetActive(isActive);
    }
}
