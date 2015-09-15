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
            FillPreparedStages();

            m_Teams = new List<Team>();
            FillPreparedTeams();
        }

        public List<Stage> Stages
        {
            get
            {
                return m_Stages;
            }
        }

        private void FillPreparedStages()
        {
            m_Stages.Clear();
            Stage stage;
            
            stage = new Stage();
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
        }

        private void FillPreparedTeams()
        {
            m_Teams.Clear();
            Team team;

            team = new Team();
            team.Name = "1-1";
            team.Stages.Add(1, false);
            AddTeam(team);
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

        public void AddTeam(Team newTeam)
        {
            var id = 0;
            bool changed = true;
            while (changed)
            {
                changed = false;
                foreach (var team in m_Teams)
                {
                    if (team.ID == id)
                    {
                        changed = true;
                        id++;
                        break;
                    }
                }
            }
            newTeam.ID = id;
            m_Teams.Add(newTeam);
        }
    }
}
