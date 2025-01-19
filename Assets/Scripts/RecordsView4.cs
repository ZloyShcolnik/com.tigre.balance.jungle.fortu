using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RecordsView4 : MonoBehaviour
{
  [SerializeField] private List<TextMeshProUGUI> recordTexts;
  private List<Record> _records4 = new List<Record>();

  private const string RecordKeyPrefix = "Record_";

  private void Start()
  {
    LoadRecords4();
    UpdateUI4();
  }

  public void UpdateRecords4(int newScore)
  {
    string currentDate = System.DateTime.Now.ToString("dd.MM.yyyy");
    _records4.Add(new Record(currentDate, newScore));


    _records4.Sort((a, b) => a.Score.CompareTo(b.Score));


    if (_records4.Count > recordTexts.Count)
    {
      _records4.RemoveAt(0);
    }

    SaveRecords4();
    UpdateUI4();
  }

  private void SaveRecords4()
  {
    for (int i4 = 0; i4 < _records4.Count; i4++)
    {
      PlayerPrefs.SetString($"{RecordKeyPrefix}{i4}_Date", _records4[i4].Date);
      PlayerPrefs.SetInt($"{RecordKeyPrefix}{i4}_Score", _records4[i4].Score);
    }


    for (int i = _records4.Count; i < 4; i++)
    {
      PlayerPrefs.DeleteKey($"{RecordKeyPrefix}{i}_Date");
      PlayerPrefs.DeleteKey($"{RecordKeyPrefix}{i}_Score");
    }

    PlayerPrefs.Save();
  }

  private void LoadRecords4()
  {
    _records4.Clear();

    for (int i = 0; i < recordTexts.Count; i++)
    {
      string dateKey = $"{RecordKeyPrefix}{i}_Date";
      string scoreKey = $"{RecordKeyPrefix}{i}_Score";

      if (PlayerPrefs.HasKey(dateKey) && PlayerPrefs.HasKey(scoreKey))
      {
        string date = PlayerPrefs.GetString(dateKey);
        int score = PlayerPrefs.GetInt(scoreKey);
        _records4.Add(new Record(date, score));
      }
      else
      {
        _records4.Add(new Record("0", 0));
      }
    }

    _records4 = _records4.OrderByDescending(x => x.Score).ToList();
  }

  private void UpdateUI4()
  {
    for (int i = 0; i < recordTexts.Count; i++)
    {
      if (i < _records4.Count)
      {
        recordTexts[i].text = $"{i + 1}. {_records4[i].Date}      –      {_records4[i].Score}";
      }
      else
      {
        recordTexts[i].text = $"{i + 1}. 00.00.000      –      0";
      }
    }
  }
}