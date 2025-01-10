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
    // Start is called before the first frame update
    void Start()
    {
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
        }
        if (Input.GetKey(MoveLeftKey))
        {
            PlayerRigidbody.velocity = new Vector2((-1 * playerSpeed), PlayerRigidbody.velocity.y);
        }
        if (Input.GetKey(MoveUpKey))
        {
            PlayerRigidbody.velocity = new Vector2(PlayerRigidbody.velocity.x, (1 * playerSpeed));
        }
        if (Input.GetKey(MoveDownKey))
        {
            PlayerRigidbody.velocity = new Vector2(PlayerRigidbody.velocity.x, (-1 * playerSpeed));
        }
        }
    }
}
