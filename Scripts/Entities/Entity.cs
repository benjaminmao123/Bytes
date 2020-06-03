using System;
using Photon.Pun;

namespace Bytes.Entities
{
    public class Entity : MonoBehaviourPun
    {
        public Guid InstanceID { get; set; }

        private void Awake()
        {
            InstanceID = System.Guid.NewGuid();
        }
    }
}

