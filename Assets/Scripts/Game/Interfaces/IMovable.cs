using System;
using UnityEngine;

public interface IMovable
{
    Action<Vector2> onUpdatePosition { get; set; }
    void StartMove();
}

