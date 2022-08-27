using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D player;

    private float movePlayer;

    public float speed, jumpForce, cameraHeight, winSpeed;
    private bool jump, isGrounded, restartPlayer, win;
    private GameObject cameraPos, initialPos;
    public GameObject winPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        cameraPos = GameObject.Find("Main Camera");
        initialPos = GameObject.Find("initialPos");
        win = false;
    }

    // Update is called once per frame
    void Update()
    {
        print(win);
        movePlayer = Input.GetAxis("Horizontal");
        jump = Input.GetButtonDown("Jump");
        cameraPos.transform.position = new Vector3(cameraPos.transform.position.x, player.transform.position.y + cameraHeight, cameraPos.transform.position.z);
        player.velocity = new Vector2(movePlayer*speed, player.velocity.y);
        if (jump == true && isGrounded == true)
        {
            player.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }

        Restart();
        winGame();
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

        if (col.CompareTag("win") == true)
        {
            win = true;
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

    private void winGame()
    {
        if (win == true)
        {
            player.velocity = new Vector2(0, player.velocity.y);
            winPanel.transform.position = Vector2.MoveTowards(winPanel.transform.position, cameraPos.transform.position, winSpeed * Time.deltaTime);
        }
    }
}
