using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEffects : MonoBehaviour
{
	[SerializeField]
    private Transform platform;
	[SerializeField]
	private float speed;
	[SerializeField]
	private Transform[] currentPosition;
	private int idPos;
	

    // Start is called before the first frame update
    void Start()
    {
        platform.position = currentPosition[0].position;
		idPos = 1;
    }

    // Update is called once per frame
    void Update()
    {
		platform.position = Vector3.MoveTowards(platform.position, currentPosition[idPos].position, speed * Time.deltaTime);
	        
		if(platform.position == currentPosition[idPos].position)
		{
			idPos += 1; // goes to next position
		}
		if(idPos == currentPosition.Length)
		{
			idPos = 0;	
		}
    }
	
}
