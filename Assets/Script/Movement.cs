using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public bool Ground = true;
    private float jumpForce = 5f;
    private float VerticalInput;
    private float HorizontalInput;
    private Rigidbody rb;

    [SerializeField] AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * VerticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed * HorizontalInput);

        Jump();
    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Ground = true;
        }
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Ground)
        {
            jumpSound.Play();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Ground = false;
        }
    }
}
