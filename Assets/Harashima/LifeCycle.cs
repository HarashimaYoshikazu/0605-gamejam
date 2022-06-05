using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using GameState;

public class LifeCycle : MonoBehaviour
{
    private GameState.GameState _prevState;

    //ステート
    public StateProcessor StateProcessor { get; set; } = new StateProcessor();
    public GameStart StateStart { get; set; } = new GameStart();
    public InGame StateInGame { get; set; } = new InGame();
    public Result StateResult { get; set; } = new Result();

    /// <summary>タイマー変数</summary>
    float _timer = 0f;
    [SerializeField,Tooltip("制限時間")]
    float _timeUp = 60f;

    void Start()
    {
        //ステートの初期化
        StateProcessor.StateReactiveProperty.Value = StateStart;
        StateStart.EnterAction += StartDebug;
        StateInGame.EnterAction += InGameDebug;
        StateResult.EnterAction += ResultDebug;
        StateInGame.UpdateAction += Timer;

        //ステートの値が変更されたら実行処理を行うようにする
        StateProcessor.StateReactiveProperty
            .Where(_ => StateProcessor.StateReactiveProperty.Value.GetState() != _prevState)
            .Subscribe(_ =>
            {
                Debug.Log("Now State:" + StateProcessor.StateReactiveProperty.Value.GetState());
                if(_prevState != null)
                {
                    _prevState.OnExit();
                }
                
                _prevState = StateProcessor.StateReactiveProperty.Value.GetState();
                StateProcessor.Enter();
            })
            .AddTo(this);
    }

    private void Update()
    {
        StateProcessor.Update();
    }

    void Timer()
    {
        _timer += Time.deltaTime;
        Debug.Log($"現在の時間{_timer}");
        if (_timer > _timeUp)
        {
            ChangeState();
        }
    }

    public void StartDebug()
    {
        Debug.Log("StateがStartに状態遷移しました。");
    }

    public void InGameDebug()
    {
        Debug.Log("StateがInGameに状態遷移しました。");
    }

    public void ResultDebug()
    {
        Debug.Log("StateがResultに状態遷移しました。");
    }
    public void ChangeState()
    {
        switch (StateProcessor.StateReactiveProperty.Value)
        {
            case GameState.GameStart:
                StateProcessor.StateReactiveProperty.Value = StateInGame;
                break;
            case GameState.InGame:
                StateProcessor.StateReactiveProperty.Value = StateResult;
                break;
            case GameState.Result:
                StateProcessor.StateReactiveProperty.Value = StateStart;
                break;
        }
    }
}
