using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public Image fadePanel;
    public float fadeTime;

    private void Start()
    {
        fadePanel = GetComponent<Image>();
        fadePanel.CrossFadeAlpha(0f, fadeTime, false);
    }

    public void FadeOut()
    {
        fadePanel.CrossFadeAlpha(1f, fadeTime, false);
    }
}
