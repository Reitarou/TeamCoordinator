using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamCoordinator
{
    class AI
    {
        private List<Stage> m_Stages;
        private List<Team> m_Teams;

        public AI()
        {
            m_Stages = new List<Stage>();

            var stage = new Stage();
            stage.Name = "01";
            stage.Desription = "Пожар";
            AddStage(stage);

            stage = new Stage();
            stage.Name = "02";
            stage.Desription = "ДТП";
            AddStage(stage);

            stage = new Stage();
            stage.Name = "03";
            stage.Desription = "Перелом";
            AddStage(stage);

            stage = new Stage();
            stage.Name = "03";
            stage.Desription = "Перелом";
            AddStage(stage);

            stage = new Stage();
            stage.Name = "03";
            stage.Desription = "Перелом";
            AddStage(stage);

            stage = new Stage();
            stage.Name = "03";
            stage.Desription = "Перелом";
            AddStage(stage);

            stage = new Stage();
            stage.Name = "03";
            stage.Desription = "Перелом";
            AddStage(stage);

            stage = new Stage();
            stage.Name = "03";
            stage.Desription = "Перелом";
            AddStage(stage);

            stage = new Stage();
            stage.Name = "03";
            stage.Desription = "Перелом";
            AddStage(stage);

            m_Teams = new List<Team>();
        }

        public List<Stage> Stages
        {
            get
            {
                return PreparedStages;
            }
        }

        private List<Stage> PreparedStages
        {
            get
            {
                return m_Stages;
            }
        }

        public void AddStage(Stage newStage)
        {
            var id = 0;
            bool changed = true;
            while (changed)
            {
                changed = false;
                foreach (var stage in m_Stages)
                {
                    if (stage.ID == id)
                    {
                        changed = true;
                        id++;
                        break;
                    }
                }
            }
            newStage.ID = id;
            m_Stages.Add(newStage);
        }
    }
}
