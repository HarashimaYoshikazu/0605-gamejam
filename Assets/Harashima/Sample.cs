using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    UnityEngine.UI.Button _button = null;
    [SerializeField]
    bool isIncrease = true;
    private void Start()
    {
        _button = GetComponent<UnityEngine.UI.Button>();
        _button.onClick.AddListener(() => 
        {
            if (isIncrease)
            {
                GameManager.Instance.ChangeGold(10);
            }
            else
            {
                GameManager.Instance.ChangeGold(-10);
            }
            
        });
    }
}
