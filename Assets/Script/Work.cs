using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Work : MonoBehaviour
{
    private Animator anim;  // Animator component reference
    void Start()
    {
        anim = GetComponent<Animator>();    // �ִ� ������Ʈ
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //���콺 ��Ŭ
        {   // Ŭ���� ����� UI�� �ƴѰ��
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() == false)    
            {
                anim.SetTrigger("Click"); //  ���콺 ��Ŭ Ŭ���� �ִϸ��̼� ����
            } 
        }
    }
}
