using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvasTran;
    private GameObject draggingObject;
    [SerializeField]
    private Player m_player;
    private bool isFire;

    void Awake()
    {
        canvasTran = transform.parent.parent;
    }

    private void Update()
    {
        //print(isFire);
    }

    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        
        CreateDragObject();
        draggingObject.transform.position = pointerEventData.position;
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        isFire = true;
        draggingObject.transform.position = pointerEventData.position;
    }

    public void OnEndDrag(PointerEventData pointerEventData)
    {
        gameObject.GetComponent<Image>().color = Vector4.one;
        Destroy(draggingObject);
        if (m_player == null)
        {
            return;
        }
        m_player.OrnamenteDrop();
    }

    // ドラッグオブジェクト作成
    private void CreateDragObject()
    {
        draggingObject = new GameObject("Dragging Object");
        draggingObject.transform.SetParent(canvasTran);
        draggingObject.transform.SetAsLastSibling();
        draggingObject.transform.localScale = Vector3.one;

        // レイキャストがブロックされないように
        CanvasGroup canvasGroup = draggingObject.AddComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false;

        Image draggingImage = draggingObject.AddComponent<Image>();
        Image sourceImage = GetComponent<Image>();

        draggingImage.sprite = sourceImage.sprite;
        draggingImage.rectTransform.sizeDelta = sourceImage.rectTransform.sizeDelta;
        draggingImage.color = sourceImage.color;
        draggingImage.material = sourceImage.material;

        gameObject.GetComponent<Image>().color = Vector4.one * 0.6f;

    }

    public bool FireCheck()
    {
        if (isFire)
        {
            return false;
        }
        else if(!isFire)
        {
            return false;
        }
        else
        {
            return false;
        }
    }
}
