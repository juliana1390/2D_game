using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] 
    private GameObject particle;
    private Rigidbody2D shot;
    [SerializeField]
    private int speed;
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
            spawnerParticle();
            Destroy(this.gameObject);
        }
    }
    void spawnerParticle()
    {
        Instantiate(particle, transform.position, Quaternion.identity);
    }
}
