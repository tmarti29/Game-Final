using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public Button startButton;
    public Button HtPButton;
    public Button creditButton;
    public Button quitButton;
    public GameObject htP;
    public GameObject credit;
    // Start is called before the first frame update
    void Start()
    {
        
        startButton.onClick.AddListener(Begin);
        HtPButton.onClick.AddListener(HtP);
        creditButton.onClick.AddListener(Credit);
        quitButton.onClick.AddListener(Quit);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            startButton.gameObject.SetActive(true);
            HtPButton.gameObject.SetActive(true);
            creditButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
            htP.gameObject.SetActive(false);
            credit.gameObject.SetActive(false);
        }
    }
    void Begin()
    {
        SceneManager.LoadScene("Play");
    }
    void HtP()
    {
        htP.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        HtPButton.gameObject.SetActive(false);
        creditButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }
    void Credit()
    {
        credit.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        HtPButton.gameObject.SetActive(false);
        creditButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }
    void Quit()
    {
        Application.Quit();
    }
}
