using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 50.0f;
    private float forwardBound = -30; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector3.forward * Time.deltaTime * speed); 

      if (transform.position.x < forwardBound && gameObject.CompareTag("Obstacle"))
        {
        Destroy(gameObject);
        }
    }  

    
    
}
