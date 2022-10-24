using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Zenject.Inject] private ObjectsLibrary _objectsLibrary;
    [Zenject.Inject] private Area _area;
    [Zenject.Inject] private IMovable _movable;
    [SerializeField] private Vector2 _borderAreaRange;
    [SerializeField] private float _obstacleDistance = 5;
    [SerializeField] private float _updateArea = 50;
    [SerializeField] private float _screenHeight = 10;

    private int _obstacleCount = -1;
    private int _updateAreaCount = -1;

    private List<Obstacle> _obstacles = new List<Obstacle>();

    private void OnEnable()
    {
        _movable.onUpdatePosition += PlayerUpdatePosition;
    }

    private void PlayerUpdatePosition(Vector2 position)
    {
        var newObstacleCount = Mathf.FloorToInt((position.y + _screenHeight) / _obstacleDistance);
        var newUpdateAreaCount = Mathf.FloorToInt(position.y / _updateArea);
        while (newObstacleCount > _obstacleCount)
        {
            RemoveOldObstacles(position);
            _obstacleCount++;
            var obstacle = _objectsLibrary.GetRandomObstacle();
            var x = _area.border - obstacle.width / 2;
            obstacle.transform.position = obstacle.transform.position
                .SetX(Random.Range(-x, x))
                .SetY((_obstacleCount + 1) * _obstacleDistance);
            _obstacles.Add(obstacle);
        }
        if (newUpdateAreaCount != _updateAreaCount)
        {
            var newBorder = Random.Range(_borderAreaRange.x, _borderAreaRange.y);
            //Для того, чтобы при сужении коридора стены не надвигались на препятствия,
            //новая ширина ограничена позицией самого дальнего препятствия
            var maxObstacleX = _obstacles.Max(x => x == null ? 0 : Mathf.Abs(x.transform.position.x) + x.width / 2);
            newBorder = Mathf.Clamp(newBorder, maxObstacleX, Mathf.Infinity);
            _area.border = newBorder;
            _updateAreaCount = newUpdateAreaCount;
        }
    }

    private void RemoveOldObstacles(Vector2 position)
    {
        var oldObstacles = _obstacles.FindAll(x => x != null && x.transform.position.y + _screenHeight < position.y);
        oldObstacles.ForEach(x => Destroy(x.gameObject));
        _obstacles = _obstacles.FindAll(x => x != null);
    }

    private void OnDisable()
    {
        _movable.onUpdatePosition -= PlayerUpdatePosition;
    }
}
