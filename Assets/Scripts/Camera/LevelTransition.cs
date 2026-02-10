using Unity.Cinemachine;
using UnityEngine;
using System;

public enum CamConverterType{
    Left,
    Right,
    Up,
    Down
}

public class LevelTransition : MonoBehaviour
{
    [SerializeField] private CinemachineCamera StartCamera;
    [SerializeField] private CinemachineCamera EndCamera;

    [SerializeField] private CamConverterType EndCameraPos;

    private Vector3 objectPosition;

    private const int USE_VAL = 10;
    private const int UNUSE_VAL = 1;

    private void Awake() {
        objectPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            objectPosition = transform.position;
            cvtCam(isExit(other.transform.position, objectPosition));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // 플레이어가 영역을 벗어났을 때
        {
            objectPosition = transform.position;
            cvtCam(isExit(other.transform.position, objectPosition));           
        }
    }

    private Boolean isExit(Vector3 playerPosition, Vector3 objectPosition)
    {
        Boolean isIn;

        if(EndCameraPos == CamConverterType.Up) // 위쪽
        {
            isIn = playerPosition.y < objectPosition.y;
        }
        else if (EndCameraPos == CamConverterType.Right) // 오른쪽
        {
            isIn = playerPosition.x > objectPosition.x;
        }
        else if (EndCameraPos == CamConverterType.Down) // 아래쪽
        {
            isIn = playerPosition.y > objectPosition.y;
        }
        else if (EndCameraPos == CamConverterType.Left) // 왼쪽
        {
            isIn = playerPosition.x < objectPosition.x;
        }
        else // 추가된 enum에 따른 설정이 안되어있는 경우
        {
            Debug.LogError("VCCamera Direction이 잘못 설정되었습니다.");
            isIn = false;
        }
        return isIn;
    }

    private void cvtCam(Boolean cvt)
    {
        if (cvt)
        {
            EndCamera.Priority = USE_VAL;
            StartCamera.Priority = UNUSE_VAL;
        }
        else
        {
            EndCamera.Priority = UNUSE_VAL;
            StartCamera.Priority = USE_VAL;
        }
    }
}
