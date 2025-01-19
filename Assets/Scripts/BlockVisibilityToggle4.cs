using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BlockVisibilityToggle4 : MonoBehaviour
{
    public event Action OnBlocksToggled4;

    [FormerlySerializedAs("_currentBlocks")][SerializeField] private List<GameObject> blocksToHide;
    [FormerlySerializedAs("_targetBlocks")][SerializeField] private List<GameObject> blocksToShow;
    [SerializeField] private Button toggleButton;

    private void Awake()
    {
        AddListeners4();
    }

    private void AddListeners4()
    {
        toggleButton.onClick.AddListener(ToggleBlocksVisibility4);
    }

    private void ToggleBlocksVisibility4()
    {
        void NewFunction3()
        {
            HideBlocks4();
            ShowBlocks3();

            OnBlocksToggled4?.Invoke();

            void ShowBlocks3()
            {
                foreach (GameObject block3 in blocksToShow)
                {
                    block3.SetActive(true);
                }
            }
        }

        NewFunction3();
    }

    private void HideBlocks4()
    {
        void NewFunction3()
        {
            foreach (GameObject block3 in blocksToHide)
            {
                block3.SetActive(false);
            }
        }

        NewFunction3();
    }
}
