using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;

    [SerializeField] private Text movesCounterText;

    private void Awake()
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

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        movesCounterText.text = "0";
    }

    public void UpdateMovesCounterText()
    {
        movesCounterText.text = GameManager.Instance.GetMovesCounterInfo().ToString();
    }

    public void Restart()
    {
        GameManager.Instance.Restart();
    }
}
