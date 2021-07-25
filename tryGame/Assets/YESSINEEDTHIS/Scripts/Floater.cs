using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody rb;
    public float depthBeforeSubmerged = 1f;
    public float dispacementAmmount = 3f;
    float dispacementMultiplier= 3f;
    public int floaterCount = 1;
    public float waterDrag= 0.99f;
    public float waterAngularDrag = 0.5f;

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.AddForceAtPosition(Physics.gravity/floaterCount, transform.position, ForceMode.Acceleration);
        float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);
        if (transform.position.y < waveHeight)
        {
            dispacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / depthBeforeSubmerged) * dispacementAmmount;
            rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * dispacementMultiplier, 0f),transform.position ,ForceMode.Acceleration);

            rb.AddForce(dispacementMultiplier * -rb.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rb.AddTorque(dispacementMultiplier * -rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }

    }

}
