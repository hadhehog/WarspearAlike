using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    move,
    attack
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D rb;
    private Vector3 change;
    private Animator anim;

    void Start()
    {
        currentState = PlayerState.move;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetFloat("moveX", 0);
        anim.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.Normalize();
        change.x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        change.y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCor());
        }

        else if (currentState == PlayerState.move)
        {
            MovementAnimationUpdate();
        }
    }

    private IEnumerator AttackCor()
    {
        anim.SetBool("isAttacking", true);
        currentState = PlayerState.attack;
        yield return null;
        anim.SetBool("isAttacking", false);
        yield return new WaitForSeconds(0.25f);
        currentState = PlayerState.move;
    }

    void MovementAnimationUpdate()
    {
        if (change != Vector3.zero)
        {
            transform.Translate(new Vector3(change.x, change.y));
            anim.SetFloat("moveX", change.x);
            anim.SetFloat("moveY", change.y);

            anim.SetBool("isMoving", true);
        }

        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}