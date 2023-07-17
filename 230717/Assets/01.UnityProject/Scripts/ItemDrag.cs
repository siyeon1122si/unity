using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour , IPointerDownHandler , IPointerUpHandler , IDragHandler
{
    private Canvas uiCanvas = default;

    private RectTransform itemRect = default;

    private GameObject sdPlayer = default;

    private bool isDraging = false;

    private delegate void MyLogFunc(object message);

    private System.Action myAction;
    private delegate void MyAction001(object message , int number1 , int number2);

    private System.Func<float, float , int, int , string> myFunc;
    private delegate string MyFunction001(float f1 , float f2 , int i1 , int i2);

    private void Awake() // ������ �ִ� ������Ʈ�� �־��ִ� �Լ�
    {
        uiCanvas = GFunc.GetRootObj("UI_Canvas").GetComponent<Canvas>();
        itemRect = GetComponent<RectTransform>();

        //sdPlayer = GFunc.GetRootObj("Set Costume_02 SD Yuko");
        //GameObject yukoLeftEye = sdPlayer.FindChildObj("Eye_L");
        //Debug.LogFormat("Yuko is null {0} , Yuko's left eye is null : {1}", sdPlayer == null, yukoLeftEye == null);

        isDraging = false;

        MyLogFunc myLogFunc = Debug.Log;
        myLogFunc("��μ� �ٺ�");

    }

    // Start is called before the first frame update
    void Start()
    {
        //itemRect.anchoredPosition += new Vector2(100f, 0f);
        //itemRect.localPosition += new Vector3(100f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDraging = true;
        Debug.Log("���콺 ���� ��ư Ŭ���� �ٷ� �� ����");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDraging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDraging)
        {
            // LEGACY :
            //itemRect.anchoredPosition += eventData.delta;
            itemRect.anchoredPosition += ( eventData.delta / uiCanvas.scaleFactor );
            //Debug.LogFormat("�������� ������ �غ� �Ǿ��� -> {0}",eventData.delta);
        }
    }
    public void OnPointerClick(PointerEventData eventData) // �������̽��� �ִ� ���� ��� public ���� �����ؾ� �Ѵ�.
    {
        Debug.Log("�̰� �Լ� ����� ���ε� ���� Ŭ���� �ǳ�??");
    }
}
