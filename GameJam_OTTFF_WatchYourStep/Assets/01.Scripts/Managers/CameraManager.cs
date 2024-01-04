using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField]
    private CinemachineVirtualCamera titleCamera;
    [SerializeField]
    private CinemachineVirtualCamera followingCamera;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void TitleCamera()
    {
        titleCamera.Priority = 2;
        followingCamera.Priority = 1;
    }

    public void FollowingCamera()
    {
        titleCamera.Priority = 1;
        followingCamera.Priority = 2;
    }
}
