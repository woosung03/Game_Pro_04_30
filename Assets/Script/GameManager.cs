using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public long money; //�÷��̾ ���� ��
    public long moneyIncreaseAmount; //�� ������

    public Text textMoney; //  �� ǥ�� UI

    public GameObject prefabMoney; //�� ���� ȿ�� ������Ʈ

    public long moenyIncreaseLevel; //Ŭ�� �� �ܰ� ���׷��̵� ����
    public long moneyIncreasePrice; //Ŭ�� �� �ܰ� ���׷��̵� ����
    public Text textPrice; //Ŭ�� �� �ܰ� ���׷��̵� ���� UI

    public Button buttonPrice; //Ŭ�� �� �ܰ� ���׷��̵� ��ư

    public int employeeCount; //���� ����
    public Text textRecruit; //���� ���� UI

    public Button buttonRecruit; //���� ��� ��ư

    public int width; //���� �ִ� ���� ��
        public float space; //���� ����
    public GameObject Coin_Auto; //���� ������

    public Text textCoin_Auto; //���� �ܰ� UI

    public float spaceFloor; //���� ����
       public int floorCapacity; //���� �ִ� ��
       public int currentFloor; //���� �� ��
       public GameObject PrefabFloor; //�� ������
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowInfo(); //�� ǥ�� �Լ� ȣ��
        MoneyIncrease(); //�� ���� �Լ� ȣ��
        ButtonActiveCheck(); //��ư Ȱ��ȭ üũ �Լ� ȣ��
        UpdatePanelText(); //���׷��̵� ���� UI ������Ʈ �Լ� ȣ��
        CreateFloor(); //�� ���� �Լ� ȣ��
    }

    void MoneyIncrease()
    {
        if(Input.GetMouseButtonDown(0)) //���콺 ����Ŭ ��
        {
            if(EventSystem.current.IsPointerOverGameObject() == false) //UI�� �ƴ� ���� Ŭ������ ��
            {
                money += moneyIncreaseAmount; //���� ���� ������ ��ŭ �� ����
            }
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //���콺 ��ġ�� ���� ��ǥ�� ��ȯ
            Instantiate(prefabMoney, mousePosition, Quaternion.identity); //�� ���� ȿ�� ������Ʈ ����
        }
    }

    void ShowInfo()
    {
        if (money == 0)
            textMoney.text = "0��";  //���� 0�� ��
        else
            textMoney.text = money.ToString("###,###") + "��"; //���� õ ������ ��� ǥ��
        if(employeeCount == 0)
            textCoin_Auto.text = "0��"; //���� �ܰ��� 0�� ��
        else
            textCoin_Auto.text = employeeCount + "��"; //���� �ܰ� ǥ��
    }

    void UpdatePanelText()
    {
        textPrice.text = "Lv." + moenyIncreaseLevel + " �ܰ� ��� \n\n";
        textPrice.text += "���� �� �ܰ�>\n";
        textPrice.text += moneyIncreaseAmount.ToString("###,###") + "��\n";
        textPrice.text += "���׷��̵� ����>\n";
        textPrice.text += moneyIncreasePrice.ToString("###,###") + "��\n";
    }

    public void UpgradePrice()
    {
        if (money >= moneyIncreasePrice) //���� ���׷��̵� ���ݺ��� ���� ��
        {
            money -= moneyIncreasePrice; //�� ����
            moenyIncreaseLevel += 1; //���׷��̵� ���� ����
            moneyIncreaseAmount += moenyIncreaseLevel * 100; //�ܰ� ��rk           
            moneyIncreasePrice += moenyIncreaseLevel * 500; //���׷��̵� ���� ����
        }      
    }

    void ButtonActiveCheck()
    {
        if (money >= moneyIncreasePrice) //���� ���׷��̵� ���ݺ��� ���� ��
        {
            buttonPrice.interactable = true; //��ư Ȱ��ȭ
        }
        else
        {
            buttonPrice.interactable = false; //��ư ��Ȱ��ȭ
        }
    }

    void UpdateRecruitPanelText() //���� �ܰ�   ������Ʈ
    {
        textRecruit.text = "Lv." + employeeCount + " ���� ��� \n\n";
        textRecruit.text += "���� 1�� �� �ܰ�>\n";
        textRecruit.text += AutoWork.autoMoneyIncreaseAmount.ToString("###,###") + "��\n";
        textRecruit.text += "���׷��̵� ����>\n";
        textRecruit.text += AutoWork.autoMoneyIncreaseAmount.ToString("###,###") + "��\n";
    }

    void ButtonRecruitActiveCheck() // ���� ��� Ȱ��ȭ ��ư
    {
        if (money >= AutoWork.autoIncreasePrice) //���� ���׷��̵� ���ݺ��� ���� ��
        {
            buttonRecruit.interactable = true; //��ư Ȱ��ȭ
        }
        else
        {
            buttonRecruit.interactable = false; //��ư ��Ȱ��ȭ
        }
    }

    void CreateEmployee()
    {
        Vector2 boosSpot = GameObject.Find("Boss").transform.position; //���� ��ġ
        float spotX = boosSpot.x + (employeeCount % width) * space; //���� ��ġ X ��ǥ    
        float spotY = boosSpot.y - (employeeCount / width) * space; //���� ��ġ Y ��ǥ

        Instantiate(Coin_Auto, new Vector2(spotX, spotY), Quaternion.identity); //���� ������ ����
    }

    public void Recruit()
    {
        if (money >= AutoWork.autoIncreasePrice) //���� ���׷��̵� ���ݺ��� ���� ��
        {
            money -= AutoWork.autoIncreasePrice; //�� ����
            employeeCount += 1; //���� �� ����
            AutoWork.autoMoneyIncreaseAmount += moenyIncreaseLevel * 10; //���� �ܰ� ����
            AutoWork.autoIncreasePrice += employeeCount * 500; //���׷��̵� ���� ����
            CreateEmployee(); //���� ���� �Լ� ȣ��
        }
    }

    void CreateFloor()
    {
        Vector2 bgPosition = GameObject.Find("Background").transform.position; //��� ��ġ

        float nextFloor = (employeeCount + 1) / floorCapacity; //���� �� ��

        float spotX = bgPosition.x; //�� ��ġ X ��ǥ
        float spotY = bgPosition.y; //�� ��ġ Y ��ǥ

        spotY -= nextFloor * spaceFloor; //�� ��ġ Y ��ǥ

        if(nextFloor >= currentFloor) //���� �� ���� ���� �� ������ ���� ��
        {
            Instantiate(PrefabFloor, new Vector2(spotX, spotY), Quaternion.identity); //�� ������ ����
            currentFloor += 1; //���� �� �� ����
        }
    }
}
