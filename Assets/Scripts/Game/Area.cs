using System;
using UnityEngine;

public class Area : MonoBehaviour
{
    public float CurrentBorder { get; private set; }
    [SerializeField] private PlayerMovement _player;
    public float border;
    public Action<float> onUpdateBorder;
    [SerializeField] private float _borderLerpSpeed = 4;

    private void Start()
    {
        _player.onUpdatePosition += PlayerUpdatePosition;
        CurrentBorder = border;
        onUpdateBorder?.Invoke(CurrentBorder);
    }

    private void PlayerUpdatePosition(Vector2 playerPosition)
    {
        transform.position = transform.position.SetY(playerPosition.y + 2);
    }

    private void Update()
    {
        if (border != CurrentBorder)
        {
            CurrentBorder = Mathf.MoveTowards(CurrentBorder, border, Time.deltaTime * _borderLerpSpeed);
            onUpdateBorder?.Invoke(CurrentBorder);
        }
    }

    private void OnDisable()
    {
        _player.onUpdatePosition -= PlayerUpdatePosition;
    }
}
