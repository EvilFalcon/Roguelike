namespace Sources
{
    using UnityEngine;

    public class ObjectSpawner : MonoBehaviour
    {
        public GameObject objectToSpawn;
        public int numberOfObjects;
        public float radius;

        void Start()
        {
            SpawnObjects();
        }

        void SpawnObjects()
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                Vector3 randomPosition = Random.insideUnitSphere * radius;
                Vector3 spawnPosition = transform.position + randomPosition;

                Collider[] colliders = Physics.OverlapSphere(spawnPosition, 1f); // Adjust the radius as needed

                if (colliders.Length == 0)
                {
                    Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                }
            }
        }
    }
}