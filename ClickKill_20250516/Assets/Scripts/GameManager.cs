using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public TextMeshProUGUI timeText;

    public TextMeshProUGUI resultText;

    public GameObject endPannel;

    private float time;

    public float limitTime;

    private int result;

    private void Awake()
    {
        if(instance != null)
        {
            instance = this;
        }
    }

    private void Update()
    {

        timeText.text = time.ToString("F1");

        resultText.text = result.ToString();

        if (time <= limitTime)
        {
            time += Time.deltaTime;
        }
        else
        {
            endPannel.SetActive(true);
            return;
        }

    }

    public void GoMeneScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void EndGame()
    {
        Application.Quit();
    }


}
