using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> stages;
    [SerializeField] private int startStage = 1;
    [SerializeField] private Transform startPos;

    private bool isPaused = false;

    private void Start()
    {
        
    }

    public void PauseGame()
    {
        if (isPaused) return;
        isPaused = true;

        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        if (!isPaused) return;
        isPaused = false;

        Time.timeScale = 1f;
    }
}
