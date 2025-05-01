using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
public class MoneyMove : MonoBehaviour
{
    public Vector2 point;

    Text txt;
    void Start()
    {
        txt = transform.GetComponentInChildren<Text>();

        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        txt.text = "+" + gm.moneyIncreaseAmount.ToString("###,###"); //���� õ ������ ��� ǥ��

        Destroy(this.gameObject, 2f); //2�� �Ŀ� ������Ʈ ����
    }

    // Update is called once per frame
    void Update() //��ġ ���� ���� ���� ����
    {
        transform.position = Vector2.MoveTowards(transform.position, point, Time.deltaTime * 10f); //������ ��ġ�� �̵�

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a -  0.01f); //���� ����

        txt = transform.GetComponentInChildren<Text>();
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, txt.color.a -  0.01f); //���� ����
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(point, 0.2f); //������ ��ġ�� �̵��ϴ� ���� �׸���
    }
}
