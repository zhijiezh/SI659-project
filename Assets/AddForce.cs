using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    Vector3 prev_position;
    Rigidbody rb;
    public float force_magnitude = 1;
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Four))
        {
            Debug.Log("pressed");
            Debug.Log(get_current_direction() * force_magnitude);
            //rb.AddForce(get_current_direction() * force_magnitude);
            rb.AddForce(Camera.main.transform.forward * force_magnitude);
        }
    }

    Vector3 get_current_direction()
    {
        return (transform.position - prev_position).normalized;
    }
}
