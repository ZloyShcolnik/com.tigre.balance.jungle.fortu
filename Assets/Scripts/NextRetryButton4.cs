using System;
using UnityEngine;

public class NextRetryButton4 : MonoBehaviour
{
  public LevelButtonController4 LevelButtonController4 { get; set; }

  [SerializeField] private GameObject _levelsPanel3;
  [SerializeField] private GameObject _currentScene3;
  [SerializeField] private GameObject _levelManagerBlock3;
  [SerializeField] private BlockVisibilityToggle4 _blockVisibilityToggle3;
  [SerializeField] private ButtonType4 _buttonType4; 
    
  private int _currentLevelIndex4 = -1; 

  private void Awake()
  {
    void NewFunction3()
    {
      _blockVisibilityToggle3.OnBlocksToggled4 += HandleNextOrRetry4;
    }

    NewFunction3();
  }

  public void UpdateCurrentLevelIndex4(int levelIndex)
  {
    _currentLevelIndex4 = levelIndex;
  }

  private void HandleNextOrRetry4()
  {
    void NewFunction3()
    {
      for (int i4 = 0; i4 < _currentScene3.transform.childCount; i4++)
      {
        GameObject level4 = _currentScene3.transform.GetChild(i4).gameObject;
        Destroy(level4);
      }

      if (_buttonType4 == ButtonType4.Next4)
      {
        if (_currentLevelIndex4 == LevelButtonController4.levelButtons3.Length)
        {
          _levelsPanel3.SetActive(true);
          _levelManagerBlock3.SetActive(false);
          return;
        }

        LevelButtonController4.LevelButtonInvoke4(_currentLevelIndex4);
      }
      else if (_buttonType4 == ButtonType4.Retry4)
      {
        if (_currentLevelIndex4 > 0)
        {
          LevelButtonController4.LevelButtonInvoke4(_currentLevelIndex4 - 1);
        }
      }
    }

    NewFunction3();
  }
}