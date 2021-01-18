using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Test_Joystic : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Image Back_Joystic; //조이스틱 바깥
    public Image Joystic_I; //조이스틱 몸체
    public Vector3 input_V; // 이동 값
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(Back_Joystic.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / Back_Joystic.rectTransform.sizeDelta.x);
            pos.y = (pos.y / Back_Joystic.rectTransform.sizeDelta.y);

            input_V = new Vector3(pos.x * 2, pos.y * 2, 0);
            input_V = (input_V.magnitude > 1.0f) ? input_V.normalized : input_V;

            Joystic_I.rectTransform.anchoredPosition = new Vector3(input_V.x * (Back_Joystic.rectTransform.sizeDelta.x / 3)
                , input_V.y * (Back_Joystic.rectTransform.sizeDelta.y / 3));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        input_V = Vector3.zero;
        Joystic_I.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float GetHorizontalValue()
    {
        return input_V.x;
    }

    public float GetVerticalValue()
    {
        return input_V.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        Back_Joystic = GetComponent<Image>();
        Joystic_I = transform.GetChild(0).GetComponent<Image>();
    }
}
