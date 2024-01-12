using UnityEngine;
using System.Collections.Generic;
using Zenject;
using System.Linq;

namespace PuzzleBuilder
{
    public class SpriteSorter
    {
        [Inject]
        public SpriteSorter()
        {
            
        }

        public List<Sprite> SortSprites(Sprite[] sprites)
        {
            Dictionary<string, Sprite> keyValuePairs = new Dictionary<string, Sprite>();

            for (int i = 0; i < sprites.Length; i++)
            {
                string number = "";
                foreach (char c in sprites[i].name)
                {
                    if (char.IsNumber(c))
                        number += c;
                }

                keyValuePairs.Add(number, sprites[i]);
            }

            keyValuePairs = keyValuePairs.OrderBy(obj => int.Parse(obj.Key)).ToDictionary(obj => obj.Key, obj => obj.Value);
            List<Sprite> result = keyValuePairs.Values.ToList();

            return result;
        }

    }
}

