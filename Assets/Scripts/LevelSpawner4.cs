using UnityEngine;
using UnityEngine.UI;

public class LevelSpawner4 : MonoBehaviour
{
    // [SerializeField] private GameObject _levelPrefab;
    // [SerializeField] private GameObject _sceneContainer;
    [SerializeField] private Transform _parentTransform; 
    [SerializeField] private BlockVisibilityToggle4 _blockVisibilityToggle;
    [SerializeField] private int lvlnum; 

    private Text _buttonText4; 
    private LevelButtonController4 _levelButtonController4;
    // private GameObject _level3_3;

    private void Awake()
    {
        void NewFunction3()
        {
            _levelButtonController4 = GetComponentInParent<LevelButtonController4>();
            _buttonText4 = GetComponent<Button>().GetComponentInChildren<Text>();
            _blockVisibilityToggle.OnBlocksToggled4 += SpawnLevel4;
            // _levelButtonController3.LevelTimer3.LevelWon += OnLevelCompleted3;
            // _levelButtonController3.BottomBoundary.LevelLost3 += OnLevelLost3;
            // GameManager.Instance.LevelLost3 += OnLevelLost3;
            if (_buttonText4 != null)
            {
                _buttonText4.text = lvlnum.ToString();
            }
        }

        NewFunction3();
    }

    private void SpawnLevel4()
    {
        void NewFunction3()
        {
            // _level3_3 = Instantiate(_levelPrefab, _parentTransform);
            _levelButtonController4._levelManager4.SetLevelNumber(lvlnum);
            _levelButtonController4._nextLevelButton4.UpdateCurrentLevelIndex4(lvlnum);
            _levelButtonController4._retryLevelButton4.UpdateCurrentLevelIndex4(lvlnum);
            _levelButtonController4._loseRetryLevelButton4.UpdateCurrentLevelIndex4(lvlnum);
        }

        NewFunction3();
    }

    // private void OnLevelLost3()
    // {
    //     void NewFunction3()
    //     {
    //         // Destroy(_level3_3);
    //     }
    //
    //     NewFunction3();
    // }

    // private void OnLevelCompleted3()
    // {
    //     // Destroy(_level3_3);
    //
    //
    // }
}
