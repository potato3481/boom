using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket_Ctrl : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;

    GameObject director;
    AudioSource aud;


    void Start()
    {
        this.director = GameObject.Find("GameDirector");
        this.aud = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider other)  // 콜라이더에 IsTrigger가 설정되어있는 오브젝트와 닿았을때 결과를 나타내는 함수값 / * IsTrigger 설정이 없으면 OnCollisionEnter(Collision collision)로 설정
    {
        if (other.gameObject.tag == "apple")  // name으로 찾게 되면 tag를 name으로 바꿈
        {
            this.director.GetComponent<Game_dir>().Getapple();
            this.aud.PlayOneShot(this.appleSE);
        }
        else
        {
            this.director.GetComponent<Game_dir>().Getbomb();
            this.aud.PlayOneShot(this.bombSE);
        }

        Destroy(other.gameObject);
    }


    void Update()
    {
        //마우스 플레이
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;  // RaycastHit : Raycast의 결과
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))  // Raycast : ray와 닿은 물체를 판별 - true, flase / 매개변수 (광선, hit의 값을 저장할 저장소값, Mathf.Infinity)
            {
                // = hit.transform .gameObject.GetComponent 
                float x = Mathf.RoundToInt(hit.point.x);  // Mathf.RoundToInt : 반올림 / 부딪힌 좌표 조회
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }

        //키보드 플레이
        /*if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-1.0f, 0, 0);

            // x좌표값이 -1보다 작아지면
            if (this.transform.position.x < -1.0f)
            {
                this.transform.position = new Vector3(-1.0f, 0, 0);  // x좌표값을 -1으로 설정하여 더 왼쪽으로 가지 못하게 함
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(1.0f, 0, 0);

            if (this.transform.position.x > 1.0f)
            {
                this.transform.position = new Vector3(1.0f, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, 1.0f);

            if (this.transform.position.z > 1.0f)
            {
                this.transform.position = new Vector3(0, 0, 1.0f);  // 지정해놓은 Z값은 그대로인데 연타시 X값이 지정되어있던 0으로 리셋되버리는 오류(미해결)
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -1.0f);

            if (this.transform.position.z < -1.0f)
            {
                this.transform.position = new Vector3(1, 0, -1.0f);  // 지정해놓은 Z값은 그대로인데 연타시 X값이 지정되어있던 0으로 리셋되버리는 오류(미해결)
            }
        }*/
    }
}
