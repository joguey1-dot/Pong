using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2PaddleController : MonoBehaviour
{
    public float speed = 5f;

    public SpriteRenderer spriteRenderer;

  
    public bool isPlayer = false;

    private void Start()
    {
      
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Aplica a cor do SaveController
        if (isPlayer)
        {
            spriteRenderer.color = SaveController.instance.colorPlayer;
        }
        else
        {
           
            spriteRenderer.color = SaveController.instance.colorEnemy;
        }
    }

    private void Update()
    {
        Vector3 newPosition = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            newPosition += Vector3.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            newPosition += Vector3.down * speed * Time.deltaTime;
        }

        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);

        transform.position = newPosition;
    }
}