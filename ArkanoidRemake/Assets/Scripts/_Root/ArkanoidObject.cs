using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArkanoidObject : MonoBehaviour
{
    protected ArkanoidState currentState;

    public void SetState(ArkanoidState thisState) => currentState = thisState;

    public void SetPosition(Vector2 newPosition) => this.transform.position = newPosition;
}
