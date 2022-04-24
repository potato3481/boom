using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Button;

    public void OnClick()
    {
        SceneManager.LoadScene("GameScene");
    }    
}
