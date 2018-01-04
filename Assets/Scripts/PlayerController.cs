using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Boundary boundary;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;

    private Rigidbody rigibody;
    private AudioSource audio;

    private void Start()
    {
        rigibody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 v = new Vector3(moveHorizontal, 0f, moveVertical);
        rigibody.velocity = v * speed;

        rigibody.position = new Vector3(
            Mathf.Clamp(rigibody.position.x, boundary.xMin, boundary.xMax),
            0f,
            Mathf.Clamp(rigibody.position.z, boundary.zMin, boundary.zMax)
            );
        rigibody.rotation = Quaternion.Euler(0f, 0f, -rigibody.velocity.x * tilt);
    }

    public float fireRate = 0.5f;
    private float nextFire;
    private void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire){
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audio.Play();
        }
    }

}
