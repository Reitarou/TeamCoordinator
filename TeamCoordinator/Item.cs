using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stg;

namespace TeamCoordinator
{
    abstract class Item : IStgSerializable
    {
        private AI m_AI;
        protected string m_ID;

        public Item(AI ai)
        {
            m_AI = ai;
            m_ID = Guid.NewGuid().ToString();
        }

        public Item(AI ai, StgNode node)
        {
            m_AI = ai;
            LoadFromStg(node);
        }


        public AI Parent
        {
            get
            {
                return m_AI;
            }
        }

        public string ID
        {
            get
            {
                return m_ID;
            }
        }

        #region IStgSerializable Members

        public abstract void LoadFromStg(StgNode node);

        public abstract void SaveToStg(StgNode node);

        #endregion

        public override string ToString()
        {
            return m_ID;
        }
    }
}
