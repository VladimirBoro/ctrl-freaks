using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class AOESpellController : MonoBehaviour
{
    private float destroyTime = 5.0f;
    [SerializeField] private GameObject fistProjectilePrefab;
    public Transform[] spellSpawnPoints;
    private Transform playerTransform;

    // private int fistNumber = 8;
   
    private void Start()
    {

        // List<Transform> selectedSpawnPoints = new List<Transform>();
        // List<Transform> availableSpawnPoints = new List<Transform>(spellSpawnPoints);
        
        // for (int i = 0; i < fistNumber; i++)
        // {
        //     int randomIndex = Random.Range(0, availableSpawnPoints.Count);
        //     selectedSpawnPoints.Add(availableSpawnPoints[randomIndex]);
        //     availableSpawnPoints.RemoveAt(randomIndex);
        // }

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;


        foreach (Transform spellSpawnPoint in spellSpawnPoints)
        {
            Vector3 directionToPlayer = -1 * (playerTransform.position - spellSpawnPoint.position).normalized;
            
            Quaternion rotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);

            rotation *= Quaternion.Euler(90f, 0f, 0f);
            
            // Quaternion rotation = spellSpawnPoint.rotation * Quaternion.Euler(90f, 0f, 0f);
            Instantiate(fistProjectilePrefab, spellSpawnPoint.position, rotation);
        }

        Destroy(gameObject, destroyTime);
    }
}