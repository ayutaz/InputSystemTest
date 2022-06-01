using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _Project
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private Button testButton;
        [SerializeField] private TMP_InputField inputField;

        public string InputMessage()
        {
            return inputField.text;
        }

        public IObservable<Unit> OnClickTestButton() => testButton.OnClickAsObservable();
    }
}