using UnityEngine;

public class RelayRace : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private UnitScript[] units;
    [SerializeField] private Transform stick;

    private int _runUnit;

    // Start is called before the first frame update
    void Start()
    {
        foreach (UnitScript unit in units)
        {
            unit.Stop();
        }

        _runUnit = units.Length - 1;
        NextRun();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(units[_runUnit].transform.position, NextUnit(_runUnit).transform.position) <= 0.1)
        {
            NextRun();
        }
    }

    private void NextRun()
    {
        units[_runUnit].Stop();
        NextUnit(_runUnit).SetStick(stick);
        NextUnit(_runUnit).Run();
        _runUnit = NextArrayNumber(_runUnit);
        NewTarget();
    }

    private void NewTarget()
    {
        for (int i = 0; i < units.Length; i++)
        {
            if (i != _runUnit)
            {
                units[i].SetTarget(units[_runUnit].transform);
            }
            else
            {
                units[_runUnit].SetTarget(NextUnit(_runUnit).transform);
            }
        }
    }

    private UnitScript NextUnit(int currentUnit)
    {
        return units[NextArrayNumber(currentUnit)];
    }

    private int NextArrayNumber(int currentUnit)
    {
        if (currentUnit != units.Length - 1)
        {
            return currentUnit + 1;
        }
        else
        {
            return 0;
        }
    }
}