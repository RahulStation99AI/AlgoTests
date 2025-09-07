namespace AiAgents.FinancialAdvisor.Agent
{
    /// <summary>
    /// Interface for agent services (advice, data, etc.)
    /// </summary>
    public interface IAgentService
    {
        string Advise(string clientId);
        void UpdateMarketData(string symbol, double value);
        void AddClientProfile(string profile);
    }
}
