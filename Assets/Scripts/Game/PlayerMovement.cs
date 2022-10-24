using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(IDamageable))]
public class PlayerMovement : MonoBehaviour, IMovable
{
    public Action<Vector2> onUpdatePosition { get; set; }
    private IDamageable _damageable;
    private IInputController _inputController;
    private ISpeedLogic _speedLogic;
    private Area _area;
    private float _currentSpeed;
    private const float Width = 1;
    private const float DefaultSpeedMultiplier = 2;
    private bool _lerpSpeed;
    private bool _isStart;

    [Zenject.Inject]
    public void Construct(IInputController inputController, ISpeedLogic speedLogic, Area area)
    {
        _inputController = inputController;
        _speedLogic = speedLogic;
        _area = area;
    }

    private void Start()
    {
        _damageable = GetComponent<IDamageable>();
    }

    private void Update()
    {
        if (!_isStart ||
            _inputController == null ||
            _speedLogic == null ||
            _damageable.Dead)
            return;
        _inputController.Update();
        if (_currentSpeed != _speedLogic.Speed && !_lerpSpeed)
            StartCoroutine(LerpSpeed());
        transform.position = transform.position
            .SetX(_inputController.GetPositionX())
            .PlusY(_currentSpeed * Time.deltaTime * DefaultSpeedMultiplier);
        if (Mathf.Abs(transform.position.x) + Width / 2 > _area.CurrentBorder)
        {
            _damageable.Damage();
            _inputController.Reset();
        }
        onUpdatePosition?.Invoke(transform.position);
        _area.UpdatePosition(transform.position);
    }

    private IEnumerator LerpSpeed()
    {
        _lerpSpeed = true;
        var timer = 0f;
        var startSpeed = _currentSpeed;
        while (timer != 1)
        {
            timer = Mathf.MoveTowards(timer, 1, Time.deltaTime / 2);
            _currentSpeed = Mathf.Lerp(startSpeed, _speedLogic.Speed, timer);
            yield return null;
        }
        _lerpSpeed = false;
    }

    private void OnDisable()
    {
        _speedLogic?.OnDisable();
    }

    public void StartMove()
    {
        _inputController.Start();
        _speedLogic.Start();
        _isStart = true;
    }
}