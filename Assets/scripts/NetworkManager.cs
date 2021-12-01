using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : Photon.PunBehaviour
{

    public GameObject Lobbycam;
    public Transform spawnpoint;
    public GameObject LobbyUI;
    public Text statusText;

    public const string Version = "1.0";
    public const string RoomName = "Multiplayer";
    public const string playerprefabName = "Player-1";


    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(Version);
    }

    // Update is called once per frame
    void Update()
    {
        statusText.text = PhotonNetwork.connectionStateDetailed.ToString();
    }

    public override void OnConnectionFail(DisconnectCause cause){
        print("connection Failed:" + cause.ToString());
    }
    public override void OnJoinedLobby(){
        RoomOptions roomOptions = new RoomOptions() {isVisible = false,MaxPlayers = 4};
        PhotonNetwork.JoinOrCreateRoom(RoomName,roomOptions,TypedLobby.Default);
    }
    public override void OnJoinedRoom(){
        Lobbycam.SetActive(false);
        LobbyUI.SetActive(false);

        GameObject player = PhotonNetwork.Instantiate(playerprefabName,spawnpoint.position,spawnpoint.rotation,0);
    }
    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer){
        print("new Player Connected");
    }
    public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer){
        print("Player DisConnected");
    }

}
