using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Managers;
using UI.Grid;
using Other;

namespace Foodpack
{
    public class FoodpackAnimation : MonoSingleton<FoodpackAnimation>
    {
        [SerializeField] float animationTime = .5f;
        public void MoveForCollect(Transform _transform) //Movement animation when collect gameobjects
        {
            _transform.DOMove(ColumnsPool.Instance.GetNextColumnPos(), animationTime);
            _transform.DOScale(Vector3.one / 5, animationTime).OnComplete(() =>
            {
                CollectionController.Instance.AddCollectedObj(_transform.GetComponent<FoodpackObj>().foodpackSO);
                _transform.gameObject.SetActive(false);
            });
        }
        public void UIMatchAnimation(Transform _transform) //Match animation when collect 3 object on grid
        {
            _transform.DORotate(_transform.rotation.eulerAngles + new Vector3(0, 180, 0), .25f).OnComplete(() =>
               {
                   EventManager.Broadcast(GameEvent.OnMatch);
               });
        }
    }
}