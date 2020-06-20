using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingController : MonoBehaviour
{
    private Camera MainCamera => Camera.main;
    private Vector2 DefaultPosition => this.transform.position;

    //Movement variables
    private float shift, newPositionX, mousePositionX;
    private void Update()
    {
        if (!GameController.isGameRunning) return;
        Movement();
    }
    private void Movement()
    {
        shift = this.GetComponent<SpriteRenderer>().size.x / 4;
        newPositionX = MainCamera.ScreenToWorldPoint(Input.mousePosition).x;
        mousePositionX = Mathf.Clamp(newPositionX, GameData.ResMinX + shift, GameData.ResMaxX - shift);
        this.transform.position = new Vector3(mousePositionX, DefaultPosition.y, 0);
    }
}
