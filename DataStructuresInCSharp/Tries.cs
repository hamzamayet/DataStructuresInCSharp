using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresInCSharp
{
    public class Trie
    {
        private readonly TrieNode _root = new TrieNode();

        public Trie()
        {
        }

        //  default constructor
        public Trie(string[] words)
        {
            foreach (string word in words)
            {
                Add(word);
            }

        }

        public void Add(string str)
        {
            TrieNode curr = _root;
            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                curr.PutChildIfAbsent(ch);
                curr = curr.GetChild(ch);
                curr.Size++;
            }

        }

        /// <summary>
        /// return no. of occurance of that string
        /// </summary>
        /// <param name="prefix">search partial string</param>
        /// <returns></returns>
        public int Find(string prefix)
        {
            TrieNode curr = _root;
            for (int i = 0; i < prefix.Length; i++)
            {
                char ch = prefix[i];
                curr = curr.GetChild(ch);
                if (curr == null)
                {
                    return 0;
                }

            }

            return curr.Size;
        }
        public class TrieNode
        {
            private readonly Dictionary<char, TrieNode> _children = new Dictionary<char, TrieNode>();

            public int Size;

            public void PutChildIfAbsent(char ch)
            {
                if (!_children.ContainsKey(ch))
                    _children.Add(ch, new TrieNode());
            }

            public TrieNode GetChild(char ch)
            {
                if (_children.ContainsKey(ch))
                    return _children[ch];
                return null;
            }
        }
    }
}
