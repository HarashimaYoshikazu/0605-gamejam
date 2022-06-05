using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //ŽG‚ÉSingletoni”ñ„§j
    static private UIManager _instance;
    static public UIManager Instance => _instance;

    [SerializeField]
    Text _goldText = null;
    private void Awake()
    {
        _instance = this;
        if (!_goldText)
        {
            _goldText = GetComponent<Text>();
        }
    }

    public void SetGoldText(int value)
    {
        _goldText.text = value.ToString();
    }

}
