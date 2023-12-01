using UnityEngine;

public class ScreenSplitter : MonoBehaviour
{
    // Adjust this threshold to determine the split between left and right sides
    public float splitThreshold = 0.5f;

    // Speed at which the player moves to the side
    public float moveSpeed = 5f;

    void Update()
    {
        // Check if there is any touch input
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Check if the touch phase is the beginning of a touch
            if (touch.phase == TouchPhase.Began)
            {
                // Get the touch position in screen coordinates
                Vector3 touchPosition = touch.position;

                // Cast a ray from the camera through the touch position
                Ray ray = Camera.main.ScreenPointToRay(touchPosition);
                RaycastHit hit;

                // Check if the ray hits something
                if (Physics.Raycast(ray, out hit))
                {
                    // Check if the hit object has the "Player" tag
                    if (hit.collider.CompareTag("Player"))
                    {
                        // Move the player to the left or right based on the touch position
                        MovePlayer(touchPosition.x);
                    }
                }
            }
        }
    }

    void MovePlayer(float touchX)
    {
        // Determine the target position based on touchX
        float targetX = (touchX < Screen.width * splitThreshold) ? -10f : 10f; // Adjust the values based on your scene

        // Find the GameObject with the "Player" tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Move the player smoothly to the target position
        Vector3 targetPosition = new Vector3(targetX, player.transform.position.y, player.transform.position.z);
        player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
