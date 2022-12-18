using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int ballAmount = 3;
    [SerializeField] private TextMeshProUGUI txtScore;
    [SerializeField] private bool isPlaying = true;

    [SerializeField] private GameObject endPanel;
    [SerializeField] private TextMeshProUGUI endScore;
    [SerializeField] private GameObject newRecord;
    private int highScore = 0;

    [SerializeField] private TextMeshProUGUI txtHighScore;
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore");
        if (txtHighScore != null)
            txtHighScore.text = highScore.ToString("D4");
        score = 0;
        StartCoroutine(UpdateUI());
    }

    private IEnumerator UpdateUI()
    {
        while(isPlaying)
        {
            score += 1;
            txtScore.text = score.ToString("D4");
            if(ballAmount <= 0)
            {
                if(highScore < score)
                {
                    PlayerPrefs.SetInt("highscore", score);
                    newRecord.SetActive(true);
                }
                txtScore.gameObject.SetActive(false);
                endPanel.SetActive(true);
                endScore.text = score.ToString("D4");
                isPlaying = false;
            }
            yield return new WaitForSeconds(.2f);
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
