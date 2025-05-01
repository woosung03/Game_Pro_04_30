using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class AutoWork : MonoBehaviour
{
    public static long autoMoneyIncreaseAmount = 10;
    public static long autoIncreasePrice = 1000;
    void Start()
    {
        StartCoroutine(Work());
    }

    IEnumerator Work()
    {
        while (true)
        {

            GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            gm.money += autoMoneyIncreaseAmount;
            yield return new WaitForSeconds(1); //1초마다 돈 증가           
        }
    }
}
