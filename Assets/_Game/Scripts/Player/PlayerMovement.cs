using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Animator animator = null;
    [SerializeField] private Rigidbody2D rigidbody2d;

    private Vector2 inputMovement = Vector2.zero;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inputMovement.x = Input.GetAxisRaw("Horizontal");
        inputMovement.y = Input.GetAxisRaw("Vertical");

        if(animator != null ) Animate();
    }

    private void FixedUpdate()
    {
        if (!PlayerInventory.Instance.isMenuOpen)
        {
            rigidbody2d.MovePosition(rigidbody2d.position + inputMovement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void Animate()
    {
        animator.SetFloat("Horizontal", inputMovement.x);
        animator.SetFloat("Vertical", inputMovement.y);
        animator.SetBool("IsMoving", inputMovement.sqrMagnitude>0.1f?true:false);
    }

}
