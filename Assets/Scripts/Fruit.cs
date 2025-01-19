using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fruit : MonoBehaviour
{
  // public event Action LevelLost3;
  [SerializeField] private List<Sprite> _sprites;
  [SerializeField] private List<int> _scores;
  [SerializeField] private Rigidbody2D _rigidbody2D;
  [SerializeField] private SpriteRenderer _fruitImage;

  private int _numberFruit;

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Cat"))
    {
      // LevelLost3?.Invoke();
      GameManager.Instance.GameOver();
      GameManager.Instance.Fruits.Remove(gameObject);
      Destroy(gameObject);
    }
    else if (collision.gameObject.CompareTag("ground"))
    {
      GameManager.Instance.ScoreView.UpdateScoreText4(_scores[_numberFruit]);
      GameManager.Instance.Fruits.Remove(gameObject);
      Destroy(gameObject);
    }
  }

  public void Init4(float fruitMass)
  {
    _numberFruit = Random.Range(0, 5);
    _fruitImage.sprite = _sprites[_numberFruit];
    _rigidbody2D.mass = fruitMass;
    GameManager.Instance.Fruits.Add(gameObject);
  }
}