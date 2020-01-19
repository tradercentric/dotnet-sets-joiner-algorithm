using System;
using System.Collections.Generic;

namespace SetJoiner
{
    public class Group
    {
        public string GroupName { get; set; }

        public HashSet<string> AccountNames { get; set; }

        public override string ToString()
        {
            var commaDelimitedString = string.Join<string>(",", AccountNames);
            return $"{nameof(GroupName)}: {GroupName}, {nameof(AccountNames)}: [{commaDelimitedString}]";
        }
    }
}