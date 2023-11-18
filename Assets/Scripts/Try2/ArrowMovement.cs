using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject hitPointPrefab;

    private GameObject arrow;
    private GameObject hitPoint;

    private bool isMoving = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            isMoving = true;
            SpawnObjects();
        }

        if (isMoving)
        {
            MoveArrow();
        }
    }

    void SpawnObjects()
    {
        // Instantiate the arrow at the origin
        arrow = Instantiate(arrowPrefab, Vector3.zero, Quaternion.identity);

        // Instantiate the hitPoint at a random location
        float randomX = Random.Range(-5f, 5f); // Adjust the range as needed
        float randomY = Random.Range(0.5f, 2.5f); // Adjust the height range as needed
        float randomZ = Random.Range(-5f, 5f); // Adjust the range as needed
        hitPoint = Instantiate(hitPointPrefab, new Vector3(randomX, randomY, randomZ), Quaternion.identity);
    }

    void MoveArrow()
    {
        // Move the arrow towards the hitPoint
        arrow.transform.LookAt(hitPoint.transform.position);
        arrow.transform.Translate(Vector3.forward * Time.deltaTime);

        // Check for overlap and destroy objects
        float distance = Vector3.Distance(arrow.transform.position, hitPoint.transform.position);
        if (distance < 0.1f) // Adjust the overlap threshold as needed
        {
            Destroy(arrow);
            Destroy(hitPoint);
            isMoving = false;
        }
    }
}