using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovableItem : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    private Vector3 originalPosition;

    //private bool ifollow = false;

    private void Start()
    {
        originalPosition = transform.position;
        //ifollow = false;
    }

    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, pointerData.position, canvas.worldCamera, out position);
        //ifollow = true;

        transform.position = canvas.transform.TransformPoint(position);
    }

    public void DropHandler(BaseEventData data)
    {

    }
}
