using TMPro;
using UnityEngine;

public abstract class CountSystemBase : MonoBehaviour, ICountSystem
{
    protected int count;
    protected string key;

    public int Count => count;

    public void AddCount(int addedCount)
    { 
        count += addedCount;
        CountChanged();
    }

    public void RemoveCount(int removedCount)
    {
        count -= removedCount;
        CountChanged();
    }

    public void SaveCount() => PlayerPrefs.SetInt(key, count);

    protected virtual void Start()
    {
        count = PlayerPrefs.GetInt(key, 100);
    }
    public abstract void CountChanged();
    
}
