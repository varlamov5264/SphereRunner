using System;

public class PointsCollector : Singleton<PointsCollector>
{
    public Action<int> onAddPoints;
    public int Points { get; private set; }

    public void Add(int points)
    {
        Points += points;
        onAddPoints?.Invoke(Points);
    }
}
