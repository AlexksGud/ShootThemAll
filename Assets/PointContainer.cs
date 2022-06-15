using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointContainer : MonoBehaviour
{
    [SerializeField] private List<Transform> pointsForInit;
                     private Vector3[] pointsList;

    private int currentPointIndex;
    
    void Start()
    {
        pointsList = new Vector3[pointsForInit.Count];
        for (int i = 0; i < pointsForInit.Count; i++)
        {
            pointsList[i] = pointsForInit[i].position;
        }
        currentPointIndex = 0;
    }

    public Vector3 NextPoint()
    {
        if (currentPointIndex == pointsList.Length - 1)
        {
            Debug.Log("Point wasted, was returned start point");
            currentPointIndex = 0;
            return pointsList[0];
        }
        else
        {
            return pointsList[++currentPointIndex];
        }
           
    }
 
}
