using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D player;

    private float movePlayer;

    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(movePlayer*speed, player.velocity.y);
    }
}
