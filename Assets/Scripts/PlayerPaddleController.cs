using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleController : MonoBehaviour
{
    public float speed = 5f;

    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        if (isPlayer)
            spriteRenderer.color = SaveController.instance.colorPlayer;
        else
            spriteRenderer.color = SaveController.instance.colorEnemy;
    }

    private void Update()
    {
        Vector3 newPosition = transform.position;

       
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += Vector3.up * speed * Time.deltaTime;
        }

     
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += Vector3.down * speed * Time.deltaTime;
        }

     
        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);

        transform.position = newPosition;
    }
}
