using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_gen : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;

    float span = 2.0f;  // 생성빈도(2초마다 한번씩 생성)
    float delta = 0;
    int ratio = 2;  // 생성비율값 = 10분에 2할만 폭탄
    float speed = -0.05f; // 아이템 이동속도


    public void Setparameter(float span, float speed, int ratio)  // Setparameter : public 없이 변수 조정을 간접적으로 실행하는 함수값
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }


    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject item;
            int dice = Random.Range(1, 11);  // Range = 최소값 포함 ~ 최대값 미포함의 범위
            if (dice <= this.ratio)
            {
                item = Instantiate(bombPrefab) as GameObject;
            }
            else
            {
                item = Instantiate(applePrefab) as GameObject;
            }

            // x, z의 위치는 -1, 0, 1 사이에서 랜덤으로 설정(스테이지 넓이 3x3) 
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);  // 새롭게 생성되는 아이템 초기 위치를 랜덤 설정된 x, z 위치값을 적용해 (x, 4, z)로 지정한다
            item.GetComponent<item_ctrl>().dropSpeed = this.speed;
        }
    }
}
