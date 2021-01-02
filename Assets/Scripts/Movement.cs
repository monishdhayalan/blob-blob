using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody2D rigidbody2d;

    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpPower = 10f;

    [Header("Bools")]
    [SerializeField] bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 Move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += Move * Time.deltaTime * moveSpeed;
        Jump();

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rigidbody2d.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
            isGrounded = false;
            //StartCoroutine(QuickFall());
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }

}
