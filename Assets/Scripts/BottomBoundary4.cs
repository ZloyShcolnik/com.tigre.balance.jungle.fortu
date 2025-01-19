using System;
using UnityEngine;

public class BottomBoundary4 : MonoBehaviour
{
  // public event Action LevelLost3;

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Cat"))
    {
      // LevelLost3?.Invoke();
      GameManager.Instance.GameOver();
    }
  }
}