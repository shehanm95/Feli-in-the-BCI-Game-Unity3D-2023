using UnityEngine;

public class PlayerThrow: MonoBehaviour
    {
    public GameObject projectilePrefab;
    public Transform muzzel;
    public float throwForce = 10f;
    PlayerController player;

    private void Start ( )
        {
        player = GetComponent<PlayerController> ( );
        }
    void Update ( )
        {
        
        if (Input.GetMouseButtonDown ( 0 ))
            {
            Plane plane = new Plane(Vector3.back, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast ( ray,out float enter )) {
                Vector3 worldPosition = ray.GetPoint(enter);
                ThrowObject ( worldPosition );
                // Now you have the world position you wanted.
                }
            // Call a method to throw something towards the clicked position
            
            }
        }

    void ThrowObject ( Vector3 targetPosition )
        {

        if ((transform.localScale.x == -1 && targetPosition.x < transform.position.x - 0.5) || (transform.localScale.x == 1 && targetPosition.x > transform.position.x + 0.5))
            {
            // Assuming you have a projectile prefab
            GameObject projectile = Instantiate(projectilePrefab, muzzel.position, Quaternion.identity);

            // Calculate the direction to throw the projectile
            Vector2 throwDirection = (targetPosition - muzzel.position).normalized;

            // Apply force to throw the projectile
            projectile.GetComponent<Rigidbody2D> ( ).AddForce ( throwDirection * throwForce,ForceMode2D.Impulse );
            }
        }
    }
