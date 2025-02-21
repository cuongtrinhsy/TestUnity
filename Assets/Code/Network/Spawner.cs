using UnityEngine;
using Photon.Pun;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        PhotonNetwork.Instantiate("Prefabs/Character", new Vector3(0, 0, Random.Range(-3,3)), Quaternion.identity);
    }
}
