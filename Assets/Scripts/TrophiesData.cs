using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrophiesData", menuName = "Data/TrophiesData")]
public class TrophiesData : ScriptableObject
{
  public List<Sprite> Sprites;
  public List<string> Description;
}