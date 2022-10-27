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
    private float reputation;
    [SerializeField] private int points;

    [SerializeField] private Slider sliderBar;
    [SerializeField] private TMP_Text pointDisplay;

    [SerializeField]
    private GameObject pauseOverlay, hudOverlay;

    private InputController controller;

    void Start()
    {
        controller = new InputController();

        controller.UI.Pause.performed += TogglePause;
        controller.UI.Pause.Enable();
    }


    public void SetReputation(float value)
    {
        reputation = value;
        sliderBar.value = reputation;
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
        pointDisplay.text = "" + points;
    }

    public void AddPoints(int amount)
    {
        points += amount;
        pointDisplay.text = "" + points;
    }

    public int GetPoints()
    {
        return points;
    }
    public void TogglePause(CallbackContext ctx)
    {
        pauseOverlay.SetActive(!pauseOverlay.activeInHierarchy);
        
        /*
            if (pauseOverlay.activeInHierarchy)
            {
                Debug.Log("toggling");
                pauseOverlay.SetActive(false);
                //hudOverlay.SetActive(true);
            }
            else
            {
                pauseOverlay.SetActive(true);
                //hudOverlay.SetActive(false);
            }
        */

    }

    //Wrapper function for ease of use for calling from a button
    public void ResumeButton()
    {
        TogglePause(new CallbackContext());
    }

    public void MainMenuButton()
    {
        Debug.Log("Set Scene to Main here!");
    }

    public void SettingButton()
    {
        Debug.Log("Show Settings Prefab");
    }
}
