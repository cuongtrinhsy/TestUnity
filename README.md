# Installation
1. Download lastest Unity 6 version (6000.0.39f1)
2. Open project , and Go to File -> Build Profiles -> In Platform session -> Select MacOS -> Switch Platform -> And then hit the "Build"
3. In built folder -> Run built application
4. How to play : 
- Move character by ASDW key
- Rotate camera by holding left mouse button and left-drag or right-drag

# About Photon : a lib to wrap functions for creating multiplayer game
1. Go to asset store,and download Pun 2 plugins
2. To init photons plugins , create an script with below code : 

public class ConnectToPhoton : MonoBehaviourPunCallbacks
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby() {
        SceneManager.LoadScene("Lobby");
    }
}
3. After inited, create function to create and join room : 
    public void CreateRoom() {
        PhotonNetwork.JoinOrCreateRoom(inp_create.text,new RoomOptions(){MaxPlayers = 4},TypedLobby.Default,null);
    }

    public void JoinRoom() {
        PhotonNetwork.JoinRoom(inp_join.text);
    }

    public override void OnJoinedRoom() {
        PhotonNetwork.LoadLevel("Main");
    }   
4. To sync position,rotation,animation of character to other user view,add below component into character
- Photon View
- Photon Transform View
- Photon Animator View
>
 
