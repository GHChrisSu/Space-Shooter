using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    private Rigidbody rigidbody;
    public float speed;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
        rigidbody.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
