using System.Collections.Generic;

public class SpeedByPoints : ISpeedLogic
{
    public class Preferences
    {
        public Preferences(int points, float speed)
        {
            this.points = points;
            this.speed = speed;
        }

        public int points;
        public float speed;
    }

    public float Speed { get; set; }

    private List<Preferences> _preferences = new List<Preferences>
    {
        new Preferences(100, 4f),
        new Preferences(50, 3f),
        new Preferences(25, 2f),
        new Preferences(10, 1.5f),
        new Preferences(0, 1),
    };

    public void Start()
    {
        PointsCollector.Instance.onAddPoints += GetNewPoints;
        GetNewPoints(0);
    }

    public void GetNewPoints(int points)
    {
        var current = _preferences.Find(x => points >= x.points);
        Speed = current.speed;
    }

    public void OnDisable()
    {
        if (PointsCollector.IsAvailible)
            PointsCollector.Instance.onAddPoints -= GetNewPoints;
    }
}