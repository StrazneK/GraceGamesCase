using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnsPool : MonoSingleton<ColumnsPool>
{
   List<Column> columns = new List<Column>();
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            columns.Add(transform.GetChild(i).GetComponent<Column>());
        }
    }

    public void FillColumns(List<FoodpackSO> collectedObjs)
    {
        for (int i = 0; i < collectedObjs.Count; i++)
        {
            columns[i].FillContent(collectedObjs[i]);
        }
    }
    public void ClearColumns()
    {
        for (int i = 0; i < columns.Count; i++)
        {
            columns[i].RemoveContent();
            columns[i].gameObject.SetActive(false);
        }
    }
    public Vector3 GetNextColumnPos()
    {
        int targetIndex = CollectionController.Instance.lastIndex + 1;
        Vector3 columnPos = columns[targetIndex].transform.position;
        Vector3 screenPos = columnPos;
        Vector3 worldPos=Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        if (Physics.Raycast(ray, out RaycastHit hitData))
        {
            worldPos = hitData.point;
        }
        
        return worldPos;
    }
    public void MatchedColumns(int columnIndex)
    {
            FoodpackAnimation.Instance.UIMatchAnimation(columns[columnIndex].transform);
    }
}
