using UnityEngine;

public class CatMagnet : MonoBehaviour
{
  public Transform platform;
  public float stickingForce = 20f;

  private Rigidbody2D catRb;

  private void Start()
  {
    catRb = GetComponent<Rigidbody2D>();
  }

  private void FixedUpdate()
  {
    Vector2 platformUp = platform.up;
    Vector2 forceDirection = -platformUp.normalized;
    catRb.AddForce(forceDirection * stickingForce, ForceMode2D.Force);
    catRb.rotation = 0f;
  }
}