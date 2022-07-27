using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsUI : MonoBehaviour
{

    [SerializeField] private Text _label;

    private void OnEnable()
    {
        PointsCollector.Instance.onAddPoints += GetNewPoints;
        GetNewPoints(0);
    }

    private void GetNewPoints(int points)
    {
        _label.text = points.ToString();
    }

    private void OnDisable()
    {
        if (PointsCollector.IsAvailible)
            PointsCollector.Instance.onAddPoints -= GetNewPoints;
    }
}
