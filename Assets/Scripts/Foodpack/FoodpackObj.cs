using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class FoodpackObj : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] MeshRenderer mRenderer;
    private void Start()
    {
        mRenderer = GetComponent<MeshRenderer>(); 
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        mRenderer.material.SetFloat("_Outline", 1);
        transform.localScale = transform.localScale * 1.3f;
    }
}
