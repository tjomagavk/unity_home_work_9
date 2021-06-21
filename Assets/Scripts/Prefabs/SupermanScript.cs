using System;
using Prefabs;
using UnityEngine;
using Random = UnityEngine.Random;

public class SupermanScript : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    private bool _leftLegPositive;
    private const float BodyRunPosition = .1f;
    private int _target;
    public int speed;
    private int _layer;

    void Start()
    {
        _layer = LayerMask.NameToLayer("BadGuy");
        NextTarget();
    }

    private void NextTarget()
    {
        int newTarget = Random.Range(0, points.Length);
        if (newTarget == _target)
        {
            if (newTarget >= 0 && newTarget < points.Length - 1)
            {
                ++newTarget;
            }
            else
            {
                --newTarget;
            }
        }

        _target = newTarget;
    }

    void FixedUpdate()
    {
        Transform target = points[_target];
        transform.LookAt(target);
        transform.position =
            Vector3.MoveTowards(transform.position, target.position, Time.fixedDeltaTime * speed);
        if (Vector3.Distance(target.transform.position, transform.transform.position) <= 0.1)
        {
            NextTarget();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _layer)
        {
            other.GetComponent<Rigidbody>().AddForce(other.transform.position.normalized * 15, ForceMode.Impulse);
        }

        NextTarget();
    }
}