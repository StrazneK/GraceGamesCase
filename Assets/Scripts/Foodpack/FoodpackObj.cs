using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Foodpack
{
    [RequireComponent(typeof(Rigidbody))]
    public class FoodpackObj : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] MeshRenderer mRenderer;
        public FoodpackSO foodpackSO;
        private void Start()
        {
            mRenderer = GetComponent<MeshRenderer>();
        }
        public void OnPointerDown(PointerEventData eventData) //Give yellow outline and enlarge when clicked object
        {
            mRenderer.material.SetFloat("_Outline", 2);
            transform.localScale = transform.localScale * 1.5f;
            FoodpackAnimation.Instance.MoveForCollect(transform);
        }
    }
}