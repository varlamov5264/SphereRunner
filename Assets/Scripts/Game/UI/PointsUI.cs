using UnityEngine;
using UnityEngine.UI;

public class PointsUI : MonoBehaviour
{
    [SerializeField] private Text _label;
    [Zenject.Inject] private PointsCollector _pointsCollector;

    private void OnEnable()
    {
        _pointsCollector.onAddPoints += GetNewPoints;
        GetNewPoints(0);
    }

    private void GetNewPoints(int points)
    {
        _label.text = points.ToString();
    }

    private void OnDisable()
    {
        if (_pointsCollector)
            _pointsCollector.onAddPoints -= GetNewPoints;
    }
}
