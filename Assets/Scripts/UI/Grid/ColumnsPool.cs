using Foodpack;
using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Grid
{
    public class ColumnsPool : PoolControl<ColumnsPool>
    {
        public Vector3 GetNextColumnPos()
        {
            int targetIndex = CollectionController.Instance.lastIndex + 1;
            Vector3 columnPos = foodpackUIs[targetIndex].transform.position;
            Vector3 screenPos = columnPos;
            Vector3 worldPos = Vector3.zero;
            Ray ray = Camera.main.ScreenPointToRay(screenPos);

            if (Physics.Raycast(ray, out RaycastHit hitData))
            {
                worldPos = hitData.point;
            }

            return worldPos;
        }
        public void MatchedColumns(int columnIndex)
        {
            FoodpackAnimation.Instance.UIMatchAnimation(foodpackUIs[columnIndex].transform);
        }
    }
}