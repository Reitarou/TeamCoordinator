using System;
using Stg;

namespace TeamCoordinator
{
    public abstract class Item : IStgSerializable
    {
        private AI m_AI;
        private string m_ID;

        public Item(AI ai)
        {
            m_AI = ai;
            m_ID = Guid.NewGuid().ToString();
        }

        public AI AI
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

        protected abstract void OnLoad(StgNode node);

        public void LoadFromStg(StgNode node)
        {
            m_ID = node.GetString("ID");
            OnLoad(node);
        }

        protected abstract void OnSave(StgNode node);

        public void SaveToStg(StgNode node)
        {
            node.AddString("ID", m_ID);
            OnSave(node);
        }

        #endregion
    }
}
