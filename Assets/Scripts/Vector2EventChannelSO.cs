using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Vector2EventChannelSO", menuName = "SO/Vector2EventChannelSO")]
public class Vector2EventChannelSO : ScriptableObject
{
    public event UnityAction<Vector2> OnEventRaised;
    public void RaiseEvent(Vector2 value)
    {
        if (OnEventRaised != null)
        {
            OnEventRaised.Invoke(value);
        }
    }
}
