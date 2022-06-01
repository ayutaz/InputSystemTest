using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _Project
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private Button testButton;

        public IObservable<Unit> OnClickTestButton() => testButton.OnClickAsObservable();
    }
}