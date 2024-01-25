using UnityEngine;

namespace Assets.Prototype_1.Scripts
{
    internal class FollowPlayer : MonoBehaviour
    {

        [SerializeField] private GameObject player;


        private void LateUpdate()
        {
            // Offset the camera behind the player by adding to the player´s position
            transform.position = player.transform.position + new Vector3(0, 5, -7);
        }

    }
}
