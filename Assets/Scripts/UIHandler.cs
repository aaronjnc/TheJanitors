using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;
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

    float GetReputation()
    {
        return reputation;
    }

    void SetPoints(int amount)
    {
        points = amount;
        pointDisplay.text = "" + points;
    }

    void AddPoints(int amount)
    {
        points += amount;
        pointDisplay.text = "" + points;
    }

    int GetPoints()
    {
        return points;
    }
    void TogglePause(CallbackContext ctx)
    {
        if (pauseOverlay.activeInHierarchy)
        {
            Debug.Log("toggling");
            pauseOverlay.SetActive(false);
            hudOverlay.SetActive(true);
        }
        else
        {
            pauseOverlay.SetActive(true);
            hudOverlay.SetActive(false);
        }

    }
}
