using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentEntity
{
    public class Agent
    {
        public int AgentId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }  
        public int PayMode { get; set; }
       
        public double Premium { get; set; }

        public override string ToString()
        {
            return "AgentId  " + AgentId + " Name " + Name  + "Gender "+ Gender + " PayMode" + PayMode + " Primium" + Premium;
        }
    }
}
