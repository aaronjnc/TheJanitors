using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreUI;

    // Start is called before the first frame update
    void Start()
    {
        scoreUI.text = score.ToString() + " points";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
