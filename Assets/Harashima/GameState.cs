using UnityEngine;
using System;
using UniRx;

/// <summary>
/// �L�����N�^�[�̏�ԁi�X�e�[�g�j
/// </summary>
namespace GameState
{
    /// <summary>
    /// �X�e�[�g�̎��s���Ǘ�����N���X
    /// </summary>
    public class StateProcessor
    {
        //�X�e�[�g�{��
        public ReactiveProperty<GameState> StateReactiveProperty { get; set; } = new ReactiveProperty<GameState>();

        //���s�u���b�W
        public void Enter() => StateReactiveProperty.Value.OnEnter();
        public void Update() => StateReactiveProperty.Value.OnUpdate();
        public void Exit() => StateReactiveProperty.Value.OnExit();
    }

    /// <summary>
    /// �X�e�[�g�̃N���X
    /// </summary>
    public abstract class GameState
    {
        //�f���Q�[�g
        public Action EnterAction { get; set; }
        public Action UpdateAction { get; set; }
        public Action ExitAction { get; set; }

        //���s����
        public virtual void OnEnter()
        {
            Debug.Log(this + "OnEnter");
            if(EnterAction != null)
            {
                EnterAction();
            }
            
        }

        public virtual void OnUpdate()
        {
            Debug.Log(this + "OnUpdate");
            if (UpdateAction != null)
            {
                UpdateAction();
            }
            
        }
        public virtual void OnExit()
        {
            Debug.Log( this+"OnExit");
            if (ExitAction != null)
            {
                ExitAction();
            }
            
        }

        //�X�e�[�g�����擾���郁�\�b�h
        public abstract GameState GetState();
    }


    /// <summary>
    /// �Q�[���X�^�[�g
    /// </summary>
    public class GameStart : GameState
    {
        public override GameState GetState()
        {
            return this;
        }
    }

    /// <summary>
    /// �Q�[����
    /// </summary>
    public class InGame : GameState
    {
        public override GameState GetState()
        {
            return this;
        }
    }

    /// <summary>
    /// ���U���g
    /// </summary>
    public class Result : GameState
    {
        public override GameState GetState()
        {
            return this;
        }
    }
}
