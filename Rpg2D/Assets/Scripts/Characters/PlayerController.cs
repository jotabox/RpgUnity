using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float interactionRadius = 1f;

    [Header("Input Keys")]
    [SerializeField] private KeyCode interactKey = KeyCode.Space;
    [SerializeField] private KeyCode runKey = KeyCode.LeftShift;

    private Rigidbody2D _rigidBody;
    private Vector2 _currentMovement;
    private bool _isRunning;
    private Inventory _inventory;


    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        HandleInput();
        TryInteract();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }
    private void HandleInput()
    {
        //captura o movimento
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //_currentMovement = (moveX != 0) ? new Vector2(moveX, 0) : new Vector2(moveY, 0);
        _currentMovement = new Vector2(moveX, moveY).normalized;

        if (_currentMovement.x != 0)
        {
            _currentMovement.y = 0;
        }

        //_currentMovement.Normalize();

        _isRunning = Input.GetKey(runKey);
    }

    private void MoveCharacter()
    {
        float speed = _isRunning? runSpeed: walkSpeed;
        _rigidBody.velocity = _currentMovement * speed;
    }

    private void TryInteract()
    {

        if (!Input.GetKeyDown(interactKey)) return;    

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactionRadius);

        foreach(Collider2D hit in hits)
        {
            if (!hit.CompareTag("Interactable")) continue;

            if(hit.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
                break;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        //desenha o raio , só pra debug
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Item"))
        {
            if(collision.TryGetComponent(out ItemHolder itemHolder))
            {
                _inventory.AddItem(itemHolder.itemData);
                Destroy(collision.gameObject);
                Debug.Log($"Item coletado: {itemHolder.itemData.itemName}");
            }
        }
    }

}
