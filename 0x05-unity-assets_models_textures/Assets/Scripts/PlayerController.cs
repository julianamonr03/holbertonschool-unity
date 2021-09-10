using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 2000f;
    public bool isGrounded;
    public float jump = 7000f;
    public float distance = -15f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
           rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
           rb.AddForce(0, 0, -speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }

        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(0, jump * Time.deltaTime, 0);
            isGrounded = false;
        }

        if (transform.position.y < distance)
        {
            transform.position = new Vector3(0, 20, 0);
        }
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
}

