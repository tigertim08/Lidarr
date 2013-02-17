using System.Diagnostics;
using NzbDrone.Common.EnsureThat.Resources;

namespace NzbDrone.Common.EnsureThat
{
    public static class EnsureIntExtensions
    {
        [DebuggerStepThrough]
        public static Param<int> IsLessThan(this Param<int> param, int limit)
        {
            if (param.Value >= limit)
                throw ExceptionFactory.CreateForParamValidation(param.Name, ExceptionMessages.EnsureExtensions_IsNotLt.Inject(param.Value, limit));

            return param;
        }

        [DebuggerStepThrough]
        public static Param<int> IsLessThanOrEqualTo(this Param<int> param, int limit)
        {
            if (!(param.Value <= limit))
                throw ExceptionFactory.CreateForParamValidation(param.Name, ExceptionMessages.EnsureExtensions_IsNotLte.Inject(param.Value, limit));

            return param;
        }

        [DebuggerStepThrough]
        public static Param<int> IsGreaterThan(this Param<int> param, int limit)
        {
            if (param.Value <= limit)
                throw ExceptionFactory.CreateForParamValidation(param.Name, ExceptionMessages.EnsureExtensions_IsNotGt.Inject(param.Value, limit));

            return param;
        }

        [DebuggerStepThrough]
        public static Param<int> IsGreaterOrEqualTo(this Param<int> param, int limit)
        {
            if (!(param.Value >= limit))
                throw ExceptionFactory.CreateForParamValidation(param.Name, ExceptionMessages.EnsureExtensions_IsNotGte.Inject(param.Value, limit));

            return param;
        }

        [DebuggerStepThrough]
        public static Param<int> IsInRange(this Param<int> param, int min, int max)
        {
            if (param.Value < min)
                throw ExceptionFactory.CreateForParamValidation(param.Name, ExceptionMessages.EnsureExtensions_IsNotInRange_ToLow.Inject(param.Value, min));

            if (param.Value > max)
                throw ExceptionFactory.CreateForParamValidation(param.Name, ExceptionMessages.EnsureExtensions_IsNotInRange_ToHigh.Inject(param.Value, max));

            return param;
        }
    }
}