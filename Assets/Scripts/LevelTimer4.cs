using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer4 : MonoBehaviour
{
  public event Action LevelWon4;

  // public int MaxTimerValue3 => _maxTimerValue3;

  [SerializeField] private TextMeshProUGUI _timer3;

  // [SerializeField] private Text _winViewTimer3;

  // [SerializeField] private Text _loseViewTimer3;
  [SerializeField] private int _maxTimerValue3;
  
  private int _timerValue;
  public bool IsEndlessMode { get; set; }

  // private int _timer;

  // public void Init()
  // {
  //   void NewFunction3()
  //   {
  //     // if (TimerValue != _maxTimerValue3)
  //     // {
  //     //   TimerValue = _maxTimerValue3;
  //     // }
  //     SetTextTimer(_maxTimerValue3);
  //     StartCoroutine(TimerCoroutine3());
  //   }
  //
  //   NewFunction3();
  // }

  public void StartTimer4()
  {
    if (IsEndlessMode) return;
    StartCoroutine(TimerCoroutine4());
  }

  public void StopTimer4()
  {
    StopAllCoroutines();
  }

  public void ResetTimerValue4()
  {
    _timerValue = 0;
  }

  private IEnumerator TimerCoroutine4()
  {
    int maxCount4 = _maxTimerValue3;
    if (_timerValue != 0) maxCount4 = _timerValue;

    SetTextTimer4(maxCount4);
    while (maxCount4 > 0)
    {
      yield return new WaitForSeconds(1);
      maxCount4 -= 1;
      _timerValue = maxCount4;
      SetTextTimer4(maxCount4);
    }
    _timerValue = 0;
    LevelWon4?.Invoke();
  }

  private void SetTextTimer4(float value)
  {
    // TimerValue = value;
    int minutes4 = Mathf.FloorToInt(value / 60);
    int seconds4 = Mathf.FloorToInt(value % 60);
    _timer3.text = $"{minutes4:00}:{seconds4:00}";
  }
}