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

    private void Awake() // 가지고 있는 컴포넌트를 넣어주는 함수
    {
        uiCanvas = GFunc.GetRootObj("UI_Canvas").GetComponent<Canvas>();
        itemRect = GetComponent<RectTransform>();

        //sdPlayer = GFunc.GetRootObj("Set Costume_02 SD Yuko");
        //GameObject yukoLeftEye = sdPlayer.FindChildObj("Eye_L");
        //Debug.LogFormat("Yuko is null {0} , Yuko's left eye is null : {1}", sdPlayer == null, yukoLeftEye == null);

        isDraging = false;

        MyLogFunc myLogFunc = Debug.Log;
        myLogFunc("김민섭 바보");

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
        Debug.Log("마우스 왼쪽 버튼 클릭한 바로 그 순간");
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
            //Debug.LogFormat("아이콘을 움직일 준비가 되었음 -> {0}",eventData.delta);
        }
    }
    public void OnPointerClick(PointerEventData eventData) // 인터페이스에 있는 것은 모두 public 으로 구현해야 한다.
    {
        Debug.Log("이거 함수 만든것 뿐인데 정말 클릭이 되나??");
    }
}
