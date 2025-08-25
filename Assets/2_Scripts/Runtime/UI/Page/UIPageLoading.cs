using TMPro;
using UnityEngine;

public class UIPageLoading : UIPage
{
    [SerializeField] private TMP_Text loadingText;

    public void OnProgress(float progress)
    {
        loadingText.text = progress.ToString($"{progress * 100:F1} %");
    }
}