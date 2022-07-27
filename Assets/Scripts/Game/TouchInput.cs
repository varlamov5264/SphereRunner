using UnityEngine;

public class TouchInput : IInputController
{
    private Vector3 _startMousePosition;
    private float _startX;
    private bool _isClicked;
    private float _x;

    private const float _sensitive = 10;

    public void Update()
    {
        _isClicked = Input.GetButton("Fire1");
        if (_isClicked)
        {
            if (_startMousePosition == Vector3.zero)
            {
                _startMousePosition = Input.mousePosition;
                _startX = _x;
            }
            _x = _startX - ((_startMousePosition.x - Input.mousePosition.x) / Screen.height * _sensitive);
        }
        else
        {
            _startX = 0;
            _startMousePosition = Vector3.zero;
        }
    }

    public void Reset()
    {
        _x = 0;
        _startX = 0;
        _startMousePosition = Input.mousePosition;
    }

    public float GetPositionX() => _x;
}