using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 3;
    private Rigidbody2D rb;
    private float input;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        rb.velocity = Vector2.right * (walkSpeed * input);
    }
}
