using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager4 : MonoBehaviour
{
  [SerializeField] private GameObject _winView;
  [SerializeField] private GameObject _loseView;
  [SerializeField] private LevelTimer4 _levelTimer4;
  [SerializeField] private LevelButtonController4 _levelButtonController4;
  [SerializeField] private RecordsView4 _recordsView4;
  [SerializeField] private ScoreView _scoreView;
  [SerializeField] private TrophiesView _trophiesView;
  [SerializeField] private GameObject _permanentScene2;
  [SerializeField] private BlockVisibilityToggle4 _gameOptionsButtonBlockVisibilityToggle1;
  [SerializeField] private BlockVisibilityToggle4 _backToGameButtonBlockVisibilityToggle1;
  [SerializeField] private BlockVisibilityToggle4 _backToMenuButtonBlockVisibilityToggle1;
  [SerializeField] private BlockVisibilityToggle4 _tutorialBlockVisibilityToggle3;
  [SerializeField] private PlatformController _platformController;
  [SerializeField] private TextMeshProUGUI _levelNumberText;
  [SerializeField] private TextMeshProUGUI _winLevelNumberText;
  [SerializeField] private TextMeshProUGUI _loseLevelNumberText;

  private int _currentLevelNumber4;

  private void Awake()
  {
    _levelTimer4.LevelWon4 += OnWin4;
    // _bottomBoundary.LevelLost3 += OnLose3;
    
    _gameOptionsButtonBlockVisibilityToggle1.OnBlocksToggled4 += OnGameOptionsButtonClicked;
    _backToGameButtonBlockVisibilityToggle1.OnBlocksToggled4 += BackToGameOptionsButtonClicked;
  }

  private void OnEnable()
  {
    if (PlayerPrefs.GetInt("TutorialCompleted") != 1)
    {
      _tutorialBlockVisibilityToggle3.gameObject.SetActive(true);
      _tutorialBlockVisibilityToggle3.OnBlocksToggled4 += TutorialButtonClicked;
    }
    else
    {
      _levelTimer4.StartTimer4();
      GameManager.Instance.StartSpawnFruit();
    }
  }

  private void Start()
  {
    _backToMenuButtonBlockVisibilityToggle1.OnBlocksToggled4 += OnBackToMenuButtonClicked;
    GameManager.Instance.LevelLost4 += OnLose4;
  }

  public void SetLevelNumber(int lvlnum)
  {
    _currentLevelNumber4 = lvlnum;
    _levelNumberText.text = $"LEVEL: {lvlnum}";
    _winLevelNumberText.text = _levelNumberText.text;
    _loseLevelNumberText.text = _levelNumberText.text;
  }

  private void OnLose4()
  {
    _levelTimer4.StopTimer4();
    _levelTimer4.ResetTimerValue4();
    SetGameplayStartsPositions4();
    _loseView.SetActive(true);
    _permanentScene2.SetActive(false);
    _recordsView4.UpdateRecords4(_scoreView.Score);
    _scoreView.IsNeedScoreReset = true;
    GameManager.Instance.CancelFruitSpawn();
    gameObject.SetActive(false);
  }

  private void OnWin4()
  {
    AddTrophy();
    SaveCompletedLevel4();
    _levelTimer4.StopTimer4();
    _levelTimer4.ResetTimerValue4();
    SetGameplayStartsPositions4();
    _winView.SetActive(true);
    _permanentScene2.SetActive(false);
    _recordsView4.UpdateRecords4(_scoreView.Score);
    _scoreView.IsNeedScoreReset = true;
    GameManager.Instance.CancelFruitSpawn();
    gameObject.SetActive(false);
  }

  private void AddTrophy()
  {
    if (PlayerPrefs.GetInt("Level4" + (_currentLevelNumber4 - 1)) != 2)
      if (_currentLevelNumber4 % 2 == 0)
        _trophiesView.EnableTrophy();
  }

  private void SaveCompletedLevel4()
  {
    PlayerPrefs.SetInt("Level4" + (_currentLevelNumber4 - 1), 2);
    if (_currentLevelNumber4 < _levelButtonController4.levelButtons3.Length && PlayerPrefs.GetInt("Level4" + _currentLevelNumber4) != 2)
      PlayerPrefs.SetInt("Level4" + (_currentLevelNumber4), 1);
  }

  private void SetGameplayStartsPositions4()
  {
    _platformController.SetStartPositions();
  }

  private void OnGameOptionsButtonClicked()
  {
    _levelTimer4.StopTimer4();
    _scoreView.IsNeedScoreReset = false;
    GameManager.Instance.CancelFruitSpawn();
    // for (int i = 0; i < _levelScene3.transform.childCount; i++)
    // {
    //   GameObject level = _levelScene3.transform.GetChild(i).gameObject;
    //   Destroy(level);
    // }
  }

  private void BackToGameOptionsButtonClicked()
  {
    _levelTimer4.StartTimer4();
    _scoreView.IsNeedScoreReset = true;
    GameManager.Instance.CancelFruitSpawn();
    GameManager.Instance.CancelFruitSpawn();
    GameManager.Instance.StartSpawnFruit();
  }

  private void OnBackToMenuButtonClicked()
  {
    _levelTimer4.StopTimer4();
    _levelTimer4.ResetTimerValue4();
    _scoreView.IsNeedScoreReset = true;
    SetGameplayStartsPositions4();
    GameManager.Instance.CancelFruitSpawn();
  }

  private void TutorialButtonClicked()
  {
    PlayerPrefs.SetInt("TutorialCompleted", 1);
    _levelTimer4.StartTimer4();
    _scoreView.IsNeedScoreReset = true;
    GameManager.Instance.StartSpawnFruit();
  }
}