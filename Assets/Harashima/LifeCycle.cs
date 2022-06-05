using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using GameState;

public class LifeCycle : MonoBehaviour
{
    //�G��Singleton�i�񐄏��j
    static private LifeCycle _instance;
    static public LifeCycle Instance => _instance;

    private GameState.GameState _prevState;

    //�X�e�[�g
    public StateProcessor StateProcessor { get; set; } = new StateProcessor();
    public GameStart StateStart { get; set; } = new GameStart();
    public InGame StateInGame { get; set; } = new InGame();
    public Result StateResult { get; set; } = new Result();

    /// <summary>�^�C�}�[�ϐ�</summary>
    float _timer = 0f;
    [SerializeField, Tooltip("��������")]
    float _timeUp = 60f;

    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        //�X�e�[�g�̏�����
        StateProcessor.StateReactiveProperty.Value = StateStart;
        StateStart.EnterAction += StartSetUp;
        StateStart.EnterAction += GameManager.Instance.ResetGold;
        StateStart.ExitAction += StartExit;

        StateInGame.EnterAction += InGameSetUp;
        StateInGame.UpdateAction += Timer;
        StateInGame.ExitAction += InGameExit;

        StateResult.EnterAction += ResultSetUp;
        StateResult.ExitAction += ResultExit;
        

        //�X�e�[�g�̒l���ύX���ꂽ����s�������s���悤�ɂ���
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
        Debug.Log($"���݂̎���{_timer}");
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
        Debug.Log("State��Start�ɏ�ԑJ�ڂ��܂����B");
        _startPanel?.SetActive(true);
    }

    void InGameSetUp()
    {
        Debug.Log("State��InGame�ɏ�ԑJ�ڂ��܂����B");
        _inGameUI?.SetActive(true);
    }

    void ResultSetUp()
    {
        Debug.Log("State��Result�ɏ�ԑJ�ڂ��܂����B");
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
