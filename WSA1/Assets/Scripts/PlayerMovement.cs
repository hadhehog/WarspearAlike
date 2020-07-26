using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    move,
    attack,
    stagger,
    idle
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
        if (Input.GetButtonDown("Attack") && 
            currentState != PlayerState.attack &&
                currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCor());
        }

        else if (currentState == PlayerState.move || 
            currentState == PlayerState.idle)
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

    public void Knock(float knockTime)
    {
        StartCoroutine(KnockCo(knockTime));
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (rb != null)
        {
            yield return new WaitForSeconds(knockTime);
            rb.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            rb.velocity = Vector2.zero;
        }
    }
}