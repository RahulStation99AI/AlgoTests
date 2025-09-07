using System;
using System.Collections.Generic;

namespace AiAgents.FinancialAdvisor.Agent
{
    /// <summary>
    /// Main AI agent for financial advisory tasks, based on requirements and design.
    /// </summary>
    public class FinancialAdvisorAgent
    {
        // State: collected user data
        private Dictionary<string, object> userInputs = new();

        // List of prompts based on requirements
        private readonly List<(string key, string prompt)> prompts = new()
        {
            ("Age", "What is your age?"),
            ("CurrentSavings_Taxable", "What is your current taxable savings?"),
            ("CurrentSavings_IRA", "What is your current IRA savings?"),
            ("CurrentSavings_401K", "What is your current 401K savings?"),
            ("CurrentSavings_RothIRA", "What is your current Roth IRA savings?"),
            ("AnnualIncome", "What is your annual income?"),
            ("MonthlyContribution", "How much do you contribute monthly to retirement savings?"),
            ("ExpectedRetirementAge", "At what age do you expect to retire?"),
            ("DesiredRetirementIncome", "What is your desired annual retirement income?"),
            ("RiskTolerance", "What is your risk tolerance (low, medium, high)?"),
            ("InvestmentPreferences", "Do you have any investment preferences or restrictions?"),
            ("CurrentDebt", "What is your current total debt?"),
            ("OtherIncomeSources", "List any other income sources (comma separated):"),
            ("InflationRate", "What inflation rate do you want to assume? (e.g., 2.5%)"),
            ("LifeExpectancy", "What is your expected life expectancy? (years)"),
            ("MarketConditions", "Any assumptions about future market conditions?"),
            ("TaxConsiderations", "Any special tax considerations?"),
            ("HealthStatus", "How would you describe your health status? (good/average/poor)"),
        };

        // Collect all required prompts from user (simulate with a dictionary for now)
        public void CollectUserInputs(Dictionary<string, object> simulatedAnswers)
        {
            userInputs.Clear();
            foreach (var (key, prompt) in prompts)
            {
                if (simulatedAnswers.ContainsKey(key))
                    userInputs[key] = simulatedAnswers[key];
                else
                    userInputs[key] = null; // Or prompt user in a real app
            }
        }

        // Main agent logic: process collected inputs and generate a sample answer
        public string Advise()
        {
            // In a real implementation, use all collected inputs and requirements/design logic
            // Here, just demonstrate using the collected data
            if (userInputs.Count == 0)
                return "No user data collected. Please provide inputs.";

            // Example: Calculate a simple readiness score
            int age = Convert.ToInt32(userInputs["Age"] ?? 0);
            double savings = Convert.ToDouble(userInputs["CurrentSavings_Taxable"] ?? 0)
                + Convert.ToDouble(userInputs["CurrentSavings_IRA"] ?? 0)
                + Convert.ToDouble(userInputs["CurrentSavings_401K"] ?? 0)
                + Convert.ToDouble(userInputs["CurrentSavings_RothIRA"] ?? 0);
            double annualIncome = Convert.ToDouble(userInputs["AnnualIncome"] ?? 0);
            double desiredIncome = Convert.ToDouble(userInputs["DesiredRetirementIncome"] ?? 0);
            int retirementAge = Convert.ToInt32(userInputs["ExpectedRetirementAge"] ?? 65);

            // Dummy logic for demonstration
            double readinessScore = (savings + (retirementAge - age) * annualIncome * 0.15) / (desiredIncome * 20.0);
            readinessScore = Math.Max(0, Math.Min(1, readinessScore));

            return $"Retirement Readiness Score: {readinessScore:F2}\n" +
                   $"Projected Retirement Savings: ${(savings + (retirementAge - age) * annualIncome * 0.15):F0}\n" +
                   $"Recommended Action: {(readinessScore > 0.8 ? "On track!" : "Increase savings or adjust goals.")}";
        }
    }
}
