using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgentEntity;
using System.IO;

using System.Threading.Tasks;

namespace AgentDataLayer
{
    public class AgentDAL
    {
        static List<Agent> agentList;
        static AgentDAL()
        {
            agentList = new List<Agent>();
        }

        public string DeleteAgentDAL(int AgentId)
        {
            Agent agentFound = SeachAgentDAL(AgentId);
            if (agentFound!=null)
            {
                agentList.Remove(agentFound);
                return "Agent Record Deleted...";
            }
            return "Agent Record Not Found...";
        }
        public Agent SeachAgentDAL(int AgentId)
        {
            foreach(Agent agent in agentList)
            {
                if (agent.AgentId == AgentId)
                {
                    return agent;
                }
            }
            return null;
        }
        public Agent WriteFileDAL()
        {
            FileStream fs=new FileStream(@"C:\Documents\MYfile.txt",FileMode.Create,FileAccess.Write);
            var text = agentList;
            StreamWriter sw=new StreamWriter(fs);
            sw.Write(text);
            fs.Close();
            return null;
        }
        public Agent ReadFileDAL()
        {
            FileStream fs = new FileStream(@"C:\Documents\MYfile.txt", FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            Console.Write(sw.ReadToEnd());
            fs.Close();
            return null;
        }

        public Agent UpdateAgentDAL(int AgentId)
        {
            foreach (Agent agent in agentList)
            {
                if (agent.AgentId == AgentId)
                {
                    Console.WriteLine("enter updated values");
                    Console.WriteLine("Enter Agent Name  ");
                    agent.Name = Console.ReadLine();
                    Console.WriteLine("Enter Gender  ");
                    agent.Gender = Console.ReadLine();
                    Console.WriteLine("Enter PayMode  ");
                    agent.PayMode = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Premium  ");
                    agent.Premium = Convert.ToDouble(Console.ReadLine());
                    
                }
            }

            return null;
        }
        public string AddAgentDAL(Agent agent)
        {
            agentList.Add(agent);
            return "Agent Record Added...";
        }

        public List<Agent> ShowAgentDAL()
        {
            return agentList;
        }
    }
}
