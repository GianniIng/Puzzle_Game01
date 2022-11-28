using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField]
    private Transform emptySpace01 = null;

    
    private Camera mCam;
    void Start()
    {
        mCam = Camera.main;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                /* Debug.Log(hit.transform.name);*/
                if (Vector2.Distance(emptySpace01.position, hit.transform.position) < 6)
                {
                    Vector2 lastEmptySpacePosition = emptySpace01.position;
                    TileScript thisTile = hit.transform.GetComponent<TileScript>();
                    emptySpace01.position = hit.transform.position;
                    hit.transform.position = lastEmptySpacePosition;
                    thisTile.targetPosition = lastEmptySpacePosition;
                }
                
            }
        }
    }
}
