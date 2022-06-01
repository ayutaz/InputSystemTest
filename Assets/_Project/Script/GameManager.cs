using System;
using UniRx;
using UnityEditor;
using UnityEngine;
using VContainer.Unity;

namespace _Project
{
    public class GameManager : IInitializable, IStartable, IDisposable, ITickable
    {
        private readonly GameView _gameView;
        private readonly MenuView _menuView;
        private readonly PlayerMove _playerMove;
        private readonly GameInput _gameInput;
        private readonly CompositeDisposable _disposables = new CompositeDisposable();
        private bool _isOpenMenu = false;

        private GameManager(GameView gameView, GameInput gameInput, PlayerMove playerMove, MenuView menuView)
        {
            _menuView = menuView;
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
            _gameView.OnClickTestButton().Subscribe(message => { Debug.Log($"{message}"); }).AddTo(_disposables);

            _menuView.OnRestartButtonClickAsObservable().Subscribe(_ =>
            {
                //todo リスタート処理
            }).AddTo(_disposables);

            _menuView.OnGameEndButtonClickAsObservable().Subscribe(_ =>
            {
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }).AddTo(_disposables);
        }


        public void Dispose()
        {
            _disposables?.Dispose();
        }

        public void Tick()
        {
            if (!_gameView.IsInput)
            {
                var moveValue = _gameInput.Player.Move.ReadValue<Vector2>();
                _playerMove.Move(moveValue);
            }

            if (_gameInput.Player.Menu.WasPressedThisFrame())
            {
                Debug.Log("Menu");
                _isOpenMenu = !_isOpenMenu;
                _menuView.SetView(_isOpenMenu);
            }

            SwitchPlayerInput(_isOpenMenu);
        }

        private void SwitchPlayerInput(bool isMenuMode)
        {
            if (isMenuMode)
            {
                _gameInput.Player.Disable();
            }
            else
            {
                _gameInput.Player.Enable();
            }
        }
    }
}