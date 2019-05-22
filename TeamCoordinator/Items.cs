using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Stg;

namespace TeamCoordinator
{
    public class Items<T> where T : Item
    {
        private Dictionary<Guid, T> m_Items = new Dictionary<Guid, T>();
        IComparer<T> m_Comparer;

        public Items(IComparer<T> comparer)
        {
            m_Comparer = comparer;
        }

        public IEnumerable<T> All
        {
            get
            {
                foreach (var value in m_Items.Values)
                {
                    yield return value;
                }
            }
        }

        public IEnumerable<T> AllSorted
        {
            get
            {
                var list = new List<T>();
                foreach (var value in m_Items.Values)
                {
                    list.Add(value);
                }
                list.Sort(m_Comparer);
                return list;
            }
        }

        public void AddItem(Item item)
        {
            var t = item as T;
            if (t != null)
            {
                m_Items.Add(t.ID, t);
                item.AI.RebuildGrid = true;
            }
        }

        public T this[Guid id]
        {
            get
            {
                if (m_Items.ContainsKey(id))
                    return m_Items[id];
                return null;
            }
        }

        public T GetByName(string name)
        {
            if (typeof(T) == typeof(Group))
            {
                foreach (var item in m_Items.Values)
                {
                    var group = item as Group;
                    if (group == null)
                    {
                        Debug.Fail("How?");
                        continue;
                    }
                    if (group.Name == name)
                        return group as T;
                }
            }

            if (typeof(T) == typeof(Stage))
            {
                foreach (var item in m_Items.Values)
                {
                    var stage = item as Stage;
                    if (stage == null)
                    {
                        Debug.Fail("How?");
                        continue;
                    }
                    if (stage.Name == name)
                        return stage as T;
                }
            }

            if (typeof(T) == typeof(Scene) ||
                typeof(T) == typeof(Team))
            {
                Debug.Fail("Not Implemented");
            }

            return null;
        }

        public void RemoveItem(Item item)
        {
            var t = item as T;
            if (t != null && m_Items.ContainsKey(t.ID))
            {
                t.AI.RebuildGrid = true;
                m_Items.Remove(t.ID);
            }
        }

        #region IStgSerializable

        public void LoadFromStg(AI ai, IStgArray array, Func<AI, StgNode, T> create)
        {
            m_Items.Clear();
            for (int i = 0; i < array.Count; i++)
            {
                var node = array[i] as StgNode;
                var item = create(ai, node);
                m_Items.Add(item.ID, item);
            }
        }

        public void SaveToStg(IStgArray array)
        {
            foreach (var item in m_Items.Values)
            {
                var node = array.AddNode();
                item.SaveToStg(node);
            }
        }

        #endregion
    }
}
