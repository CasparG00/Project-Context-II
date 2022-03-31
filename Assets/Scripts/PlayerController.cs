using UnityEngine;
using Yarn.Unity;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 3;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float input;

    private DialogueRunner dialogueRunner;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    private void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        
        if (!dialogueRunner.IsDialogueRunning)
        {
            rb.velocity = Vector2.right * (walkSpeed * input);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
        var velocity = rb.velocity;
        spriteRenderer.flipX = velocity.x > 0;
        animator.SetFloat("moveSpeed", velocity.sqrMagnitude);
    }
}
