using UnityEngine;
using System;
using UniRx;

/// <summary>
/// キャラクターの状態（ステート）
/// </summary>
namespace GameState
{
    /// <summary>
    /// ステートの実行を管理するクラス
    /// </summary>
    public class StateProcessor
    {
        //ステート本体
        public ReactiveProperty<GameState> StateReactiveProperty { get; set; } = new ReactiveProperty<GameState>();

        //実行ブリッジ
        public void Enter() => StateReactiveProperty.Value.OnEnter();
        public void Update() => StateReactiveProperty.Value.OnUpdate();
        public void Exit() => StateReactiveProperty.Value.OnExit();
    }

    /// <summary>
    /// ステートのクラス
    /// </summary>
    public abstract class GameState
    {
        //デリゲート
        public Action EnterAction { get; set; }
        public Action UpdateAction { get; set; }
        public Action ExitAction { get; set; }

        //実行処理
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

        //ステート名を取得するメソッド
        public abstract GameState GetState();
    }


    /// <summary>
    /// ゲームスタート
    /// </summary>
    public class GameStart : GameState
    {
        public override GameState GetState()
        {
            return this;
        }
    }

    /// <summary>
    /// ゲーム中
    /// </summary>
    public class InGame : GameState
    {
        public override GameState GetState()
        {
            return this;
        }
    }

    /// <summary>
    /// リザルト
    /// </summary>
    public class Result : GameState
    {
        public override GameState GetState()
        {
            return this;
        }
    }
}
