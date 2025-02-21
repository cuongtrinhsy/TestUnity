using UnityEngine;
using Photon.Pun;

public class GameCharacterController : MonoBehaviour
{
    public PhotonView photonView;

    public Animator chaAnimator;

    public float chaMoveSpeed = 2;

    public float characterRotationSpeed = 1;


    // Update is called once per frame
    void Update()
    {
        if(!photonView.IsMine) return;
        float offsetMovement = 0;
        float offsetRotation = 0;

        if (Input.GetKey(KeyCode.D))
        {
            offsetRotation += characterRotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            offsetRotation += -characterRotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            chaAnimator.SetTrigger("forw");
            offsetMovement += chaMoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            chaAnimator.SetTrigger("back");
            offsetMovement += -chaMoveSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            chaAnimator.SetTrigger("jump");
        }

        if (offsetMovement == 0 && !IsAnimatingState("jump"))
        {
            chaAnimator.SetTrigger("idle");
        }

        transform.Rotate(new Vector3(0, 1, 0) * offsetRotation, Space.Self);
        transform.position += transform.forward * offsetMovement;
    }

    public bool IsAnimatingState(string stateName) {
        return chaAnimator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
 }
