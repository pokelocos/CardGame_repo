using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using CardGame;

namespace GemCardGame
{
    public class BehaviourCard : MonoBehaviour, IDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public CardData cardInfo;

        static float lerpSpeed = 10;

        private void Awake()
        {
            this.gameObject.SetActive(false);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Vector3.Lerp(transform.position, eventData.position, lerpSpeed * Time.deltaTime);
        }

        public void OnDrop(PointerEventData eventData)
        {
            
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public void Use()
        {
            throw new System.NotImplementedException();
        }
    }

}
