using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ArrowSpawner : MonoBehaviour
{
    public GameObject hitPointPreFab;
    public GameObject[] arrowPrefab;

    public GameObject hitPoint;
    private GameObject arrow;
    public Text score;
    private int scorecurrent;

    public bool isMoving = false;
    public bool canBePressed;
    public bool isPresent = true;

    public KeyCode keyToPress;

    public Vector3 hitPos;


    private void Update()
    {

        if(!isMoving)
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
                isMoving = true;
                SpawnObjects();
                isPresent = true;
            //}
        }

        if(isMoving)
        {
            MoveArrow();
        }
    }

    void SpawnObjects()
    {
        int randomArrow = Random.Range(0, 3);
        arrow = Instantiate(arrowPrefab[randomArrow], Vector3.zero, Quaternion.identity);

        do
        {
            hitPos = new Vector3(Random.Range(-18f, 18f), Random.Range(-36f, 20f), 0);
        } while (hitPos.x > 1f && hitPos.x < -1f && hitPos.y > 1f && hitPos.y < -1f);
        hitPoint = Instantiate(hitPointPreFab, new Vector3(hitPos.x, hitPos.y, 0), Quaternion.identity);
    }


    void MoveArrow()
    {
        if (isPresent)
        {
            arrow.transform.Translate(hitPoint.transform.position * Time.deltaTime);

            //scorecurrent++;

            //score.text = scorecurrent.ToString();

            if (arrow.transform.position.x > 18f || arrow.transform.position.x < -18 || arrow.transform.position.y > 20f || arrow.transform.position.y < -36f)
            {
                Destroy(hitPoint);
                Destroy(arrow);

                isMoving = false;

                Debug.Log("Game Over");
                SceneManager.LoadScene("GameOver");
            }
        }
    }

}
