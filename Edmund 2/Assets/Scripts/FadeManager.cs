using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public Image fadePanel;
    public float fadeTime;
    public enum EnumEtatFade {FadeIn, FadeOut};
    public EnumEtatFade etatFade;

    private void Start()
    {
        fadePanel = GetComponent<Image>();
        //fadePanel.CrossFadeAlpha(0f, fadeTime, false);
        switch (etatFade)
        {
            case EnumEtatFade.FadeIn:
                FadeInMethod();
                break;

            case EnumEtatFade.FadeOut:
                FadeOutMethod();
                break;
        }
    }

    public void FadeOutMethod()
    {
        fadePanel.CrossFadeAlpha(0f, fadeTime, false);
    }
    public void FadeInMethod()
    {
        fadePanel.canvasRenderer.SetAlpha(0.0f);
        fadePanel.CrossFadeAlpha(1f, fadeTime, false);
    }
}
