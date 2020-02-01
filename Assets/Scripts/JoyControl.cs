using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyControl : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image backImage;
    [SerializeField] private Image joyImage;
    
    private Vector3 inputDir;

    private void Start()
    {
        backImage = GetComponent<Image>();
        joyImage = backImage.transform.GetChild(0).GetComponent<Image>();
    }
    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(backImage.rectTransform,eventData.position,eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / backImage.rectTransform.sizeDelta.x);
            pos.y = (pos.y / backImage.rectTransform.sizeDelta.y);

            inputDir = new Vector3(pos.x *2, pos.y *2, 1);
            inputDir = (inputDir.magnitude > 1 ? inputDir.normalized : inputDir);

            joyImage.rectTransform.anchoredPosition = new Vector3(inputDir.x * (backImage.rectTransform.sizeDelta.x /3), inputDir.y * (backImage.rectTransform.sizeDelta.y/3), inputDir.z);
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        inputDir = Vector3.zero;
        joyImage.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float MovimentHorizontal()
    {
        if(inputDir.x != 0)
        {
            return inputDir.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }

    public float MovimentVertical()
    {
        if (inputDir.y != 0)
        {
            return inputDir.y;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }
}
