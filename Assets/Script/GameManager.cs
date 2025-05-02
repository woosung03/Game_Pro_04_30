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

    public int employeeCount; //직원 래밸
    public Text textRecruit; //직원 래밸 UI

    public Button buttonRecruit; //직원 고용 버튼

    public int width; //가로 최대 직원 수
        public float space; //직원 간격
    public GameObject Coin_Auto; //직원 프리팹

    public Text textCoin_Auto; //직원 단가 UI

    public float spaceFloor; //직원 간격
       public int floorCapacity; //직원 최대 수
       public int currentFloor; //현재 층 수
       public GameObject PrefabFloor; //층 프리팹
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowInfo(); //돈 표시 함수 호출
        MoneyIncrease(); //돈 증가 함수 호출
        ButtonActiveCheck(); //버튼 활성화 체크 함수 호출
        UpdatePanelText(); //업그레이드 가격 UI 업데이트 함수 호출
        CreateFloor(); //층 생성 함수 호출
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
        if(employeeCount == 0)
            textCoin_Auto.text = "0명"; //직원 단가가 0일 때
        else
            textCoin_Auto.text = employeeCount + "명"; //직원 단가 표시
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

    void UpdateRecruitPanelText() //직원 단가   업데이트
    {
        textRecruit.text = "Lv." + employeeCount + " 직원 고용 \n\n";
        textRecruit.text += "직원 1초 당 단가>\n";
        textRecruit.text += AutoWork.autoMoneyIncreaseAmount.ToString("###,###") + "원\n";
        textRecruit.text += "업그레이드 가격>\n";
        textRecruit.text += AutoWork.autoMoneyIncreaseAmount.ToString("###,###") + "원\n";
    }

    void ButtonRecruitActiveCheck() // 직원 고용 활성화 버튼
    {
        if (money >= AutoWork.autoIncreasePrice) //돈이 업그레이드 가격보다 많을 때
        {
            buttonRecruit.interactable = true; //버튼 활성화
        }
        else
        {
            buttonRecruit.interactable = false; //버튼 비활성화
        }
    }

    void CreateEmployee()
    {
        Vector2 boosSpot = GameObject.Find("Boss").transform.position; //보스 위치
        float spotX = boosSpot.x + (employeeCount % width) * space; //직원 위치 X 좌표    
        float spotY = boosSpot.y - (employeeCount / width) * space; //직원 위치 Y 좌표

        Instantiate(Coin_Auto, new Vector2(spotX, spotY), Quaternion.identity); //직원 프리팹 생성
    }

    public void Recruit()
    {
        if (money >= AutoWork.autoIncreasePrice) //돈이 업그레이드 가격보다 많을 때
        {
            money -= AutoWork.autoIncreasePrice; //돈 차감
            employeeCount += 1; //직원 수 증가
            AutoWork.autoMoneyIncreaseAmount += moenyIncreaseLevel * 10; //직원 단가 증가
            AutoWork.autoIncreasePrice += employeeCount * 500; //업그레이드 가격 증가
            CreateEmployee(); //직원 생성 함수 호출
        }
    }

    void CreateFloor()
    {
        Vector2 bgPosition = GameObject.Find("Background").transform.position; //배경 위치

        float nextFloor = (employeeCount + 1) / floorCapacity; //다음 층 수

        float spotX = bgPosition.x; //층 위치 X 좌표
        float spotY = bgPosition.y; //층 위치 Y 좌표

        spotY -= nextFloor * spaceFloor; //층 위치 Y 좌표

        if(nextFloor >= currentFloor) //다음 층 수가 현재 층 수보다 많을 때
        {
            Instantiate(PrefabFloor, new Vector2(spotX, spotY), Quaternion.identity); //층 프리팹 생성
            currentFloor += 1; //현재 층 수 증가
        }
    }
}
