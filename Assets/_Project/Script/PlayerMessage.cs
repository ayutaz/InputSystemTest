using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project
{
    public class PlayerMessage : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI message;
        [SerializeField] private Image messageImage;

        public async void SetMessage(string content)
        {
            gameObject.SetActive(true);
            messageImage.DOFade(1f, 0.1f);
            await message.DOFade(1f, 0.1f);
            message.text = content;
            await UniTask.Delay(TimeSpan.FromSeconds(3f));
            messageImage.DOFade(0f, 0f);
            await message.DOFade(0f, 0f);
            message.text = string.Empty;
            gameObject.SetActive(false);
        }
    }
}