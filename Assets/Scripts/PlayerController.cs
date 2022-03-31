using UnityEngine;
using Yarn.Unity;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 3;
    private Rigidbody2D rb;
    private float input;

    private DialogueRunner dialogueRunner;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }
}
