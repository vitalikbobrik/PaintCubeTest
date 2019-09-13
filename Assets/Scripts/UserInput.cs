using UnityEngine;

public class UserInput : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public float perspectiveZoomSpeed = 0.1f;

    private void Start()
    {
        Camera.main.transform.LookAt(transform.position);
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touchZero = Input.GetTouch(0);
            Vector3 localAngle = transform.localEulerAngles;
            localAngle.y -= rotationSpeed * touchZero.deltaPosition.x * Time.deltaTime;
            transform.localEulerAngles = localAngle;
        }

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
            Camera.main.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 0.1f, 179.9f);

        }

    }

}
