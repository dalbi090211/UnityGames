using UnityEngine;
using UnityEngine.InputSystem;

public class CamMove : MonoBehaviour
{
    [SerializeField] private float minY = -50f;
    [SerializeField] private float maxY = 30f;
    [SerializeField] private float mouseSpeed = 5f;
    [SerializeField] InputActionReference lookAction;
    private float mouseX = 0f;
    private float mouseY = 0f;

    private void Start()
    {
    }

    private void Update()
    {
        Vector2 lookDelta = lookAction.action.ReadValue<Vector2>();

        mouseX += lookDelta.x * mouseSpeed;
        mouseY += lookDelta.y * mouseSpeed;
        mouseY = Mathf.Clamp(mouseY, minY, maxY);

        transform.localEulerAngles = new Vector3(-mouseY, mouseX, 0f);
    }
}
