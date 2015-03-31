using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class SmartWordToy
    {
        public bool[, , ,] forbiddenOrVisited = new bool[26, 26, 26, 26];
        public int minPresses(String start, String finish, String[] forbid)
        {
            for (int i = 0; i < forbid.Length; i++)
            {
                for (int i0 = 0; i0 < forbid[i].Split(' ')[0].Length; i0++)
                {
                    for (int i1 = 0; i1 < forbid[i].Split(' ')[1].Length; i1++)
                    {
                        for (int i2 = 0; i2 < forbid[i].Split(' ')[2].Length; i2++)
                        {
                            for (int i3 = 0; i3 < forbid[i].Split(' ')[3].Length; i3++)
                            {
                                forbiddenOrVisited[
                                    (forbid[i].Split(' ')[0][i0] - 'a'),
                                    (forbid[i].Split(' ')[1][i1] - 'a'),
                                    (forbid[i].Split(' ')[2][i2] - 'a'),
                                    (forbid[i].Split(' ')[3][i3] - 'a')
                                    ] = true;
                            }
                        }
                    }
                }
            }

            if (forbiddenOrVisited[finish[0] - 'a', finish[1] - 'a', finish[2] - 'a', finish[3] - 'a'])
            {
                return -1;
            }

            if (start.Equals(finish))
            {
                return 0;
            }

            return bfs(start, finish);
        }

        public int bfs(string start, string finish)
        {
            LinkedList<Node> q = new LinkedList<Node>();
            q.AddLast(new Node(0, start.ToCharArray()));
            while (q.Count > 0)
            {
                Node top = q.First.Value;
                q.RemoveFirst();
                forbiddenOrVisited[top.word[0] - 'a', top.word[1] - 'a', top.word[2] - 'a', top.word[3] - 'a'] = true;
                if ((new string(top.word)).Equals(finish)) return top.index;
                foreach (Node neighbor in top.neighbors())
                {
                    if (!forbiddenOrVisited[neighbor.word[0] - 'a', neighbor.word[1] - 'a', neighbor.word[2] - 'a', neighbor.word[3] - 'a'])
                    {
                        q.AddLast(neighbor);
                    }
                }
            }
            return -1;
        }

        public class Node
        {
            public int index { get; set; }
            public char[] word { get; set; }
            public Node(int index, char[] word)
            {
                this.index = index;
                this.word = word;
            }

            public LinkedList<Node> neighbors()
            {
                LinkedList<Node> result = new LinkedList<Node>();
                //Look for previous words
                for (int i = 0; i < this.word.Length; i++)
                {
                    result.AddLast(new Node(this.index + 1, previousWord(this.word, i)));
                }
                //Look for next words
                for (int i = 0; i < this.word.Length; i++)
                {
                    result.AddLast(new Node(this.index + 1, nextWord(this.word, i)));
                }
                return result;
            }

            char[] previousWord(char[] word, int index)
            {
                char[] result = new char[word.Length];
                word.CopyTo(result, 0);
                result[index] = previous(word[index]);
                return result;
            }

            char[] nextWord(char[] word, int index)
            {
                char[] result = new char[word.Length];
                word.CopyTo(result, 0);
                result[index] = next(word[index]);
                return result;
            }

            char previous(char c)
            {
                if (c.Equals('a'))
                {
                    return 'z';
                }
                else
                {
                    return Convert.ToChar(c - 1);
                }
            }

            char next(char c)
            {
                if (c.Equals('z'))
                {
                    return 'a';
                }
                else
                {
                    return Convert.ToChar(c + 1);
                }
            }
        }
    }
}
