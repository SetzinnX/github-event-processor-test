using System;
using System.Collections.Generic;
using System.Text;
using Azure.Sdk.Tools.GitHubEventProcessor.GitHubPayload;
using Octokit;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Sdk.Tools.GitHubEventProcessor.Utils
{
    public class CommentUtils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="textToLookFor"></param>
        /// <returns></returns>
        internal static bool CommentContainsText(string comment, string textToLookFor)
        {
            // Why is this using IndexOf instead of string.Contains?
            // This is the reason https://learn.microsoft.com/en-us/dotnet/api/system.string.contains?view=netframework-4.8
            // The overload for contains with a StringComparison only exists in .NET Core, not the full Framework.
            // Doing it this way makes it resilient regardless of how things get compiled.
            // Also, the strings being looked for will always be in English, matching what's in the
            // CommentConstants class which is why OrdinalIgnoreCase instead of the cultural string
            // comparisons.
            if (comment.IndexOf(textToLookFor, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return true;
            }
            return false;
        }
    }
}
