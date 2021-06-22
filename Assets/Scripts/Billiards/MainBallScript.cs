using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainBallScript : MonoBehaviour
{
    [SerializeField] private Transform[] _balls;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        Transform ball = _balls[Random.Range(0, _balls.Length)];

        Vector3 vector3 = ball.position - transform.position;

        gameObject.GetComponent<Rigidbody>()
            .AddForce(vector3.normalized * 5, ForceMode.Impulse);
    }
}