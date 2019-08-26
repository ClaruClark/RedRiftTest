using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [Header("UI")]
    [SerializeField]
    private Text score = null;
    [SerializeField]
    private GameObject planetPanel = null;

    private int hits;
    private Score currentScore;

    public bool isGameOn { get; set; }

    void Start()
    {
       currentScore = SaveManager.Instance.Load();

        if (currentScore != null)
            hits = currentScore.ballHits;

        ShowScore();
    }

   
    private void ShowScore()
    {
        score.text = "BallHits: "+ hits.ToString();
    }


    public void ClickableClick(IClickable sender)
    {
        switch (sender.GetClickableType())
        {
            case ClickableType.Platform:
                sender.DoSomething();
                break;
            case ClickableType.Button:
                planetPanel.SetActive(true);
                isGameOn = true;
                sender.DoSomething();
                break;
        }
    }

    public void AddHit()
    {
        hits++;
    }

    public void BackButton()
    {
        if (planetPanel.activeSelf)
        {
            isGameOn = false;
            PlanetController.Instance.StopPlanet();
            planetPanel.SetActive(false);
            ShowScore();
        }
        else
        {
            SaveManager.Instance.Save(hits);
            Application.Quit();
        }

        
    }

    private void OnApplicationQuit()
    {
        SaveManager.Instance.Save(hits);
    }
}
