using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offSet;

    public bool RotateAroundPlayer = true;
    public bool lookAtPlayer = false;
    public float RotationSpeed = 5.0f;

    // Initialization
    void start ()
    {
        offSet = transform.position - player.transform.position;
    }

    // Update is called once per frame
    public void Update()
    {
        transform.position = player.transform.position + offSet;

        if (RotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);

            offSet = camTurnAngle * offSet;
            transform.position = player.transform.position + offSet;
            transform.LookAt(player.transform.position);
        }
    }
}
