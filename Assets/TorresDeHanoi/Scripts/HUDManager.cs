using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;

    [SerializeField] private GameObject game;
    [SerializeField] private GameObject victory;
    [SerializeField] private GameObject newRecord;
    [SerializeField] private Text movesCounterText;

    private void Awake()
    {
        InitializeSingleton();
    }

    private void Start()
    {
        InitializeHUD();
    }

    private void InitializeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeHUD()
    {
        movesCounterText.text = "0";
        game.SetActive(true);
        victory.SetActive(false);
    }

    public void UpdateMovesCounterText()
    {
        movesCounterText.text = GameManager.Instance.GetMovesCounterInfo().ToString();
    }

    public void InitializeHUDManager()
    {
        InitializeHUD();
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
