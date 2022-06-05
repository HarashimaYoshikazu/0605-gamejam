using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //雑にSingleton（非推奨）
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

    public void SetGoldText(int startGold,int endGold)
    {
        StartCoroutine(ScoreAnimation(startGold, endGold, 0.8f));
    }
    IEnumerator ScoreAnimation(float startScore, float endScore, float duration)
    {
        // 開始時間
        float startTime = Time.time;

        // 終了時間
        float endTime = startTime + duration;

        do
        {
            // 現在の時間の割合
            float timeRate = (Time.time - startTime) / duration;

            // 数値を更新
            float updateValue = (float)((endScore - startScore) * timeRate + startScore);
            int newvalue = Mathf.FloorToInt(updateValue);
            // テキストの更新
            _goldText.text = "おかね:" + newvalue.ToString("D7");

            // 1フレーム待つ
            yield return null;

        } while (Time.time < endTime);

        // 最終的な着地のスコア
        int newendScore = Mathf.FloorToInt(endScore);
        _goldText.text = "おかね:" + newendScore.ToString("D7");
    }

}
