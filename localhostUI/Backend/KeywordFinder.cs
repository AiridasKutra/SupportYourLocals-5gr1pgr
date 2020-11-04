using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace localhostUI.Backend
{
    struct KeywordWeight
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public KeywordWeight(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }
    }

    class KeywordFinder
    {
        private List<KeywordWeight> weights;

        public KeywordFinder(List<KeywordWeight> weights = null)
        {
            if (weights == null)
            {
                this.weights = new List<KeywordWeight>();
                this.weights.Add(new KeywordWeight("address", 200));
                this.weights.Add(new KeywordWeight("sports", 100));
                this.weights.Add(new KeywordWeight("name", 100));
                this.weights.Add(new KeywordWeight("teams", 50));
                this.weights.Add(new KeywordWeight("tags", 50));
                this.weights.Add(new KeywordWeight("description", 10));
            }
            else
            {
                this.weights = weights;
            }
        }

        public int Find(string[] keywords, DataList data)
        {
            int score = 0;
            foreach (var keyword in keywords)
            {
                foreach (var weight in weights)
                {
                    object categoryObj = data.Get(weight.Name);
                    score += FindRecursively(keyword.ToLower(), categoryObj) * weight.Weight;
                }
            }
            return score;
        }

        private int FindRecursively(string keyword, object data)
        {
            int count = 0;
            if (data is string)
            {
                string[] words = ((string)data).Split(" ,.!?\"~*/\\()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (keyword == word.ToLower())
                    {
                        count++;
                    }
                }
            }
            else if (data is DataList)
            {
                foreach (var item in (DataList)data)
                {
                    count += FindRecursively(keyword, item.item);
                }
            }
            return count;
        }
    }
}
