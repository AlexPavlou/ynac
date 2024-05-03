﻿using System.Text.Json.Serialization;

namespace YnabApi.Budget
{
    public class Budget
    {
        [JsonPropertyName("name")]
        public string Name { get; init; } = string.Empty;

        public Guid Id { get; init; }

        public string BudgetId
        {
            get
            {
                if (Name == LastUsedBudgetName && Id == Guid.Empty)
                    return LastUsedBudgetName;
                return Id.ToString();
            }
        }

        public override string ToString()
        {
            if (Name == LastUsedBudgetName && Id == Guid.Empty)
                return LastUsedBudgetDescription;
            return Name;
        }
        
        public static readonly Budget LastUsedBudget = new() { Name = LastUsedBudgetName, Id = Guid.Empty };
        public static readonly Budget NoBudget = new() { Name = NoBudgetsFoundText, Id = Guid.Empty };
        private static string LastUsedBudgetName => "last-used";
        private static string NoBudgetsFoundText => "ynac:error:no-budgets-found";
        private static string LastUsedBudgetDescription => "Last Used Budget";
    }
}
