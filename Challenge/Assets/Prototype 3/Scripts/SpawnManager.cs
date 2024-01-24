
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Prototype_3.Scripts
{
    internal class SpawnManager : MonoBehaviour
    {
        [SerializeField] GameObject obstaclePrefab;
        [SerializeField] private Vector3 spawnPos = new(25, 0, 0);
        [SerializeField] private float startDelay = 2;
        [SerializeField] private float repeatRate = 2;
        private PlayerController playerControllerScript;

        private void Start()
        {
            InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
            playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        private void SpawnObstacle()
        {
            if (playerControllerScript.gameOver == false)
            {
                Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            }
        }
    }
}
