using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToHitPoint : MonoBehaviour
{

    public GameObject hitPoint;
    public Vector3 hitPointPosition;
    // Start is called before the first frame update
    void Start()
    {
        hitPointPosition = hitPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(hitPointPosition * Time.deltaTime);
    }
}
