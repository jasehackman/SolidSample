using ArdalisRating.Raters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    class RaterFactory
    {
        public Rater Create(Policy policy, RatingEngine engine)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.Raters.{policy.Type}PolicyRater"),
                        new object[] { engine, engine.Logger });
            }
            catch
            {
                return new UnknownPolicyRater(engine, engine.Logger);
            }
        }
    }
}
