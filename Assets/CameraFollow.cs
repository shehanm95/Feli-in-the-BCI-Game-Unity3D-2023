using UnityEngine;

public class CameraFollow: MonoBehaviour
    {
    public Transform target; // Player's Transform
    public float smoothTime = 0.3f; // Smoothing time for camera follow
    public float zoomSpeed = 2f; // Speed of zooming
    public float maxFOV = 60f; // Maximum field of view
    public float minFOV = 30f; // Minimum field of view
    public float xOffSet = 0f; // X offset from the player
    public float yOffSet = 0f; // Y offset from the player

    private Vector3 velocity = Vector3.zero;
    private Camera mainCamera;

    void Start ( )
        {
        mainCamera = Camera.main;
        }

    void LateUpdate ( )
        {
        if (target != null)
            {
            // Calculate target position with offsets
            Vector3 targetPosition = new Vector3(target.position.x + xOffSet, target.position.y + yOffSet, transform.position.z);

            // Smoothly follow the player
            transform.position = Vector3.SmoothDamp ( transform.position,targetPosition,ref velocity,smoothTime );

            // Calculate player speed
            float speed = target.GetComponent<Rigidbody2D>().velocity.magnitude;

            // Zoom based on player movement
            float targetFOV = speed > 0.1f ? maxFOV :minFOV ;

            // Adjust the camera's field of view
            mainCamera.fieldOfView = Mathf.MoveTowards ( mainCamera.fieldOfView,targetFOV,Time.deltaTime * zoomSpeed );
            }
        }
    }
