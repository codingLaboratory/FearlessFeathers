using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    [SerializeField] private InputAction playerControls;
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private float moveSpeed;

    void Update()
    {
        moveDirection = playerControls.ReadValue<Vector2>();
        if (moveDirection != Vector2.zero){
            animator.SetBool("moving", true);
            animator.SetFloat("moveX", moveDirection.x);
            animator.SetFloat("moveY", moveDirection.y);
        } else {
            animator.SetBool("moving", false);
        }
    }

    void FixedUpdate(){
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void OnEnable(){
        playerControls.Enable();
    }

    private void OnDisable(){
        playerControls.Disable();
    }
}
