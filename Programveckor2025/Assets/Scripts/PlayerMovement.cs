using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    KeyCode MoveRightKey;

    [SerializeField]
    KeyCode MoveLeftKey;

    [SerializeField]
    KeyCode MoveUpKey;

    [SerializeField]
    KeyCode MoveDownKey;

    [SerializeField]
    float playerSpeed;

    Rigidbody2D PlayerRigidbody;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        if (PlayerRigidbody == null)
        {
            Debug.LogWarning("Rigidbody2D not assinged to player");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRigidbody.velocity = new Vector2(0, 0);

        if (PlayerRigidbody != null)
        {
        if (Input.GetKey(MoveRightKey))
        {
            PlayerRigidbody.velocity = new Vector2((1 * playerSpeed), PlayerRigidbody.velocity.y);
                animator.SetFloat("Run", playerSpeed); 
        }
        else if (Input.GetKey(MoveLeftKey))
        {
            PlayerRigidbody.velocity = new Vector2((-1 * playerSpeed), PlayerRigidbody.velocity.y);
                animator.SetFloat("RunLeft", playerSpeed);
            }
        else if (Input.GetKey(MoveUpKey))
        {
            PlayerRigidbody.velocity = new Vector2(PlayerRigidbody.velocity.x, (1 * playerSpeed));
                animator.SetFloat("RunUp", playerSpeed);
            }
        else if (Input.GetKey(MoveDownKey))
        {
            PlayerRigidbody.velocity = new Vector2(PlayerRigidbody.velocity.x, (-1 * playerSpeed));
                animator.SetFloat("RunDown", playerSpeed);
            }
            else
            {
                animator.SetFloat("Run", 0f);
            }
        }
    }
}
