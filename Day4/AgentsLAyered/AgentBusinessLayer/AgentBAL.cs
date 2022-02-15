using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exceptions;
using AgentEntity;
using AgentDataLayer;
using System.Threading.Tasks;

namespace AgentBusinessLayer
{
    public class AgentBAL
    {
        static StringBuilder sb = new StringBuilder();

        static AgentDAL dal = new AgentDAL();
        public bool ValidateAgent(Agent agent)
        {
            bool isValid = true;
            if (agent.AgentId <= 0)
            {
                sb.Append("Agent No cannot be negative or zero...\r\n");
                isValid = false;
            }
            if (agent.Name.Length < 5)
            {
                sb.Append("Employ Name contains min. 5 characters...\r\n");
                isValid = false;
            }
            if (agent.Gender != "Female" || agent.Gender != "Male")
            {
                sb.Append("Agent gender invalid...\r\n");
                isValid |= false;
            }
            if (agent.PayMode<1 || agent.PayMode>3)
            {
                sb.Append("not valid PayMode...\r\n");
                isValid = false;
            }
            if (agent.Premium <15000)
            {
                sb.Append("Premium cannot less than 15000..\r\n");
                isValid = false;
            }
            
            return isValid;
        }

        public Agent SearchAgentBAL(int AgentId)
        {
            return dal.SeachAgentDAL(AgentId);
        }
        public Agent UpdateAgentBAL(int AgentId)
        {
            return dal.UpdateAgentDAL(AgentId);
        }
        public Agent WriteFileDAL()
        {
            return dal.WriteFileDAL();
        }
        public Agent ReadFileDAL()
        {
            return dal.ReadFileDAL();
        }
        public string DeleteAgentDAL(int AgentId)
        {
            return dal.DeleteAgentDAL(AgentId);
        }
        public string AddAgentBAL(Agent agent)
        {
            if (ValidateAgent(agent)==false)
            {
                throw new AgentException(sb.ToString());
            }
            else
            {
                return dal.AddAgentDAL(agent);
            }
        }

        public List<Agent> ShowAgentBAL()
        {
            return dal.ShowAgentDAL();
        }
    }
}
