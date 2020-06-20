using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArkanoidObject : MonoBehaviour
{
    public ArkanoidState CurrentState { get; set; }

    public void SetPosition(Vector2 newPosition) => this.transform.position = newPosition;
}
