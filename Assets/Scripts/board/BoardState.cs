using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class BoardState {
		public int[,] BoardMatrix {get; set;}
        public int[] LineSums {get; set;}
        public int[] ColumnSums {get; set;}
        public int[] DiagonalSums {get; set;}
        public int TurnNum {get; set;}
        public bool gameOver;
        public bool playerTurn;
        public Vector2Int previousPlayerPlay;
        public Vector2Int previousOtherPlayerPlay;

		public BoardState() {
			BoardMatrix = new int[3, 3];
			LineSums = new int[3];
            ColumnSums = new int[3];
            DiagonalSums = new int[2];
            previousPlayerPlay = new Vector2Int(-1,-1);
            previousOtherPlayerPlay = new Vector2Int(-1,-1);
            TurnNum = 0;
		}

        public BoardState clone()
        {
            var serialized = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<BoardState>(serialized);
        }
}