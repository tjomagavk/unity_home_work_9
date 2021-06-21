using Prefabs;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    [SerializeField] private UnitLeg leftLeg;
    [SerializeField] private UnitLeg rightLeg;
    [SerializeField] private UnitHand leftHand;
    [SerializeField] private UnitHand rightHand;
    [SerializeField] private Transform body;
    private bool _leftLegPositive;
    private const float BodyRunPosition = .1f;
    private Transform _target;
    public int speed;
    private bool _run;

    void Update()
    {
        transform.LookAt(_target);
        if (_run)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * speed);
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void Run()
    {
        LegsAnimation(true);
        HandAnimation(true);
        body.localRotation = Quaternion.Euler(new Vector3(10, 0, 0));
        Vector3 localPosition = body.localPosition;
        localPosition.z += BodyRunPosition;
        body.localPosition = localPosition;
        _run = true;
    }

    public void SetStick(Transform stick)
    {
        stick.parent = rightHand.transform;
        stick.localPosition = new Vector3(0, stick.localPosition.y, 0);
    }

    public void Stop()
    {
        LegsAnimation(false);
        HandAnimation(false);
        body.localRotation = Quaternion.Euler(Vector3.zero);
        Vector3 localPosition = body.localPosition;
        localPosition.z = 0;
        body.localPosition = localPosition;
        _run = false;
    }

    private void LegsAnimation(bool animate)
    {
        if (animate)
        {
            leftLeg.StartAnimation(true, speed);
            rightLeg.StartAnimation(false, speed);
        }
        else
        {
            leftLeg.Stop();
            rightLeg.Stop();
        }
    }

    private void HandAnimation(bool animate)
    {
        if (animate)
        {
            rightHand.StartAnimation(true, speed);
            leftHand.StartAnimation(false, speed);
        }
        else
        {
            rightHand.Stop();
            leftHand.Stop();
        }
    }
}