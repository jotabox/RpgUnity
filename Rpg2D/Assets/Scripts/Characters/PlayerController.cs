using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float interactionRadius = 1f;


    private Rigidbody2D _rigidBody;


    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerMovement();

       if(Input.GetKeyDown(KeyCode.Space))
        {
            TryInteract();
        }
    }

    private void PlayerMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized;
        // impede movimento na diagonal
        if (movement.x != 0)
        {
            movement.y = 0;
        }

        _rigidBody.velocity = movement * moveSpeed;
    }

    private void TryInteract()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactionRadius);

        foreach(Collider2D hit in hits)
        {
            if(hit.CompareTag("Interactable"))//aqui eu verifico se o objeto encontrado é interagível
            {
                hit.GetComponent<IInteractable>().Interact(); //chamando a função de interagir
                break; //interage apenas com o 1 objeto encontrado
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        //desenha o raio , só pra debug
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
