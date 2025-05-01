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
        txt.text = "+" + gm.moneyIncreaseAmount.ToString("###,###"); //돈을 천 단위로 끊어서 표시

        Destroy(this.gameObject, 2f); //2초 후에 오브젝트 삭제
    }

    // Update is called once per frame
    void Update() //위치 색상 랜덤 투명도 감소
    {
        transform.position = Vector2.MoveTowards(transform.position, point, Time.deltaTime * 10f); //지정한 위치로 이동

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a -  0.01f); //투명도 감소

        txt = transform.GetComponentInChildren<Text>();
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, txt.color.a -  0.01f); //투명도 감소
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(point, 0.2f); //지정한 위치로 이동하는 선을 그리기
    }
}
