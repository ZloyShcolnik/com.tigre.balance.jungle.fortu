using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrophiesView : MonoBehaviour
{
  [SerializeField] private TrophiesData _trophiesData;
  [SerializeField] private Image _descriptionTrophyImage;
  [SerializeField] private TextMeshProUGUI _descriptionTrophyText;
  [SerializeField] private List<Button> _trophyButtons;

  private int _visibleTrophyLastIndex;
  
  private void Awake()
  {
    foreach (Button trophyButton in _trophyButtons)
    {
      trophyButton.onClick.AddListener(() => TrophyButtonClicked(trophyButton.GetComponent<Image>().sprite));
    }
  }

  public void EnableTrophy()
  {
    _visibleTrophyLastIndex += 1;
    if (_visibleTrophyLastIndex >= _trophyButtons.Count - 1) return;

    _trophyButtons[_visibleTrophyLastIndex].interactable = true;
  }
  
  private void TrophyButtonClicked(Sprite sprite)
  {
    _descriptionTrophyImage.sprite = sprite;
    _descriptionTrophyText.text = _trophiesData.Description[_trophiesData.Sprites.FindIndex(s => s == sprite)];
  }
}