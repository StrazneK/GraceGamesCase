using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName ="ScriptableObjects/FoodpackSO")]
    public class FoodpackSO : ScriptableObject
    {
        public GameObject prefab;
        public Sprite image;
        public string title;
        private void OnValidate()
        {
            if (prefab != null)
                title = prefab.name;
        }
    }
}