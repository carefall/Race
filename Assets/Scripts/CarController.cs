using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    [SerializeField] WheelCollider wheelFL, wheelFR, wheelRL, wheelRR;
    [SerializeField] Transform meshFL, meshFR, meshRL, meshRR;
    [SerializeField] TextMeshProUGUI speedText;
    [Range(0.1f, float.MaxValue)]
    [SerializeField] float speedCheckInterval;
    [SerializeField] float torque, brakeTorque;
    [SerializeField] float steerAngle;
    [SerializeField] float steerSpeed;
    private float currentAngle;

    [SerializeField] AudioClip drift, idle, ride;
    private Vector3 lastPosition;
    private WheelFrictionCurve slip = new();
    private bool isBraking;
    private Vector2 direction;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(nameof(SpeedMeasure));
        slip.extremumValue = 1;
        slip.asymptoteSlip = 0.5f;
        slip.asymptoteValue = 0.75f;
        slip.stiffness = 3;
    }

    private void Update()
    {
        if (direction.x == 0)
        {
            if (currentAngle > 0)
            {
                currentAngle = Mathf.Clamp(currentAngle - steerSpeed * Time.deltaTime, 0, steerAngle);
            } else if (currentAngle < 0)
            {
                currentAngle = Mathf.Clamp(currentAngle + steerSpeed * Time.deltaTime, -steerAngle, 0);
            }
        }
        currentAngle = Mathf.Clamp(currentAngle + steerSpeed * direction.x * Time.deltaTime, -steerAngle, steerAngle);
        wheelFL.steerAngle = currentAngle;
        wheelFR.steerAngle = currentAngle;
        ProcessAcceleration();
        UpdateWheelTransform(wheelFL, meshFL);
        UpdateWheelTransform(wheelFR, meshFR);
        UpdateWheelTransform(wheelRL, meshRL);
        UpdateWheelTransform(wheelRR, meshRR);
        // UPDATE SOUNDS
        if (isBraking && lastPosition != transform.position && source.clip != drift)
        {
            source.clip = drift;
            source.Play();
        }
        else if (direction.y == 0 && source.clip != idle && !isBraking)
        {
            source.clip = idle;
            source.Play();
        }
        else if (direction.y != 0 && source.clip != ride && !isBraking)
        {
            source.clip = ride;
            source.Play();
        }
    }

    private void ProcessAcceleration()
    {
        // UPDATE THIS SHIT TO NFS LEVEL BROOO
        wheelRL.motorTorque = torque * direction.y;
        wheelRR.motorTorque = torque * direction.y;
        wheelRL.brakeTorque = isBraking ? brakeTorque : 0;
        wheelRR.brakeTorque = isBraking ? brakeTorque : 0;
        slip.extremumSlip = isBraking ? 1f : 0.2f;
        wheelRL.sidewaysFriction = slip;
        wheelRR.sidewaysFriction = slip;
        wheelFR.sidewaysFriction = slip;
        wheelFL.sidewaysFriction = slip;
    }


    public void HorizontalInput(InputAction.CallbackContext ctx)
    {
        direction.x = ctx.ReadValue<float>();
    }

    public void VerticalInput(InputAction.CallbackContext ctx)
    {
        direction.y = ctx.ReadValue<float>();
    }

    public void Brakes(InputAction.CallbackContext ctx)
    {
        isBraking = ctx.performed;
    }

    private void UpdateWheelTransform(WheelCollider col, Transform mesh)
    {
        Quaternion rot;
        col.GetWorldPose(out _, out rot);
        mesh.rotation = rot;
    }

    private IEnumerator SpeedMeasure()
    {
        while (true)
        {
            float distance = Vector3.Distance(lastPosition, transform.position);
            int speed = (int)(distance * 3.6f / speedCheckInterval);
            speedText.text = $"{speed}";
            lastPosition = transform.position;
            yield return new WaitForSeconds(speedCheckInterval);
        }
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(SpeedMeasure));
    }
}
