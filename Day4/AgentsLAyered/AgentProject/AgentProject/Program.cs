using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgentEntity;
using Exceptions;
using AgentBusinessLayer;
using System.Threading.Tasks;

namespace AgentProject
{
    class Program
    {
        static AgentBAL bal = new AgentBAL();
        public static void AddAgentMain()
        {
            Agent agent = new Agent();
            Console.WriteLine("Enter AgentId No   ");
            agent.AgentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Agent Name  ");
            agent.Name = Console.ReadLine();
            Console.WriteLine("Enter PayMode  ");
            agent.PayMode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Premium  ");
            agent.Premium = Convert.ToDouble(Console.ReadLine());
            bal.AddAgentBAL(agent);

        }

        public static void SearchAgentMain()
        {
            int AgentId;
            Console.WriteLine("Enter Agent No  ");
            AgentId = Convert.ToInt32(Console.ReadLine());
            Agent agent = bal.SearchAgentBAL(AgentId);
            if (agent!=null)
            {
                Console.WriteLine(agent);
            }
            else
            {
                Console.WriteLine("Record Not Found...");
            }
        }

        public static void DeleteAgentMain()
        {
            int AgentId;
            Console.WriteLine("Enter AgentId No  ");
            AgentId= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(bal.DeleteAgentDAL(AgentId));
        }
        public static void ShowAgentMain()
        {
            List<Agent> agentList = bal.ShowAgentBAL();
            foreach(Agent agent in agentList)
            {
                Console.WriteLine(agent);
            }
        }

        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("O P T I O N S ");
                Console.WriteLine("--------------");
                Console.WriteLine("1. Add Agent");
                Console.WriteLine("2. Show Agent");
                Console.WriteLine("3. Search Agent");
                Console.WriteLine("4. Delete Agent");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter Your Choice   ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        try
                        {
                            AddAgentMain();
                        }
                        catch(AgentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 2:
                        ShowAgentMain();
                        break;
                    case 3:
                        SearchAgentMain();
                        break;
                    case 4:
                        DeleteAgentMain();
                        break;
                    case 6:
                        return;
                }
            } while (choice != 6);
        }
    }
}
