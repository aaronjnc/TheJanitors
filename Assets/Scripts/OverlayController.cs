using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIController : MonoBehaviour
{
    [SerializeField]
    private float reputation;
    [SerializeField] private int points; 

    [SerializeField] private Slider sliderBar;
    [SerializeField] private TMP_Text pointDisplay;
    

    void Start()
    {
           
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
}
