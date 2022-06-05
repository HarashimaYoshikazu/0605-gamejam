using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //�G��Singleton�i�񐄏��j
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
        // �J�n����
        float startTime = Time.time;

        // �I������
        float endTime = startTime + duration;

        do
        {
            // ���݂̎��Ԃ̊���
            float timeRate = (Time.time - startTime) / duration;

            // ���l���X�V
            float updateValue = (float)((endScore - startScore) * timeRate + startScore);
            int newvalue = Mathf.FloorToInt(updateValue);
            // �e�L�X�g�̍X�V
            _goldText.text = "������:" + newvalue.ToString("D7");

            // 1�t���[���҂�
            yield return null;

        } while (Time.time < endTime);

        // �ŏI�I�Ȓ��n�̃X�R�A
        int newendScore = Mathf.FloorToInt(endScore);
        _goldText.text = "������:" + newendScore.ToString("D7");
    }

}
