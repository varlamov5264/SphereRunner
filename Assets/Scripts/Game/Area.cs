using System;
using UnityEngine;

public class Area : MonoBehaviour
{
    public float CurrentBorder { get; private set; }
    public float border;
    public Action<float> onUpdateBorder;
    [SerializeField] private float _borderLerpSpeed = 4;

    private void Start()
    {
        CurrentBorder = border;
        onUpdateBorder?.Invoke(CurrentBorder);
    }

    public void UpdatePosition(Vector2 playerPosition)
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
}