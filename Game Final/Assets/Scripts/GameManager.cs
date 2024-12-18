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
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void StartGame()
    {
        UpdateTimer();
        StartCoroutine(TimerCountUp());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateTimer()
    {
        timerText.text = "Time: " + Mathf.FloorToInt(timer).ToString();
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
}
