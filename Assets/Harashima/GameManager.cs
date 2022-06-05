using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    static private GameManager _instance = new GameManager();
    static public GameManager Instance => _instance;
    private GameManager() { }

    int _initGold = 10;
    int _gold = 0;

    /// <summary>
    /// お金の値を変化する関数
    /// </summary>
    /// <param name="value">正の値で足され、負の値で減る</param>
    public void ChangeGold(int value)
    {
        UIManager.Instance.SetGoldText(_gold,_gold+ value);
        _gold += value;
        
        if(_gold<0)
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
