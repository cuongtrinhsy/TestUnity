using UnityEngine;

public class GameCameraController : MonoBehaviour
{

    public Vector3 cam_offset;

    public float smoothTime = 0.3F;
    private Vector3 velocityPosition = Vector3.zero;

    private Vector3 velocityRotation = Vector3.zero;

    private Transform objFollow;

    // Update is called once per frame
    void Update()
    {
        if(objFollow == null) {
            objFollow = GameObject.FindWithTag("cam_character").transform;
        }
        Vector3 targetPosition = new Vector3(objFollow.position.x,objFollow.position.y,objFollow.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocityPosition, smoothTime);

        transform.forward = Vector3.SmoothDamp(transform.forward, objFollow.forward, ref velocityRotation, smoothTime);
    }
}
