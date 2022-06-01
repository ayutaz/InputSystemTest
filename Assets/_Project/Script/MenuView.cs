using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _Project
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] private Button gameEndButton;
        [SerializeField] private Button restartButton;

        public IObservable<Unit> OnGameEndButtonClickAsObservable()
        {
            return gameEndButton.OnClickAsObservable();
        }

        public IObservable<Unit> OnRestartButtonClickAsObservable()
        {
            return restartButton.OnClickAsObservable();
        }

        public void SetView(bool isView)
        {
            gameObject.SetActive(isView);
        }
    }
}