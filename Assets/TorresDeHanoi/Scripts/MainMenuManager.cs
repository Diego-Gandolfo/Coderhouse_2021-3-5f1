using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;

    [SerializeField] private Text bestGameText;

    private void Awake()
    {
        InitializeSingleton();

        if (GameManager.Instance == null) return;
        bestGameText.text = GameManager.Instance.GetBestGameInfo().ToString();
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

    public void Play()
    {
        GameManager.Instance.ResetMovesCounter();
        SceneManager.LoadScene("02_Game");
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
