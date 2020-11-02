using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Froggy
{
    public class Lake:IEnumerable<int>
    {
        private List<int> StonesList;
        public Lake(int[] stones)
        {
            this.StonesList = new List<int>(stones);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < StonesList.Count; i+=2)
            {
                yield return StonesList[i];
            }

            if(StonesList.Count%2==0)
            {
                for (int i = StonesList.Count - 1; i >= 1; i-=2)
                {
                    yield return StonesList[i];
                }
            }
            else
            {
                for (int i = StonesList.Count- 2; i >= 0; i-=2)
                {
                    yield return StonesList[i];
                }
            }                                
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
