using UnityEngine;
using Photon.Pun;
using System.IO;

namespace Bytes.Controllers
{
    public class RoomController : MonoBehaviourPunCallbacks
    {
        //Player spawn point
        [SerializeField] Transform spawnPoint;
        bool isQuit = false;

        // Use this for initialization
        void Start()
        {
            //In case we started this demo with the wrong scene being active, simply load the menu scene
            if (PhotonNetwork.CurrentRoom == null)
            {
                Debug.Log("Is not in the room, returning back to Lobby");
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
                return;
            }

            Debug.Log(PlayerPrefs.GetString("characterRoot"));

            var path = Path.Combine("Bytes", "Models", "Characters", PlayerPrefs.GetString("characterRoot"), PlayerPrefs.GetString("character"));
            //We're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
            PhotonNetwork.Instantiate(path, spawnPoint.position, Quaternion.identity, 0);
        }

        public void OnQuitToMainMenu()
        {
            PhotonNetwork.LeaveRoom();
        }

        public void OnQuit()
        {
            isQuit = true;
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            if (!isQuit)
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
            else
            {
                PhotonNetwork.LeaveLobby();
                Application.Quit();
            }
        }
    }
}

