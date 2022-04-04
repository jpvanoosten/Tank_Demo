using System;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public Transform leftTread;
    public Transform rightTread;
    
    public float treadRadius;
    public float tankSpeed;
    public float tankRotationSpeed;

    private float treadDistance;
    private float circumference;
    private Vector3 tankRotation;
    private Vector3 leftTreadRotation;
    private Vector3 rightTreadRotation;

    // Start is called before the first frame update
    void Start()
    {
        circumference = 2.0f * Mathf.PI * treadRadius;
        leftTreadRotation = leftTread.localEulerAngles;
        rightTreadRotation = rightTread.localEulerAngles;
        tankRotation = transform.localEulerAngles;
        treadDistance = Math.Abs(leftTread.localPosition.x - transform.localPosition.x);
    }

    // Update is called once per frame
    void Update()
    {

        float deltaZ = 0.0f;
        float rotY = 0.0f;

        if (Input.GetKey(KeyCode.W))
        {
            deltaZ += tankSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            deltaZ -= tankSpeed * Time.deltaTime;
        }

        Vector3 pos = new Vector3();
        pos.z += deltaZ;
        transform.Translate(pos, Space.Self);

        if (Input.GetKey(KeyCode.D))
        {
            rotY += tankRotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rotY -= tankRotationSpeed * Time.deltaTime;
        }

        tankRotation.y += rotY;
        transform.localEulerAngles = tankRotation;

        leftTreadRotation.x += deltaZ / circumference * 360.0f;
        rightTreadRotation.x += deltaZ / circumference * 360.0f;

        leftTreadRotation.x += (rotY * Mathf.Deg2Rad * treadDistance) / circumference * 360.0f;
        rightTreadRotation.x -= (rotY * Mathf.Deg2Rad * treadDistance) / circumference * 360.0f;

        leftTread.localEulerAngles = leftTreadRotation;
        rightTread.localEulerAngles = rightTreadRotation;
    }
}
