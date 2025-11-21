namespace AiAgents.FinancialAdvisor.Agent
{
    /// <summary>
    /// Factory for creating agent instances.
    /// </summary>
    public static class AgentFactory
    {
        public static FinancialAdvisorAgent CreateDefaultAgent()
        {
            // Return a parameterless FinancialAdvisorAgent (simulated) to avoid external dependencies during build
            return new FinancialAdvisorAgent();
        }
    }
}
