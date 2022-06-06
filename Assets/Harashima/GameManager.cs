using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager:MonoBehaviour
{
    static private GameManager _instance;
    static public GameManager Instance => _instance;
    private GameManager() { }

    int _initGold = 50;
    public int Gold => _gold;
    int _gold = 0;

    private void Awake()
    {
        if (_instance ==null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject) ;
        }
        
    }
    private void Update()
    {
        Debug.Log(_instance);
    }
    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }

    /// <summary>
    /// �����̒l��ω�����֐�
    /// </summary>
    /// <param name="value">���̒l�ő�����A���̒l�Ō���</param>
    public void ChangeGold(int value)
    {
        UIManager.Instance.SetGoldText(_gold,_gold+ value);
        _gold += value;
        
        if(_gold<=0)
        {
            LifeCycle.Instance.ChangeState();
        }
    }

    public void ResetGold()
    {
        UIManager.Instance.SetGoldText(_gold,_initGold);
        _gold = _initGold;
        
    }
}
