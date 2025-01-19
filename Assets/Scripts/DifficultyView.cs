using System;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyView : MonoBehaviour
{
  [SerializeField] private List<float> _levelsDifficulty;
  [SerializeField] private List<BlockVisibilityToggle4> _difficultyButtonBlockVisibilityToggle3;

  private void Start()
  {
    // for (var i = 0; i < _difficultyButtonBlockVisibilityToggle3.Count; i++)
    // {
    //   var i1 = i;
    //   _difficultyButtonBlockVisibilityToggle3[i].OnBlocksToggled3 += () => OnDifficultyButtonClicked(i1);
    // }
    
    for (var i4 = 0; i4 < _difficultyButtonBlockVisibilityToggle3.Count; i4++)
    {
      _difficultyButtonBlockVisibilityToggle3[i4].OnBlocksToggled4 += CreateHandler(i4);
    }


  }

  // private void OnDifficultyButtonClicked(int index)
  // {
  //   GameManager.Instance.FruitMass = _levelsDifficulty[index];
  // }

  private Action CreateHandler(int index)
  {
    return () => GameManager.Instance.FruitMass = _levelsDifficulty[index];
  }

}