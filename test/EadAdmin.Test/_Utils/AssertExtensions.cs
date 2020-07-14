using System;
using Xunit;

namespace EadAdmin.Domain._Utils
{
    public static class AssertExtensions
    {
        public static void WithMessage(this ArgumentException exception, string message)
        {
            if (exception.Message == message)
                Assert.True(true);
            else
                Assert.False(true, $"Expected message : '{message}'");
        }
    }
}