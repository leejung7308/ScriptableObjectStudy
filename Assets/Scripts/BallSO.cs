using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
/// <summary>
/// Extendable enum
/// </summary>
[CreateAssetMenu(fileName = "BallSO", menuName = "SO/BallSO", order = 0)]
public class BallSO : ScriptableObject
{
    public BallSO weakness;
    public bool isWin(BallSO other)
    {
        return other.weakness == this;
    }
}
