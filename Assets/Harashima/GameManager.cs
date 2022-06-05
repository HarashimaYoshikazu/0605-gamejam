using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    static private GameManager _instance = new GameManager();
    static public GameManager Instance => _instance;
    private GameManager() { }

    int _gold = 10;

    /// <summary>
    /// お金の値を変化する関数
    /// </summary>
    /// <param name="value">正の値で足され、負の値で減る</param>
    public void ChangeGold(int value)
    {
        _gold += value;
        if(_gold<0)
        {

        }
    }
}
