using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameMenu : MonoBehaviour
{
    [SerializeField]
    TMP_Text escaped, eliminated, reputation;
    
    public void SetValues(int escapedNum, int eliminatedNum, float reputationNum)
    {
        escaped.text = "Escaped: " + escapedNum;
        eliminated.text = "Eliminated: " + eliminatedNum;
        reputation.text = "Reputation: " + reputationNum;
    }
}
