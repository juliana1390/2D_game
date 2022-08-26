using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D player;

    private float movePlayer;

    public float speed, jumpForce;
    private bool jump, isGrounded, restartPlayer;
    private GameObject cameraPos, initialPos;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        cameraPos = GameObject.Find("Main Camera");
        initialPos = GameObject.Find("initialPos");
    }

    // Update is called once per frame
    void Update()
    {
        print(restartPlayer);
        movePlayer = Input.GetAxis("Horizontal");
        jump = Input.GetButtonDown("Jump");
        player.velocity = new Vector2(movePlayer*speed, player.velocity.y);
        if (jump == true && isGrounded == true)
        {
            player.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }
        Restart();
    }

    private void OnCollisionEnter2D(Collision2D col) // it avoids several jumps in the air before touching the ground
    {
        if (col.gameObject.layer == 8)
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("armadilhas") == true)
        {
            restartPlayer = true;
        }
    }
    private void Restart()
    {
        if (restartPlayer == true)
        {
            player.transform.position = new Vector2(initialPos.transform.position.x, initialPos.transform.position.y);
            restartPlayer = false;
        }
    }
}
