using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

//give us every callback unity has including monobehaviour
public class PhotonManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("attempt connection");
    }

    //After conntecting to master, join a lobby.
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("connected to master");
    }

    //Create a room
    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 4 }, TypedLobby.Default);
    }

    //Spawn in players
    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Player", new Vector2(Random.Range(-5f, 5f), transform.position.y), Quaternion.identity);
    }
}
