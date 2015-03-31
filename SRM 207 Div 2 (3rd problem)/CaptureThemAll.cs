using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class CaptureThemAll
    {
        public int fastKnight(String knight, String rook, String queen)
        {
            Node knightNode = new Node(knight, 0, false, false);
            LinkedList<Node> queue = new LinkedList<Node>();
            queue.AddLast(knightNode);
            while (queue.Count > 0)
            {
                Node top = queue.First.Value;
                queue.RemoveFirst();
                if (top.location.Equals(rook))
                {
                    top.gotRook = true;
                }
                if (top.location.Equals(queen))
                {
                    top.gotQueen = true;
                }
                if (top.gotQueen && top.gotRook)
                {
                    return top.moves;
                }
                foreach (Node node in top.neighbors())
                {
                    queue.AddLast(node);
                }
            }
            return 0;
        }

        public class Node
        {
            public string location { get; set; }
            public int moves { get; set; }
            public bool gotRook { get; set; }
            public bool gotQueen { get; set; }

            public Node(string location, int moves, bool gotRook, bool gotQueen)
            {
                this.location = location;
                this.moves = moves;
                this.gotRook = gotRook;
                this.gotQueen = gotQueen;
            }

            public LinkedList<Node> neighbors()
            {
                LinkedList<Node> result = new LinkedList<Node>();
                int[][] possibleMoves = new int[8][];
                int[] x = new int[] { 2, 2, -2, -2, 1, -1, 1, -1 };
                int[] y = new int[] { -1, 1, -1, 1, -2, -2, 2, 2 };
                for (int i = 0; i < 8; i++)
                {
                    possibleMoves[i] = new int[] { x[i], y[i] };
                }

                for (int i = 0; i < possibleMoves.Length; i++)
                {
                    string newLocation = Convert.ToString((char)(this.location[0] + possibleMoves[i][0]))
                            + Convert.ToString((char)(this.location[1] + possibleMoves[i][1]));
                    if (newLocation[0] <= 'h' && (char)newLocation[0] >= 'a' && newLocation[1] <= '8' && newLocation[1] >= '1')
                    {
                        result.AddLast(new Node(newLocation, this.moves + 1, this.gotRook, this.gotQueen));
                    }
                }
                return result;
            }
        }
    }
}
