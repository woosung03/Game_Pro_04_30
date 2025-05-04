using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Work : MonoBehaviour
{
    private Animator anim;  // Animator component reference
    void Start()
    {
        anim = GetComponent<Animator>();    // 애니 컴포넌트
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //마우스 좌클
        {   // 클릭한 대상이 UI가 아닌경우
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() == false)    
            {
                anim.SetTrigger("Click"); //  마우스 좌클 클릭시 애니메이션 실행
            } 
        }
    }
}
