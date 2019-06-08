using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Cascade.Common.Collections
{
    public class MultiDictionary<TKey, TValue> : Dictionary<TKey, ICollection<TValue>>
    {
        public new ICollection<TValue> this[TKey key]
        {
            get => base[key];
            set => Add(key, value);
        }

        public MultiDictionary()
        {

        }

        public MultiDictionary(TKey key, TValue val)
        {
            Add(key, val);
        }

        public MultiDictionary(TKey key, ICollection<TValue> vals)
        {
            Add(key, vals);
        }

        public new void Add(TKey key, ICollection<TValue> vals)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (vals == null)
            {
                throw new ArgumentNullException(nameof(vals));
            }

            if (!this.ContainsKey(key))
            {
                base.Add(key, vals);
            }

            foreach (TValue v in vals)
            {
                this[key].Add(v);
            }
        }

        public void Add(TKey key, TValue val)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (!this.ContainsKey(key))
            {
                this.Add(key, new LinkedList<TValue>());
            }

            this[key].Add(val);
        }

        public ICollection<TValue> Get(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (!this.ContainsKey(key))
            {
                return null;
            }

            return base[key];
        }
    }
}
