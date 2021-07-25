using System.Collections;
using UnityEngine;

public class BezierFollowScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform[] routes;
    private int routeToGo;
    private float tParam;
    private Vector2 sheepPosition;
    private float speedModifier;
    private bool coroutineAllowed;

    void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.5f;
        coroutineAllowed = true;

    }

    void Update()
    {
        if (coroutineAllowed)
            StartCoroutine(GoByTheRoute(routeToGo));
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;

        Vector2 p0 = routes[routeNumber].GetChild(0).position;
        Vector2 p1 = routes[routeNumber].GetChild(1).position;
        Vector2 p2 = routes[routeNumber].GetChild(2).position;
        Vector2 p3 = routes[routeNumber].GetChild(3).position;

        while (tParam < 1)
        {

            tParam += Time.deltaTime * speedModifier;

            sheepPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;
            transform.LookAt(sheepPosition);
            transform.position = sheepPosition;
            yield return new WaitForEndOfFrame();

        }
           
           tParam = 0f;

           routeToGo++;

           if (routeToGo > routes.Length - 1)
             routeToGo = 0;

           coroutineAllowed = true;
     }
}


