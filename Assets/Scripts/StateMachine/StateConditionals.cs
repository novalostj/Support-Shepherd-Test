using System;
using UnityEngine;

namespace StateMachine
{
    public static class StateConditionals
    {
        public static bool ConditionalBoolCheck(ConditionalBool value, Func<bool> action)
        {
            return value switch
            {
                ConditionalBool.IGNORE => true,
                ConditionalBool.TRUE => action.Invoke(),
                ConditionalBool.FALSE => !action.Invoke(),
            };
        }

        public static bool ConditionalComparisonCheck(ConditionalComparison value, Func<float, float, bool> action)
        {
            return value switch
            {
                ConditionalComparison.IGNORE => true
            };
        }
    }

    public enum ConditionalBool
    {
        IGNORE,
        TRUE,
        FALSE
    }

    public enum ConditionalComparison
    {
        IGNORE,
        GREATER,
        LESS,
        EQUAL
    }
}