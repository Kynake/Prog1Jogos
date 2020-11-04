using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float speed = 4f;
    public float turningRate = 90f; // in degrees

    public Transform target = null;

    void Start() {
    }

    void Update() {
        if(target == null) {
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;

        float angle = Vector3.Angle(transform.forward, direction);
        if(angle > 0) {
            transform.forward = Vector3.Slerp(transform.forward, direction, (turningRate * Time.deltaTime) / angle);
            transform.position += transform.forward * speed * Time.deltaTime;
        } else {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }
}
