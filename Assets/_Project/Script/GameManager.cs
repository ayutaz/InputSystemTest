using System;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace _Project
{
    public class GameManager : IInitializable, IStartable, IDisposable, ITickable
    {
        private readonly GameView _gameView;
        private readonly PlayerMove _playerMove;
        private readonly GameInput _gameInput;
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        private GameManager(GameView gameView, GameInput gameInput, PlayerMove playerMove)
        {
            _gameView = gameView;
            _gameInput = gameInput;
            _playerMove = playerMove;
        }

        public void Initialize()
        {
            _gameInput.Enable();
        }

        public void Start()
        {
            _gameView.OnClickTestButton().Subscribe(_ => { Debug.Log("on click test button"); }).AddTo(_disposables);
        }


        public void Dispose()
        {
            _disposables?.Dispose();
        }

        public void Tick()
        {
            var moveValue = _gameInput.Player.Move.ReadValue<Vector2>();
            _playerMove.Move(moveValue);
        }
    }
}