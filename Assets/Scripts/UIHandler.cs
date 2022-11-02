using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.SceneManagement;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private float reputation = 50;
    [SerializeField] private int points;
    private int AliensRemaining = 5;

    [SerializeField] private Slider sliderBar;
    [SerializeField] private TMP_Text pointDisplay;
    [SerializeField] private TMP_Text alienDisplay;

    [SerializeField]
    private GameObject pauseOverlay, hudOverlay, settings, endOverlay;

    private InputController controller;

    bool paused = false;

    void Start()
    {
        reputation = 50;
        controller = new InputController();

        controller.UI.Pause.performed += TogglePause;
        controller.UI.Pause.Enable();
    }


    public void SetReputation(float value)
    {
        reputation = Mathf.Clamp(value, 0, 100);
        sliderBar.value = reputation;
        if (reputation <= 0)
        {
            EndGame();
        }
    }

    public void AddReputation(float value)
    {
        SetReputation(value + reputation);
    }

    public float GetReputation()
    {
        return reputation;
    }

    public void SetPoints(int amount)
    {
        points = amount;
        pointDisplay.text = "Points: " + points;
    }

    public void AddPoints(int amount)
    {
        SetPoints(points + amount);
    }

    public void RemoveAlien()
    {
        AliensRemaining--;
        alienDisplay.text = "Aliens: " + AliensRemaining;
        if (AliensRemaining == 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        int aliensKilled = points/20;
        endOverlay.GetComponent<EndGameMenu>().SetValues(5-aliensKilled, aliensKilled, reputation);
        endOverlay.SetActive(true);
        hudOverlay.SetActive(false);
        pointDisplay.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public int GetPoints()
    {
        return points;
    }
    public void TogglePause(CallbackContext ctx)
    {
        paused = !paused;
        pauseOverlay.SetActive(paused);
        if (paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

    }

    //Wrapper function for ease of use for calling from a button
    public void ResumeButton()
    {
        TogglePause(new CallbackContext());
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void SettingButton()
    {
        settings.SetActive(true);
        pauseOverlay.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
