using UnityEngine;

public class PointToPoint : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private UnitScript unit;

    private int _runUnit;
    private bool _reverse;

    // Start is called before the first frame update
    void Start()
    {
        unit.Stop();
        _runUnit = -1;
        NextRun();
        unit.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (unit.transform.position == NextPoint(_runUnit).transform.position)
        {
            NextRun();
        }
    }

    private void NextRun()
    {
        _runUnit = NextArrayNumber(_runUnit);
        NewTarget();
    }

    private void NewTarget()
    {
        unit.SetTarget(NextPoint(_runUnit).transform);
    }

    private Transform NextPoint(int current)
    {
        return points[NextArrayNumber(current)];
    }

    private int NextArrayNumber(int currentUnit)
    {
        if (currentUnit == points.Length - 1)
        {
            _reverse = true;
        }
        else if (currentUnit == 0)
        {
            _reverse = false;
        }

        if (_reverse)
        {
            return currentUnit - 1;
        }
        else
        {
            return currentUnit + 1;
        }
    }
}