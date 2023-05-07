using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;

public class LevelView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private float animDuration = 0.5f;

    private int _displayedLevel;
    private Tween _tween;
   

    public void UpdateLevelAnimated(int newLevel)
    {
        if (_tween != null && _tween.IsActive() && _tween.IsPlaying())
        {
            _tween.Kill();
        }

        DOGetter<int> getter = () => _displayedLevel;
        _tween = DOTween.To(getter, UpdateLevel, newLevel, animDuration);
    }

    public void UpdateLevel(int level)
    {
        _displayedLevel = level;
        label.text = "Lv." + level.ToString();
    }
}
