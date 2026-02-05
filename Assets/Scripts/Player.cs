using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private GameObject resetObj;
    private Vector3 resetPosition;
    private float stopTime = 1f;
    private float gravityScale = -9.81f;
    private Transform camTransform3D;
    private Vector2 horizontalMovement;
    private float verticalMovement;
    private CharacterController playerInfo;
    private int curDimension = 3;
    

    void Start()
    {
        clearDir();
        playerInfo = transform.GetComponent<CharacterController>();
        camTransform3D = transform.Find("3dCam");
        resetPosition = resetObj.transform.position;
    }

    void Update()
    {
        if(curDimension == 3)
        {
            applyMovement3D();
        }
        else if(curDimension == 2)
        {
            applyMovement2D();
        }
    }

    public void switchDimension(int dimension)
    {
        StartCoroutine(changeMove(dimension));
    }

    //다형성 예시, 메소드 오버라이딩
    public IEnumerator changeMove(int dimension)
    {
        curDimension = dimension;
        yield return changeMove();
    }

    public IEnumerator changeMove()
    {
        int tempDim = curDimension;
        curDimension = 0;
        yield return null;
        
        transform.rotation = Quaternion.identity;
        transform.position = resetPosition;
        yield return new WaitForSeconds(stopTime);
        curDimension = tempDim;
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

    public void differVerticalPower(float force)
    {
        verticalMovement = force;        
    }

    private void OnJump(InputValue input)
    {
        if(!playerInfo.isGrounded) return;
        verticalMovement = jumpForce;
    }


    private void applyMovement3D()
    {
        //중력 적용
        if (!playerInfo.isGrounded)
        {
            verticalMovement += gravityScale * Time.deltaTime;
        }

        //수평 계산
        Vector3 forward = camTransform3D.forward;
        Vector3 right = camTransform3D.right;
        // forward.y = 0;
        // right.y = 0;

        Vector3 resultMove = (forward * horizontalMovement.y + right * horizontalMovement.x) * moveSpeed;
        resultMove.y = verticalMovement;

        playerInfo.Move(resultMove * Time.deltaTime);
        
    }
    private void applyMovement2D()
    {
        if (!playerInfo.isGrounded)
        {
            verticalMovement += gravityScale * Time.deltaTime;
        }

        Vector3 resultMove = new Vector3(horizontalMovement.x * moveSpeed, verticalMovement, 0);
        playerInfo.Move(resultMove * Time.deltaTime);
    }
}
