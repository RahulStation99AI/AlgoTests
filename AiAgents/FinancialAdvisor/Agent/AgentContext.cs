using System.Collections.Generic;

namespace AiAgents.FinancialAdvisor.Agent
{
    /// <summary>
    /// Context class for agent state, environment, and session data.
    /// </summary>
    public class AgentContext
    {
        public string SessionId { get; set; }
        public Dictionary<string, object> State { get; set; }
        public Dictionary<string, object> Environment { get; set; }

        public AgentContext()
        {
            State = new Dictionary<string, object>();
            Environment = new Dictionary<string, object>();
        }
    }
}
