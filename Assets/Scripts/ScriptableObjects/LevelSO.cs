using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/LevelSO")]
    public class LevelSO : ScriptableObject
    {
        [SerializeField] const bool randomObjs = true;
        public int difficulty = 1;
        public float time = 100;
    }
}