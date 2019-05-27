using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cursovoy_var16.Utils
{
    public class Pair<K, V>
    {
        public K First { get; set; }
        public V Second { get; set; }
        public Pair(K k, V v)
        {
            First = k;
            Second = v;
        }

    }
}
