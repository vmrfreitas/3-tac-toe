using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CircleDrawer : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        DrawCircle(1, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void DrawCircle(float radius, float lineWidth)
    {
        var segments = 20;
        line = GetComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
        line.positionCount = segments + 1;

        var pointCount = segments + 1; // add extra point to make startpoint and endpoint the same to close the circle
        var points = new Vector3[pointCount];

        for (int i = 0; i < pointCount; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360 / segments);
            points[i] = new Vector3(Mathf.Sin(rad) * radius, Mathf.Cos(rad) * radius, 0);
        }
        
        line.SetPositions(points);
        //StartCoroutine (AnimateLine (points)) ;
        //line.SetPositions(points);
    }

    private IEnumerator AnimateLine (Vector3[] linePoints) {
      float segmentDuration = 1 / 361 ;

      for (int i = 0; i < 361 - 1; i++) {
         float startTime = Time.time ;

         Vector3 startPosition = linePoints [ i ] ;
         Vector3 endPosition = linePoints [ i + 1 ] ;

         Vector3 pos = startPosition ;
         while (pos != endPosition) {
            float t = (Time.time - startTime) / segmentDuration ;
            pos = Vector3.Lerp (startPosition, endPosition, t) ;

            // animate all other points except point at index i
            for (int j = i + 1; j < 361; j++)
               line.SetPosition (j, pos) ;

            yield return null ;
         }
      }
   }
}
