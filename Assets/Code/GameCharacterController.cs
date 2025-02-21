using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class GameCharacterController : MonoBehaviour
{
    public PhotonView photonView;

    public Animator chaAnimator;

    public GameObject prefab_playerName;

    public Transform transUserName;

    public float chaMoveSpeed = 2;

    public float characterRotationSpeed = 1;

    private TMP_Text txt_playerId;

    void Start() {
        txt_playerId =  Instantiate(prefab_playerName).transform.GetComponent<TMP_Text>();
        Transform canvas = GameObject.FindWithTag("MainUI_Canvas").transform;
        txt_playerId.transform.SetParent(canvas, false);
    }


    // Update is called once per frame
    void Update()
    {
        txt_playerId.text = "ID:" + photonView.ViewID;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transUserName.position);
        screenPoint.z = 0;
        txt_playerId.transform.position = screenPoint;
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
