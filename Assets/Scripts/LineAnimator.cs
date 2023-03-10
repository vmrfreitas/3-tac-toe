using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAnimator : MonoBehaviour
{
    [SerializeField] private float animationDuration = 5f ;

   private LineRenderer lineRenderer ;
   private Vector3[] linePoints ;
   private int pointsCount ;

   private void Start () {
      lineRenderer = GetComponent<LineRenderer> () ;

      // Store a copy of lineRenderer's points in linePoints array
      pointsCount = lineRenderer.positionCount ;
      linePoints = new Vector3[pointsCount] ;
      for (int i = 0; i < pointsCount; i++) {
         linePoints [ i ] = lineRenderer.GetPosition (i) ;
      }

      StartCoroutine (AnimateLine ()) ;
   }

   private IEnumerator AnimateLine () {
      float segmentDuration = animationDuration / pointsCount ;

      for (int i = 0; i < pointsCount - 1; i++) {
         float startTime = Time.time ;

         Vector3 startPosition = linePoints [ i ] ;
         Vector3 endPosition = linePoints [ i + 1 ] ;

         Vector3 pos = startPosition ;
         while (pos != endPosition) {
            float t = (Time.time - startTime) / segmentDuration ;
            pos = Vector3.Lerp (startPosition, endPosition, t) ;

            // animate all other points except point at index i
            for (int j = i + 1; j < pointsCount; j++)
               lineRenderer.SetPosition (j, pos) ;

            yield return null ;
         }
      }
   }
}

// code extracted from Hamza Herbou's YouTube channel, from the Animate LineRenderer〰️ in Unity
// https://www.youtube.com/watch?v=RMM3BAick4I&t=186s

// Support them :
// ☞Paypal :https://paypal.me/hamzaherbou
// ☞Patreon : https://www.patreon.com/herbou