using System;
using System.Collections.Generic;
using Stg;

namespace TeamCoordinator
{
    public class Stage : Item
    {
        #region Comparer

        public class StageComparer : IComparer<Stage>
        {
            public int Compare(Stage x, Stage y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }

        public static readonly IComparer<Stage> Comparer = new StageComparer();

        #endregion

        public string Name = "Этап";
        public string ShortName = "";
        public List<Guid> AvailableGroups = new List<Guid>();

        public Stage(AI ai)
            : base(ai)
        {
        }

        #region IStgSerializable Members

        protected override void OnLoad(StgNode node)
        {
            Name = node.GetString("Name", "");
            ShortName = node.GetString("ShortName", "");
            var array = node.GetArray("AvailableGroups", StgType.String);
            for (int i = 0; i < array.Count; i++)
            {
                var s = array[i] as string;
                if (s != string.Empty)
                {
                    AvailableGroups.Add(Tools.CreateFromString(s));
                }
            }
        }

        protected override void OnSave(StgNode node)
        {
            node.AddString("Name", Name);
            node.AddString("ShortName", ShortName);
            var array = node.AddArray("AvailableGroups", StgType.String);
            foreach (var item in AvailableGroups)
            {
                array.AddString(item.ToString());
            }
        }

        #endregion
    }
}
