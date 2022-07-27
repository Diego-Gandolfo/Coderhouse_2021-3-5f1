using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text bestGameText;

    private void Awake()
    {
        if (GameManager.Instance == null) return;
        bestGameText.text = GameManager.Instance.bestGame.ToString();
    }
    
    public void Play()
    {
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
