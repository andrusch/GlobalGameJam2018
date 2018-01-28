using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class LevelBuilder : MonoBehaviour {

    public GameObject CellPrefab;
    public int numberOfObjects = 3;
    public int maxX;
    public float CellSize;
    private void Awake()
    {
        GameState.Instance.MaxX = maxX;

        /*
        List<Vector3> placed = new List<Vector3>();
        int possibleX = (int)(maxX / CellSize);
        int possibleY = (int)(maxY / CellSize);
        List<Vector2> points = new List<Vector2>();
        for (int i = 1; i <= possibleX; i++) 
        {
            for (int j = 1; j <= possibleY; j++) 
            {
                points.Add(new Vector2(i, j));
            }
        }
        List<Vector2> shuffledPoints = points.OrderBy(x => Guid.NewGuid()).ToList();
        */

        List<Vector2> points = new List<Vector2>();
        int totalWidth = maxX ;
        int midpoint = 0;

        int ni = midpoint;
        for (int i = midpoint; i <= totalWidth; i++)
        {
            int ny = midpoint;
            for (int j = midpoint; j <= totalWidth; j++)
            {
                if (!(j == midpoint && i == midpoint))
                {
                    points.Add(new Vector2(i, j));
                    points.Add(new Vector2(ni, ny));
                }
                ny--;
            }
            ni--;
        }
        List<Vector2> shuffledPoints = points; 

        for (int i = 0; i < numberOfObjects; i++)
        {
            
            float x, y;
            x = (shuffledPoints[i].x-1) * CellSize + CellSize + (-maxX);
            y = (shuffledPoints[i].y - 1) * CellSize + CellSize + (-maxX);

            Vector3 pos = new Vector3(x, y, 1);
            Instantiate(CellPrefab, pos, Quaternion.identity);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
