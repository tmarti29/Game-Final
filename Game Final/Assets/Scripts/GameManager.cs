using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timer = 0.0f;
    public TextMeshProUGUI timerText;
    public bool isGameActive;
    public GameObject jerry;
    public GameObject deathBG;
    public GameObject deathText;
    public GameObject escapeText;
    public GameObject winText;
    public GameObject bigTimer;
    public TextMeshProUGUI bigTimerText;
    public GameObject winEscape;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }
    void StartGame()
    {
        isGameActive = true;
        UpdateTimer();
        StartCoroutine(TimerCountUp());
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Start Menu");
        }
        if(jerry.transform.position.y < 83 && jerry.transform.position.x > 23)
        {
            GameOver();
        }
        else if(jerry.transform.position.y < -7.5f)
        {
            GameOver();
        }
        else if(jerry.transform.position.y > 163.5f)
        {
            Win();
        }
    }
    public void UpdateTimer()
    {
        timerText.text = "Time: " + Mathf.FloorToInt(timer).ToString();
        bigTimerText.text = "Time: " + Mathf.FloorToInt(timer).ToString();
    }

    IEnumerator TimerCountUp()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1f);
            timer += 1f;
            UpdateTimer();
        }
    }
    void GameOver()
    {
        isGameActive=false;
        deathBG.SetActive(true);
        deathText.SetActive(true);
        escapeText.SetActive(true);
    }
    void Win()
    {
        isGameActive=false;
        winText.SetActive(true);
        bigTimer.SetActive(true);
        winEscape.SetActive(true);
    }
}
