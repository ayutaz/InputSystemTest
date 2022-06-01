using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project
{
    public class SelectObject : MonoBehaviour, IPointerClickHandler
    {
        private readonly Subject<string> _onClickSubject = new Subject<string>();
        public IObservable<string> OnClickAsObservable() => _onClickSubject;

        public void OnPointerClick(PointerEventData eventData)
        {
            var objectName = eventData.pointerEnter.name;
            _onClickSubject.OnNext(SendClickObjectMessage(objectName));
        }

        private static string SendClickObjectMessage(string objectName)
        {
            return $"Select {objectName}!";
        }
    }
}