using System;
using System.Collections;
using UnityEngine;

public class LoadingScreenManager4 : MonoBehaviour
{
  [SerializeField] private GameObject _loadingScreenCanvas3; 
  [SerializeField] private GameObject _gameManager;

  private void Awake()
  {
    _gameManager.SetActive(true);
    _gameManager.SetActive(false);
  }

  void Start()
  {
    void NewFunction3()
    {
      StartCoroutine(HideLoadingScreenAfterDelay4(1.5f));
    }

    NewFunction3();
  }

  private IEnumerator HideLoadingScreenAfterDelay4(float delay)
  {
    void NewFunction3(CanvasGroup canvasGroup, float endAlpha3)
    {
      canvasGroup.alpha = endAlpha3;
      _loadingScreenCanvas3.SetActive(false);
    }

    yield return new WaitForSeconds(delay);  

    CanvasGroup canvasGroup4 = _loadingScreenCanvas3.GetComponent<CanvasGroup>();
    if (canvasGroup4 != null)
    {
      float startAlpha4 = canvasGroup4.alpha;
      float endAlpha4 = 0f;
      float fadeDuration4 = 1f;
      float elapsedFadeTime4 = 0f;

      while (elapsedFadeTime4 < fadeDuration4)
      {
        elapsedFadeTime4 += Time.deltaTime;
        canvasGroup4.alpha = Mathf.Lerp(startAlpha4, endAlpha4, elapsedFadeTime4 / fadeDuration4);
        yield return null;
      }

      NewFunction3(canvasGroup4, endAlpha4);
    }
  }
}