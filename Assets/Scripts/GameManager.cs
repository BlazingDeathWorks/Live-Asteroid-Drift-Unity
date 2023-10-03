using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private Button _replayButton;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        Time.timeScale = 1;
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        _replayButton.gameObject.SetActive(true);
    }
}
