using System;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace _Project
{
    public class GameManager : IStartable, IDisposable
    {
        private readonly GameView _gameView;
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        private GameManager(GameView gameView)
        {
            _gameView = gameView;
        }

        public void Start()
        {
            _gameView.OnClickTestButton().Subscribe(_ => { Debug.Log("on click test button"); }).AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }
    }
}