using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_dir : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;

    float time = 30.0f;  // 제한시간
    int point = 0; // 현재 포인트

    GameObject generator;


    public void Getapple() // 포인트 추가
    {
        this.point += 100;
    }

    public void Getbomb()  // 포인트 감소
    {
        this.point /= 2;
    }


    void Start()
    {
        this.generator = GameObject.Find("ItemGen");  // IEnumerable course() (코루틴) 사용시 사용X

        this.timerText = GameObject.Find("time");
        this.pointText = GameObject.Find("point");

        //generator.GetComponent<Item_gen>().Setparameter(1.5f, -0.002f, 2);  // IEnumerable course() (코루틴) 사용시 사용
    }


    void Update()
    {
        this.time -= Time.deltaTime;

        if (this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<Item_gen>().Setparameter(10000.0f, 0, 0);
        }
        else if (0 <= this.time && this.time < 5)
        {
            this.generator.GetComponent<Item_gen>().Setparameter(0.7f, -0.04f, 3);
        }
        else if (5 <= this.time && this.time < 12)
        {
            this.generator.GetComponent<Item_gen>().Setparameter(0.5f, -0.05f, 6);
        }
        else if (12 <= this.time && this.time < 23)
        {
            this.generator.GetComponent<Item_gen>().Setparameter(0.8f, -0.04f, 4);
        }
        else if (23 <= this.time && this.time < 30)
        {
            this.generator.GetComponent<Item_gen>().Setparameter(1.0f, -0.03f, 2);
        }

        this.timerText.GetComponent<Text>().text = this.time.ToString("0");  // 소숫점 표시 : (소숫점 한자리)F1, (소숫점 두자리)F2

        this.pointText.GetComponent<Text>().text = this.point.ToString() + " point";
    }

    /*IEnumerable course()
    {
        this.generator.GetComponent<Item_gen>().Setparameter(0.9f, -0.04f, 3);
        yield return new WaitForSeconds(5.0f);
        this.generator.GetComponent<Item_gen>().Setparameter(0.5f, -0.05f, 6);
        yield return new WaitForSeconds(10.0f);
        this.generator.GetComponent<Item_gen>().Setparameter(0.8f, -0.04f, 4);
        yield return new WaitForSeconds(15.0f);
        this.generator.GetComponent<Item_gen>().Setparameter(1.0f, -0.03f, 2);
        yield return new WaitForSeconds(20.0f);
    }*/
}
