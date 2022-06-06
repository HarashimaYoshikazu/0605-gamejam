using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using GameState;
using UnityEngine.UI;
using DG.Tweening;

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
    [SerializeField]
    AudioSource _audioSource;
    [SerializeField]
    AudioClip[] _audioClips;

    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        //�X�e�[�g�̏�����
        StateProcessor.StateReactiveProperty.Value = StateStart;
        StateStart.EnterAction += StartSetUp;
        StateStart.EnterAction += PlayerController.Instance.FalsePlayer;
        StateStart.EnterAction += GameManager.Instance.ResetGold;
        StateStart.ExitAction += StartExit;

        StateInGame.EnterAction += InGameSetUp;
        StateInGame.EnterAction += StartMusic;
        StateInGame.EnterAction += PlayerController.Instance.ActivePlayer;
        StateInGame.UpdateAction += Timer;
        StateInGame.ExitAction += InGameExit;
        StateInGame.ExitAction += EndMusic;

        StateResult.EnterAction += ResultSetUp;
        StateResult.ExitAction += ResultExit;
        StateResult.ExitAction += OnRetry;


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


    public void StartMusic()
    {
        _audioSource.PlayOneShot(_audioClips[0]);
    }

    public void StartFiever()
    {
        _audioSource.PlayOneShot(_audioClips[1]);
        DOVirtual.DelayedCall(5f, () =>
        {
            _audioSource.Stop();
            _audioSource.PlayOneShot(_audioClips[0]);
        });
        
    }
    public void EndMusic()
    {
        _audioSource.Stop();
    }
    private void Update()
    {
        StateProcessor.Update();
    }

    [SerializeField]
    Text _text;

    [SerializeField]
    Text _timeText;
    void Timer()
    {
        _timer += Time.deltaTime;
        int a = (int)_timer;
        _timeText.text = a.ToString();
        //Debug.Log($"���݂̎���{_timer}");
        if (_timer > _timeUp)
        {
            _text.gameObject.SetActive(true);
            _text.text = "�N���A�F" + GameManager.Instance.Gold + "�~";
            _timer = 0f;
            ChangeState();
        }
    }

    public void OnRetry()
    {
        _text.gameObject.SetActive(false);
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
        if (GameManager.Instance.Gold <= 0)
        {
            _resultPanel?.SetActive(true);
        }

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
