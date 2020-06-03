using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Bytes.Controllers
{
    public class NetworkController : MonoBehaviourPunCallbacks
    {

        void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        void Update()
        {

        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 10 };
            PhotonNetwork.CreateRoom("1", roomOptions);
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected to the " + PhotonNetwork.CloudRegion + " server!");
            PhotonNetwork.JoinRandomRoom();
        }
    }
}

