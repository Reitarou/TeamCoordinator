using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stg;

namespace TeamCoordinator
{
    public class Group : Item
    {
        #region Comparer

        public class GroupComparer : IComparer<Group>
        {
            public int Compare(Group x, Group y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }

        public static readonly IComparer<Group> Comparer = new GroupComparer();

        #endregion

        public string Name = "";
        public string ShortName = "";

        public Group(AI ai)
            :base(ai)
        {
        }

        #region IStgSerializable Members

        protected override void OnLoad(StgNode node)
        {
            Name = node.GetString("Name", "");
            ShortName = node.GetString("ShortName", "");
        }

        protected override void OnSave(StgNode node)
        {
            node.AddString("Name", Name);
            node.AddString("ShortName", ShortName);
        }

        #endregion
    }
}
