using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.SemanticKernel;


namespace AiAgents.FinancialAdvisor.Agent
{
    /// <summary>
    /// Main AI agent for financial advisory tasks, based on requirements and design.
    /// </summary>
    public class FinancialAdvisorAgent
    {
        private readonly IKernel kernel;
        private Dictionary<string, object> userInputs = new();
        
        // Azure OpenAI Configuration
        public class AzureOpenAIConfig
        {
            public string Endpoint { get; set; } = "https://agenticai-rahul.openai.azure.com/";

            //public string ApiKey { get; set; } ="";

            //Uncomment it to rumn locally
            public string ApiKey { get; set; } = "CQmkc9em0xl3xqGza6YlYihsMhIoocjynae99w2Wm5TprvUbAleHJQQJ99BIACMsfrFXJ3w3AAABACOGoYLR";
            public string DeploymentName { get; set; } = "gpt-35-turbo";
        }

        private const string SystemPrompt = @"You are an expert financial advisor AI assistant. You provide professional, accurate, 
and personalized retirement planning advice based on the user's financial information and goals. Keep responses concise and focused 
on actionable recommendations.";

        public static Kernel CreateKernel(AzureOpenAIConfig config)
        {
            var builder = Kernel.CreateBuilder();

            // Example: Add Azure OpenAI connector
            builder.AddAzureOpenAIChatCompletion(
                deploymentName: config.DeploymentName,
                endpoint: config.Endpoint,
                apiKey: config.ApiKey
            );
            return builder.Build();
        }

        public FinancialAdvisorAgent(Kernel kernel)
        {
            this.kernel = kernel;
        }

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
        public async Task<string> AdviseAsync()
        {
            if (userInputs.Count == 0)
                return "No user data collected. Please provide inputs.";

            var context = new ContextVariables();
            context.Set("systemPrompt", SystemPrompt);

            // Format user data into a structured input
            var userData = new
            {
                Age = Convert.ToInt32(userInputs["Age"] ?? 0),
                CurrentSavings = new
                {
                    Taxable = Convert.ToDouble(userInputs["CurrentSavings_Taxable"] ?? 0),
                    IRA = Convert.ToDouble(userInputs["CurrentSavings_IRA"] ?? 0),
                    _401K = Convert.ToDouble(userInputs["CurrentSavings_401K"] ?? 0),
                    RothIRA = Convert.ToDouble(userInputs["CurrentSavings_RothIRA"] ?? 0)
                },
                AnnualIncome = Convert.ToDouble(userInputs["AnnualIncome"] ?? 0),
                MonthlyContribution = Convert.ToDouble(userInputs["MonthlyContribution"] ?? 0),
                ExpectedRetirementAge = Convert.ToInt32(userInputs["ExpectedRetirementAge"] ?? 65),
                DesiredRetirementIncome = Convert.ToDouble(userInputs["DesiredRetirementIncome"] ?? 0),
                RiskTolerance = userInputs["RiskTolerance"]?.ToString(),
                InvestmentPreferences = userInputs["InvestmentPreferences"]?.ToString(),
                CurrentDebt = Convert.ToDouble(userInputs["CurrentDebt"] ?? 0),
                OtherIncomeSources = userInputs["OtherIncomeSources"]?.ToString(),
                InflationRate = Convert.ToDouble(userInputs["InflationRate"]?.ToString()?.TrimEnd('%') ?? "2.5") / 100,
                LifeExpectancy = Convert.ToInt32(userInputs["LifeExpectancy"] ?? 85),
                MarketConditions = userInputs["MarketConditions"]?.ToString(),
                TaxConsiderations = userInputs["TaxConsiderations"]?.ToString(),
                HealthStatus = userInputs["HealthStatus"]?.ToString()
            };

            // Create the prompt for retirement planning analysis
            string prompt = $@"Based on the following financial information, provide a detailed retirement planning analysis with specific recommendations:

{JsonSerializer.Serialize(userData, new JsonSerializerOptions { WriteIndented = true })}

Please include:
1. Retirement readiness assessment
2. Projected retirement savings
3. Specific recommendations for improving retirement readiness
4. Tax optimization strategies
5. Risk management considerations

Focus on actionable advice and specific steps the user can take.";

            context.Set("input", prompt);

            // Use Semantic Kernel to get AI-powered advice
            var result = await kernel.InvokeSemanticFunctionAsync(context);

            return result.GetValue<string>() ?? "Unable to generate advice at this time.";
        }

        public async Task<string> GetQuickAdviceAsync(string question)
        {
            var context = new ContextVariables();
            context.Set("systemPrompt", SystemPrompt);
            context.Set("input", $"Based on the following user data:\n{JsonSerializer.Serialize(userInputs, new JsonSerializerOptions { WriteIndented = true })}\n\nPlease answer this specific question: {question}");

            var result = await kernel.InvokeSemanticFunctionAsync(context);
            return result.GetValue<string>() ?? "Unable to provide advice at this time.";
        }

        public async Task<string> AnalyzeScenarioAsync(string scenario)
        {
            var context = new ContextVariables();
            context.Set("systemPrompt", SystemPrompt);
            context.Set("input", $"Given the user's financial profile:\n{JsonSerializer.Serialize(userInputs, new JsonSerializerOptions { WriteIndented = true })}\n\nAnalyze this scenario: {scenario}\n\nProvide specific recommendations and impact analysis.");

            var result = await kernel.InvokeSemanticFunctionAsync(context);
            return result.GetValue<string>() ?? "Unable to analyze scenario at this time.";
        }

        public async Task<string> GetInvestmentAdviceAsync(double amount, string timeframe, string riskLevel)
        {
            var context = new ContextVariables();
            context.Set("systemPrompt", SystemPrompt);
            context.Set("input", $"Considering the user's financial profile and these specific parameters:\n- Amount: ${amount:N0}\n- Timeframe: {timeframe}\n- Risk Level: {riskLevel}\n\nProvide specific investment recommendations and allocation advice.");

            var result = await kernel.InvokeSemanticFunctionAsync(context);
            return result.GetValue<string>() ?? "Unable to provide investment advice at this time.";
        }
    }
}
