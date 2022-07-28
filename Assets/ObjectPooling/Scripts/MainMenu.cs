using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text bestTimeText;

    private void Awake()
    {
        if (GameManager.Instance == null) return;
        if (GameManager.Instance.bestTime == 0f) return;
        bestTimeText.text = FormatTime(GameManager.Instance.bestTime);
    }
    
    private string FormatTime(float time)
    {
        int minutes = (int) (time / 60);
        int seconds = (int) (time - (60 * minutes));
        int milliseconds = (int) ((time - (minutes * 60) - seconds) * 100);
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void Play()
    {
        SceneManager.LoadScene("Assets/ObjectPooling/Scenes/02_Game.unity");
    }

    public void Exit()
    {
         #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
         #else
            Application.Quit();
         #endif
    }
}
