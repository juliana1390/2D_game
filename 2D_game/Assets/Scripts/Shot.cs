using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
	/*void Start()
	{
		GetComponent<Rigidbody2D>().AddForce(transform.left * 1000);
		Destroy(gameObject, 2);
	}*/
    private Rigidbody2D shot;
	
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        shot = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        shot.velocity = new Vector2(speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
		
        if (col.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }
    }
}
