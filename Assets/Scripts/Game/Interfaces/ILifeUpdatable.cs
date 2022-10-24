using System;

public interface ILifeUpdatable
{
    Action<int> onLifeUpdate { get; set; }
    public Action onDead { get; set; }
}