using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public bool goingLeft;
    public float speed;
    public bool hasHitSomething;
    void Update()
    {
        if(hasHitSomething == false)
        {
            if(goingLeft)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "ArrowTrap")
        {
            Physics2D.IgnoreCollision(other.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else if(other.gameObject.tag == "Player")
        {
            hasHitSomething = true;
        }
        else
        {
            if(hasHitSomething == false)
            {
                hasHitSomething = true;
                Transform transform = GetComponent<Transform>();
                BoxCollider2D bc2d = GetComponent<BoxCollider2D>();
                Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
                transform.gameObject.tag = "Untagged";
                bc2d.isTrigger = false;
                rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }
}
