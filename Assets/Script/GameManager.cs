using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public long money; //플레이어가 가진 돈
    public long moneyIncreaseAmount; //돈 증가량

    public Text textMoney; //  돈 표시 UI

    public GameObject prefabMoney; //돈 증가 효과 오브젝트

    public long moenyIncreaseLevel; //클릭 당 단가 업그레이드 레벨
    public long moneyIncreasePrice; //클릭 당 단가 업그레이드 가격
    public Text textPrice; //클릭 당 단가 업그레이드 가격 UI

    public Button buttonPrice; //클릭 당 단가 업그레이드 버튼

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowInfo(); //돈 표시 함수 호출
        MoneyIncrease(); //돈 증가 함수 호출
        ButtonActiveCheck(); //버튼 활성화 체크 함수 호출
    }

    void MoneyIncrease()
    {
        if(Input.GetMouseButtonDown(0)) //마우스 조ㅏ클 시
        {
            if(EventSystem.current.IsPointerOverGameObject() == false) //UI가 아닌 곳을 클릭했을 때
            {
                money += moneyIncreaseAmount; //현재 돈을 증가량 만큼 돈 증가
            }
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //마우스 위치를 월드 좌표로 변환
            Instantiate(prefabMoney, mousePosition, Quaternion.identity); //돈 증가 효과 오브젝트 생성
        }
    }

    void ShowInfo()
    {
        if (money == 0)
            textMoney.text = "0원";  //돈이 0일 때
        else
            textMoney.text = money.ToString("###,###") + "원"; //돈을 천 단위로 끊어서 표시

    }

    void UpdatePanelText()
    {
        textPrice.text = "Lv." + moenyIncreaseLevel + " 단가 상승 \n\n";
        textPrice.text += "외주 당 단가>\n";
        textPrice.text += moneyIncreaseAmount.ToString("###,###") + "원\n";
        textPrice.text += "업그레이드 가격>\n";
        textPrice.text += moneyIncreasePrice.ToString("###,###") + "원\n";
    }

    public void UpgradePrice()
    {
        if (money >= moneyIncreasePrice) //돈이 업그레이드 가격보다 많을 때
        {
            money -= moneyIncreasePrice; //돈 차감
            moenyIncreaseLevel += 1; //업그레이드 레벨 증가
            moneyIncreaseAmount += moenyIncreaseLevel * 100; //단가 증rk           
            moneyIncreasePrice += moenyIncreaseLevel * 500; //업그레이드 가격 증가
        }      
    }

    void ButtonActiveCheck()
    {
        if (money >= moneyIncreasePrice) //돈이 업그레이드 가격보다 많을 때
        {
            buttonPrice.interactable = true; //버튼 활성화
        }
        else
        {
            buttonPrice.interactable = false; //버튼 비활성화
        }
    }
}
