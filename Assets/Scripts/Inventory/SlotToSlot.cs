using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotToSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        ItemSnapNMove draggableItem = dropped.GetComponent<ItemSnapNMove>();
        draggableItem.parentAfterDrag = transform;
    }
}
