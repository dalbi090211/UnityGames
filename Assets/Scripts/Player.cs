using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    private float gravityScale = -9.81f;
    private Transform camTransform;
    private Vector2 horizontalMovement;
    private float verticalMovement;
    private CharacterController playerInfo;
    

    void Start()
    {
        clearDir();
        playerInfo = transform.GetComponent<CharacterController>();
        camTransform = transform.Find("MainCamera");
    }

    void Update()
    {
        applyMovement();
    }

    private void clearDir()
    {
        horizontalMovement = new Vector2(0, 0);
        verticalMovement = 0;
    }

    private void OnMove(InputValue input)
    {
        horizontalMovement = input.Get<Vector2>();
    }

    private void OnJump(InputValue input)
    {
        if(!playerInfo.isGrounded) return;
        verticalMovement = jumpForce;
    }

    private void applyMovement()
    {
        //중력 적용
        if (!playerInfo.isGrounded)
        {
            verticalMovement += gravityScale * Time.deltaTime;
        }

        //수평 계산
        Vector3 forward = camTransform.forward;
        Vector3 right = camTransform.right;
        // forward.y = 0;
        // right.y = 0;

        Vector3 resultMove = (forward * horizontalMovement.y + right * horizontalMovement.x) * moveSpeed;
        resultMove.y = verticalMovement;

        playerInfo.Move(resultMove * Time.deltaTime);
        
    }
}
