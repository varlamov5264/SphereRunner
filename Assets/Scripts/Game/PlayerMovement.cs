using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerLife))]
public class PlayerMovement : MonoBehaviour
{
    public Action<Vector2> onUpdatePosition;
    [SerializeField] private Area _area;
    private PlayerLife _playerLife;
    private IInputController _inputController;
    private ISpeedLogic _speedLogic;
    private float _currentSpeed;
    private const float Width = 1;
    private const float DefaultSpeedMultiplier = 2;
    private bool _lerpSpeed;

    private void Start()
    {
        _playerLife = GetComponent<PlayerLife>();
        _inputController = new TouchInput();
        _inputController.Start();
        _speedLogic = new SpeedByPoints();
        _speedLogic.Start();
    }

    private void Update()
    {
        if (_inputController == null ||
            _speedLogic == null ||
            _playerLife.Dead)
            return;
        _inputController.Update();
        if (_currentSpeed != _speedLogic.Speed && !_lerpSpeed)
            StartCoroutine(LerpSpeed());
        transform.position = transform.position
            .SetX(_inputController.GetPositionX())
            .PlusY(_currentSpeed * Time.deltaTime * DefaultSpeedMultiplier);
        if (Mathf.Abs(transform.position.x) + Width / 2 > _area.CurrentBorder)
        {
            _playerLife.Damage();
            _inputController.Reset();
        }
        onUpdatePosition?.Invoke(transform.position);
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
        _speedLogic.OnDisable();
    }
}