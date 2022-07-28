using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeadUpDisplay : MonoBehaviour
{
    [Header("HUD")]
    [SerializeField] private GameObject goHUD;
    [SerializeField] private Image lifeImage;
    [SerializeField] private Text timeTextHUD;

    [Header("Victory")]
    [SerializeField] private GameObject goVictory;
    [SerializeField] private Text timeTextVictory;
    [SerializeField] private GameObject newRecord;

    private void Start()
    {
        goHUD.SetActive(true);
        goVictory.SetActive(false);

        if (GameManager.Instance == null) return;
        GameManager.Instance.headUpDisplay = this;
        GameManager.Instance.StartGame();
    }

    private string FormatTime(float time, bool debug = false)
    {
        int minutes = (int) (time / 60);
        int seconds = (int) (time - (60 * minutes));
        int milliseconds = (int) ((time - (minutes * 60) - seconds) * 100);
        if (debug)
        {
            print($"{minutes} : {seconds} : {milliseconds}");
        }
        var t = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds); 
        return t;
    }

    public void UpdateLife(float currentLife, float maxLife)
    {
        lifeImage.fillAmount = (currentLife / maxLife);
    }

    public void UpdateTime(float currentTime)
    {
        timeTextHUD.text = FormatTime(currentTime);
    }

    public void Victory(float currentTime, bool mustShotNewRecord = false)
    {
        
        goHUD.SetActive(false);
        goVictory.SetActive(true);
        newRecord.SetActive(mustShotNewRecord);
        timeTextVictory.text = FormatTime(currentTime, true);
        GameManager.Instance.Gameover();
    }

    public void ButtonReplay()
    {
        GameManager.Instance.StartGame();
        SceneManager.LoadScene("Assets/ObjectPooling/Scenes/02_Game.unity");
    }

    public void ButtonMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Assets/ObjectPooling/Scenes/01_MainMenu.unity");
    }
}
