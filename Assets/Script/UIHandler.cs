using System;

using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private CardManager cardManager;
    public static UIHandler Instance { get; private set; }
    [SerializeField] private Button startBtn, settingbtn, restartbtn, pauseBtn, quitBtn;
    [SerializeField] private GameObject mainMenu, settingPanel, scorePanel, gameWin;
    [SerializeField] private TextMeshProUGUI scoreText, winText;
    [SerializeField] private TMP_InputField widthInput, heightInput;
    private int score;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        Instance = this;
        startBtn.onClick.AddListener(OnStartClicked);
        settingbtn.onClick.AddListener(OnSettingBtnClicked);
        restartbtn.onClick.AddListener(OnRestartBtnClicked);
        pauseBtn.onClick.AddListener(OnPauseBtnClicked);
        quitBtn.onClick.AddListener(OnQuitButtonClicked);

    }

    private void OnQuitButtonClicked()
    {
        Application.Quit();
    }

    private void OnPauseBtnClicked()
    {
        scorePanel.SetActive(false);
        gameWin.SetActive(true);
        winText.text = $"Your is : {score} ";
    }

    private void OnRestartBtnClicked()
    {
        scorePanel.SetActive(false);
        SceneManager.LoadScene(0);
    }

    private void OnSettingBtnClicked()
    {

        if (!settingPanel.activeSelf)
        {
            settingPanel.SetActive(true);
            settingbtn.GetComponentInChildren<TextMeshProUGUI>().text = "Save";
        }
        else
        {
            int width = Convert.ToInt32(widthInput.text);
            int height = Convert.ToInt32(heightInput.text);
            cardManager.SetHeightWidth(width, height);
            settingPanel.SetActive(false);
            settingbtn.GetComponentInChildren<TextMeshProUGUI>().text = "Setting";

        }
    }
    public void Win()
    {
        gameWin.SetActive(true);
        winText.text = $"You Win \n Your Score : {score}";
    }

    public void UpdateScore(int score)
    {
        this.score = score;
        scoreText.text = $"Score : {score}";
    }
    private void OnStartClicked()
    {
        mainMenu.SetActive(false);
        scorePanel.SetActive(true);
        cardManager.StartGame();

    }
}
