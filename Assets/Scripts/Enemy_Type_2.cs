using UnityEngine;

public class Enemy_Type_2 : MonoBehaviour
{

    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float strength;

    private GameObject player;
    private Rigidbody rb;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Vector3 playerDir = (player.transform.position - transform.position).normalized;

        rb.AddForce(playerDir * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !player.GetComponent<PlayerController>().hasPowerup)
        {
            Rigidbody playerRb = player.GetComponent<Rigidbody>();

            Vector3 awayFromEnemy = collision.gameObject.transform.position - transform.position;

            playerRb.AddForce(awayFromEnemy * strength, ForceMode.Impulse);
        }        
    }
}
