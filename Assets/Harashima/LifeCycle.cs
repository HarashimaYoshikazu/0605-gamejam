using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using GameState;

public class LifeCycle : MonoBehaviour
{
    //雑にSingleton（非推奨）
    static private LifeCycle _instance;
    static public LifeCycle Instance => _instance;

    private GameState.GameState _prevState;

    //ステート
    public StateProcessor StateProcessor { get; set; } = new StateProcessor();
    public GameStart StateStart { get; set; } = new GameStart();
    public InGame StateInGame { get; set; } = new InGame();
    public Result StateResult { get; set; } = new Result();

    /// <summary>タイマー変数</summary>
    float _timer = 0f;
    [SerializeField, Tooltip("制限時間")]
    float _timeUp = 60f;

    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        //ステートの初期化
        StateProcessor.StateReactiveProperty.Value = StateStart;
        StateStart.EnterAction += StartSetUp;
        StateStart.EnterAction += GameManager.Instance.ResetGold;
        StateStart.ExitAction += StartExit;

        StateInGame.EnterAction += InGameSetUp;
        StateInGame.UpdateAction += Timer;
        StateInGame.ExitAction += InGameExit;

        StateResult.EnterAction += ResultSetUp;
        StateResult.ExitAction += ResultExit;
        

        //ステートの値が変更されたら実行処理を行うようにする
        StateProcessor.StateReactiveProperty
            .Where(_ => StateProcessor.StateReactiveProperty.Value.GetState() != _prevState)
            .Subscribe(_ =>
            {
                Debug.Log("Now State:" + StateProcessor.StateReactiveProperty.Value.GetState());
                if (_prevState != null)
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
            _timer = 0f;
            ChangeState();
        }
    }

    [SerializeField]
    GameObject _startPanel = null;
    [SerializeField]
    GameObject _inGameUI = null;
    [SerializeField]
    GameObject _resultPanel = null;

    void StartSetUp()
    {
        Debug.Log("StateがStartに状態遷移しました。");
        _startPanel?.SetActive(true);
    }

    void InGameSetUp()
    {
        Debug.Log("StateがInGameに状態遷移しました。");
        _inGameUI?.SetActive(true);
    }

    void ResultSetUp()
    {
        Debug.Log("StateがResultに状態遷移しました。");
        _resultPanel?.SetActive(true);
    }

    void StartExit()
    {
        _startPanel?.SetActive(false);
    }

    void InGameExit()
    {
        _inGameUI?.SetActive(false);
    }

    void ResultExit()
    {
        _resultPanel?.SetActive(false);
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
