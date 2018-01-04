using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble;
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
