using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    [SerializeField]public float speed;
    [SerializeField]public float direction; 
    [SerializeField]private SpriteRenderer _spriterenderer;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = -12f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(direction * speed * Time.deltaTime, rb.velocity.y);

        //if(direction < 0)
        //{
            //_spriterenderer.flipX = true;
        //} 
        //else if(direction < 0)
        //{
            //_spriterenderer.flipX = true;
        //}

        if (Input.GetKeyDown(KeyCode.Z) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}