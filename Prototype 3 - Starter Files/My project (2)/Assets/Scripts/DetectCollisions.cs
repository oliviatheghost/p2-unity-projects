using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollisions : MonoBehaviour
{
    GameObject enemy;
    void OnTriggerEnter(Collider other)
    {
        // filter out player, destroy only on collision with non-player objects. !!!!!!!!
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }


        // destroy only obstacles.
        
    }
}
