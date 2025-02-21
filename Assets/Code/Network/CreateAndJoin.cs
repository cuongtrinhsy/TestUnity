using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.SceneManagement;

public class CreateAndJoin : MonoBehaviourPunCallbacks
{
    public TMP_InputField inp_create;
    public TMP_InputField inp_join;

    public void CreateRoom() {
        PhotonNetwork.JoinOrCreateRoom(inp_create.text,new RoomOptions(){MaxPlayers = 4},TypedLobby.Default,null);
    }

    public void JoinRoom() {
        PhotonNetwork.JoinRoom(inp_join.text);
    }

    public override void OnJoinedRoom() {
        PhotonNetwork.LoadLevel("Main");
    }
}
