namespace AiAgents.FinancialAdvisor.Agent
{
    /// <summary>
    /// Factory for creating agent instances.
    /// </summary>
    public static class AgentFactory
    {
        public static FinancialAdvisorAgent CreateDefaultAgent()
        {
            // TODO: Add configuration, dependency injection, etc.
            return new FinancialAdvisorAgent();
        }
    }
}
