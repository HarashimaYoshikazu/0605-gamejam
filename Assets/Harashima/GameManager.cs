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
    /// �����̒l��ω�����֐�
    /// </summary>
    /// <param name="value">���̒l�ő�����A���̒l�Ō���</param>
    public void ChangeGold(int value)
    {
        _gold += value;
        if(_gold<0)
        {

        }
    }
}
