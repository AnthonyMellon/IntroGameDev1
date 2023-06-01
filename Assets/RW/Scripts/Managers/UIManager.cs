using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text sheepSavedText;
    public Text sheepDroppedText;
    public Text highScore;
    public GameObject gameOverWindow;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateHighScore();
    }

    public void UpdateSheepSaved()
    {
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString();
    }

    public void UpdateSheepDropped()
    {
        sheepDroppedText.text = GameStateManager.Instance.sheepDropped.ToString();
    }

    public void UpdateHighScore()
    {
        highScore.text = $"High Score: {GameSettings.highScore}";
    }

    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }
}
