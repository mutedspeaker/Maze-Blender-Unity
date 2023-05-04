using UnityEngine;

public class tilt : MonoBehaviour
{
    [SerializeField] private float tiltSpeed = 20f;
    [SerializeField] private float tiltThreshold = 20f;
    [SerializeField] private float maxTiltAngle = 45f;

    private float accumulatedTiltX = 0f;
    private float accumulatedTiltY = 0f;

    private void Update()
    {
        float tiltInputX = Input.GetAxis("Horizontal");
        float tiltInputY = Input.GetAxis("Vertical");

        if (Mathf.Abs(tiltInputX) > 0.3f)
        {
            accumulatedTiltX += tiltInputX * tiltSpeed * Time.deltaTime;
        }

        if (Mathf.Abs(tiltInputY) > 0.3f)
        {
            accumulatedTiltY += tiltInputY * tiltSpeed * Time.deltaTime;
        }

        float newTiltAngleX = Mathf.Clamp(accumulatedTiltX, -maxTiltAngle, maxTiltAngle);
        float newTiltAngleY = Mathf.Clamp(accumulatedTiltY, -maxTiltAngle, maxTiltAngle);

        Quaternion targetRotation = Quaternion.Euler(newTiltAngleY, transform.eulerAngles.y, -newTiltAngleX);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, tiltSpeed * Time.deltaTime);

        accumulatedTiltX = Mathf.MoveTowards(accumulatedTiltX, newTiltAngleX, tiltThreshold * Time.deltaTime);
        accumulatedTiltY = Mathf.MoveTowards(accumulatedTiltY, newTiltAngleY, tiltThreshold * Time.deltaTime);

        // Added code for left, right, up, down buttons
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            accumulatedTiltX += tiltSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            accumulatedTiltX -= tiltSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            accumulatedTiltY -= tiltSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            accumulatedTiltY += tiltSpeed * Time.deltaTime;
        }
    }
}
