using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovementCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text value;
    private int moves;
    
    public void ResetValue()
    {
        moves = 0;
        value.text = 0.ToString();
    }
    public void Increase()
    {
        moves++;
        value.text = moves.ToString();
    }
}
