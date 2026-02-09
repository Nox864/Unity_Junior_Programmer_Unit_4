using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float speed = 3.0f;

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
    }
}
