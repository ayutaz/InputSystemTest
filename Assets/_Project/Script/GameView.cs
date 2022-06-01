using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _Project
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private Button sendButton;
        [SerializeField] private TMP_InputField inputField;
        private readonly Subject<string> _onClickSendSubject = new Subject<string>();
        public IObservable<string> OnClickTestButton() => _onClickSendSubject;
        public bool IsInput => inputField.isFocused;

        private void Awake()
        {
            sendButton.OnClickAsObservable()
                .Where(_ => !string.IsNullOrEmpty(inputField.text))
                .Subscribe(_ =>
                {
                    _onClickSendSubject.OnNext(inputField.text);
                    inputField.text = string.Empty;
                })
                .AddTo(this);
        }
    }
}