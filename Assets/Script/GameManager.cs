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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowInfo(); //�� ǥ�� �Լ� ȣ��
        MoneyIncrease(); //�� ���� �Լ� ȣ��
        ButtonActiveCheck(); //��ư Ȱ��ȭ üũ �Լ� ȣ��
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
}
