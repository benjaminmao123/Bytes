using Photon.Pun;
using UnityEngine;

namespace Bytes.Utility
{
    public class SyncObject : MonoBehaviourPun
    {
        //List of the scripts that should only be active for the local player (ex. PlayerController, MouseLook etc.)
        public MonoBehaviour[] localScripts;
        //List of the GameObjects that should only be active for the local player (ex. Camera, AudioListener etc.)
        public GameObject[] localObjects;
        public GameObject[] disableIfMineObjects;
        public MonoBehaviour[] disableIfMineScripts;

        void Start()
        {
            if (!photonView.IsMine)
            {
                foreach (var script in localScripts)
                    script.enabled = false;
                foreach (var go in localObjects)
                    go.SetActive(false);

                Debug.Log("Not Mine");
            }
            else
            {
                foreach (var go in disableIfMineObjects)
                    go.SetActive(false);
                foreach (var script in disableIfMineScripts)
                    script.enabled = false;

                //Player is local
                gameObject.tag = "Player";

                Debug.Log("Mine");
            }
        }
    }
}

