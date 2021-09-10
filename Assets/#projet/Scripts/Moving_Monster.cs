using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Monster : Monster
{
    public Vector2 speed = Vector2.zero;
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;

    public float HitRange = 0.1f;
    Vector2 start;
    Vector2 direction;
    // speed.x = Input.GetAxis("Horizontal")
    // DetermineFacing(Vector2 speed)
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        // speed.x = Input.GetAxis("Horizontal");
        if (speed.x <0)
        {
            spriteRenderer.flipX = false;
            start = (Vector2)transform.position + Vector2.left *0.51f;
            direction = Vector2.left;
        }
        else
        {
            spriteRenderer.flipX = true;
            start = (Vector2)transform.position + Vector2.right *0.51f;
            direction = Vector2.right;
        }
        
        Debug.DrawRay(start, direction * HitRange, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(start, direction, HitRange);
        
        if (hit.collider != null)
        {
            speed.x *= -1;
        }
        //deplacement
        Vector2 deplacement = speed * Time.deltaTime;
        transform.position += (Vector3)deplacement;
    }
   
}
