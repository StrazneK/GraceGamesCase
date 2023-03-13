using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Managers;

namespace Foodpack
{
    public class FoodpackAnimation : MonoSingleton<FoodpackAnimation>
    {
        [SerializeField] float animationTime = .5f;
        public void MoveForCollect(Transform _transform)
        {
            _transform.DOMove(ColumnsPool.Instance.GetNextColumnPos(), animationTime);
            _transform.DOScale(Vector3.one / 5, animationTime).OnComplete(() =>
            {
                CollectionController.Instance.AddCollectedObj(_transform.GetComponent<FoodpackObj>().foodpackSO);
                _transform.gameObject.SetActive(false);
            });
        }
        public void UIMatchAnimation(Transform _transform)
        {
            _transform.DORotate(_transform.rotation.eulerAngles + new Vector3(0, 180, 0), .25f).OnComplete(() =>
               {
                   EventManager.Broadcast(GameEvent.OnMatch);
               });
        }
    }
}