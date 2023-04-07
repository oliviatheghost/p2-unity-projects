using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5.0f;
    private GameObject focalPoint;
    private bool hasPowerup;  //player power up status
    public float PowerupStrength = 999.0f; // how much strange the player has with powerup.
    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        // focalPoint means the its the focus point of the camera 
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward* speed  * forwardInput);
        // making the player able to move front and back
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    // OnTriggerEnter is called on the first frame that we collide with trigger
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true; 
            powerupIndicator.gameObject.SetActive(true);             
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

        IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(7);
            hasPowerup = false;
            powerupIndicator.gameObject.SetActive(false);
            // has power up for 7 seconds and then goes away.
        }


    // when object collides with another object, cause and effect.
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy")&& hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            
            enemyRigidbody.AddForce(awayFromPlayer * PowerupStrength, ForceMode.Impulse);
            Debug.Log("We crashed into" + collision.gameObject.name + " and our Powerup status is " + hasPowerup + ".");
        }
    }
}
