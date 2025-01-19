using UnityEngine;

public class EndlessModeView : MonoBehaviour
{
  [SerializeField] private BlockVisibilityToggle4 _endlessModeButtonBlockVisibilityToggle1;
  [SerializeField] private LevelTimer4 _levelTimer4;
  
  private void Awake()
  {
    _endlessModeButtonBlockVisibilityToggle1.OnBlocksToggled4 += EndlessModeButtonClicked;
  }

  private void OnEnable()
  {
    _levelTimer4.IsEndlessMode = false;
  }

  private void EndlessModeButtonClicked()
  {
    _levelTimer4.IsEndlessMode = true;
  }
}