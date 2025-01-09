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

    Rigidbody2D PlayerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(MoveRightKey))
        {
            PlayerRigidbody.velocity = new Vector2(1, 0);
        }
        if (Input.GetKey(MoveLeftKey))
        {
            PlayerRigidbody.velocity = new Vector2(-1, 0);
        }
    }
}
