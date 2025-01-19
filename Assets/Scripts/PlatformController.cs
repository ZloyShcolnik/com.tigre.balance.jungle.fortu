using UnityEngine;

public class PlatformController : MonoBehaviour
{
  public Transform platform;
  public Transform cat;
  public float tiltSpeed;
  public float maxTiltAngle;

  private Rigidbody2D catRb;

  private Vector3 _startCatPosition;
  private Quaternion _startPlatformRotation;

  private void Start()
  {
    _startPlatformRotation = platform.localRotation;
    _startCatPosition = cat.position;
    catRb = cat.GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
    if (Input.touchCount > 0)
    {
      Touch touch4 = Input.GetTouch(0);
      if (touch4.position.x < Screen.width / 2)
      {
        TiltPlatform(1);
      }
      else if (touch4.position.x > Screen.width / 2)
      {
        TiltPlatform(-1);
      }
    }
  }

  public void SetStartPositions()
  {
    platform.localRotation = _startPlatformRotation;
    cat.position = _startCatPosition;
  }

  private void TiltPlatform(int direction)
  {
    float currentAngle = platform.eulerAngles.z;
    if (currentAngle > 180) currentAngle -= 360;

    float newAngle = Mathf.Clamp(currentAngle + direction * tiltSpeed * Time.deltaTime, -maxTiltAngle, maxTiltAngle);
    platform.rotation = Quaternion.Euler(0, 0, newAngle);
  }
}