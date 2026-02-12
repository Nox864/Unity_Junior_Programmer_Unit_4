using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] public bool hasPowerup = false;
    [SerializeField] public bool hasMissile = false;
    [SerializeField] private float powerupStrngth;
    [SerializeField] GameObject powerupIndicator;
    [SerializeField] GameObject missile;

    private float missileSpeed = 25.0f;

    private Rigidbody rb;
    private Vector3 powerupIndicatorOffset = new Vector3(0, -0.6f, 0);



    void Start()
    {
        rb = GetComponent<Rigidbody>();

        
    }

    
    void Update()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");


        rb.AddForce(Vector3.forward * forwardInput * speed + Vector3.right * horizontalInput * speed);

        powerupIndicator.transform.position = transform.position + powerupIndicatorOffset;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.position = new Vector3(0, 0, 0);
            rb.linearVelocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine("PowerupCountdownRoutine");
            powerupIndicator.SetActive(true);
        }
        if (other.CompareTag("PowerupMissile"))
        {
            hasMissile = true;
            Destroy(other.gameObject);
            powerupIndicator.SetActive(true);

            
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            for (int i = 0; i < enemies.Length; i++)
            {
                
                GameObject miss = Instantiate(missile, transform.position + Vector3.up, Quaternion.identity);

                
                Vector3 missileDir = (enemies[i].transform.position - transform.position).normalized;

                
                Rigidbody missileRb = miss.GetComponent<Rigidbody>();

                if (missileRb != null)
                {
                    
                    miss.transform.forward = missileDir;

                    
                    missileRb.AddForce(missileDir * missileSpeed, ForceMode.Impulse);
                }

                
                Destroy(miss, 5f);
            }

            StartCoroutine("MissilePowerupCountdownRoutine");
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;
        powerupIndicator.SetActive(false);

    }

    IEnumerator MissilePowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasMissile = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * powerupStrngth, ForceMode.Impulse);

            
        }
    }
}
