using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;

    private Rigidbody rb;
    private GameObject focalPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        focalPoint = GameObject.Find("Focal Point");
    }

    
    void Update()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");

        rb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.position = new Vector3(0, 0, 0);
            rb.linearVelocity = Vector3.zero;
        }
    }
}
