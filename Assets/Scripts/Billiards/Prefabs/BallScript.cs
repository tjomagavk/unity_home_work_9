using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Vector3 _resetPosition = new Vector3(0, 5f, 0);

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayersManager.GetPockets())
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = _resetPosition;
        }
    }
}