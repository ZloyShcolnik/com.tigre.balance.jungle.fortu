using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonController4 : MonoBehaviour
{
    public Button[] levelButtons3;  
    // public Sprite lockedSprite3;    
    // public Sprite activeSprite3;    
    // public Sprite passedSprite3;    
    public NextRetryButton4 _nextLevelButton4;
    public NextRetryButton4 _retryLevelButton4;
    public NextRetryButton4 _loseRetryLevelButton4;
    public LevelManager4 _levelManager4;

    private void Awake()
    {
        void NewFunction3()
        {
            _nextLevelButton4.LevelButtonController4 = this;
            _retryLevelButton4.LevelButtonController4 = this;
            _loseRetryLevelButton4.LevelButtonController4 = this;
        }

        NewFunction3();
    }

    private void OnEnable()
    {
        InitializeButtons4();
    }

    public void InitializeButtons4()
    {
        void NewFunction3()
        {
            for (int i3 = 0; i3 < levelButtons3.Length; i3++)
            {
                Button button4 = levelButtons3[i3];
                int levelStatus4;

                if (i3 == 0)
                {
                    levelStatus4 = PlayerPrefs.GetInt("Level4" + i3, 1);
                }
                else
                {
                    levelStatus4 = PlayerPrefs.GetInt("Level4" + i3, 0);
                }

                switch (levelStatus4)
                {
                    case 0:
                        SetButtonState4(button4, false);
                        break;
                    case 1:
                        SetButtonState4(button4, true);
                        break;
                    case 2:
                        SetButtonState4(button4, true);
                        break;
                }
            }
        }

        NewFunction3();
    }

    public void LevelButtonInvoke4(int levelButtonNumber)
    {
        levelButtons3[levelButtonNumber].onClick.Invoke();
    }

    private void SetButtonState4(Button button, bool interactable)
    {
        // button.image.sprite = sprite;
        button.interactable = interactable;  
    }
}
