using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    


    private Rigidbody2D _rigidBody;


    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized;
        // impede movimento na diagonal
        if(movement.x != 0)
        {
            movement.y = 0;
        }

        _rigidBody.velocity = movement * moveSpeed;
    }
}
