using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rb;
    float dirHorizontal;
    float dirVertical;
    [SerializeField] float speed;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirHorizontal = Input.GetAxis("Horizontal");
        dirVertical = Input.GetAxis("Vertical");

        movement.x = dirHorizontal;
        movement.y = dirVertical;
        movement.Normalize();
        movement *= 5* speed;

        rb.velocity = movement;

    }
}
