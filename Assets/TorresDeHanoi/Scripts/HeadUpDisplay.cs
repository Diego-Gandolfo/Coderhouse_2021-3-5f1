using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeadUpDisplay : MonoBehaviour
{
    public static HeadUpDisplay Instance;

    [SerializeField] private GameObject game;
    [SerializeField] private GameObject victory;
    [SerializeField] private GameObject newRecord;
    [SerializeField] private Text movesCounterText;

    private void Awake()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.headUpDisplay = this;
    }

    private void Start()
    {
        InitializeHeadUpDisplay();
    }

    public void InitializeHeadUpDisplay()
    {
        movesCounterText.text = "0";
        game.SetActive(true);
        victory.SetActive(false);
    }

    public void UpdateMovesCounterText()
    {
        movesCounterText.text = GameManager.Instance.movesCounter.ToString();
    }

    public void Victory(bool record = false)
    {
        game.SetActive(false);
        victory.SetActive(true);
        newRecord.SetActive(record);
    }

    public void Restart()
    {
        GameManager.Instance.Restart();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("01_MainMenu");
    }
}
