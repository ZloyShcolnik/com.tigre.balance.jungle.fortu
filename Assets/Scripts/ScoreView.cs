using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreView : MonoBehaviour
{
  public int Score { get; private set; }
  public bool IsNeedScoreReset { get; set; }
  
  [SerializeField] private TextMeshProUGUI _levelScore;
  [SerializeField] private TextMeshProUGUI _winScore;
  // [SerializeField] private BlockVisibilityToggle3 _winBlockVisibilityToggle1;
  // [SerializeField] private BlockVisibilityToggle3 _restartWinBlockVisibilityToggle1;
  // [SerializeField] private BlockVisibilityToggle3 _restartLoseBlockVisibilityToggle1;

  private int _levelNumber4;

  // private void Awake()
  // {
  //   _winBlockVisibilityToggle1.OnBlocksToggled3 += OnWinButtonClicked;
  //   _restartWinBlockVisibilityToggle1.OnBlocksToggled3 += OnWinButtonClicked;
  //   _restartLoseBlockVisibilityToggle1.OnBlocksToggled3 += OnWinButtonClicked;
  // }

  private void OnEnable()
  {
    if (IsNeedScoreReset)
    {
      Score = 0;
      UpdateScoreText4(0);
    }
  }

  public void UpdateScoreText4(int score)
  {
    Score += score;
    _levelScore.text = $"SCORE: {Score}";
    _winScore.text = _levelScore.text;
  }

  // private void OnWinButtonClicked()
  // {
  //   Score = 0;
  //   UpdateScoreText(0);
  // }
}