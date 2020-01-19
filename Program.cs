using System;
using System.Collections.Generic;
using System.Linq;

namespace SetJoiner
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var a = new Group {GroupName = "A", AccountNames = new HashSet<string>() {"1", "2", "3"}};
            var b = new Group {GroupName = "B", AccountNames = new HashSet<string>() {"2", "3", "4"}};
            var c = new Group {GroupName = "C", AccountNames = new HashSet<string>() {"5", "6"}};
            var groups = new List<Group>() {a, b, c};
            
            
            Console.WriteLine("Operation: Find related groups, reduce groups and merge their members");
            Console.WriteLine("");
            Console.WriteLine("Before:");
            groups.ForEach(Console.WriteLine);

            Console.WriteLine("");
            var d = MergeGroup(groups);
            
            Console.WriteLine("After:");
            d.ForEach(Console.WriteLine);

        }


        private static List<Group> MergeGroup(List<Group> groups)
        {
            var isIntersected = false;
            var newGroups = new List<Group>(groups);

            foreach (var s1 in groups)
            {
                foreach (var s2 in groups)
                {
                    if (s1.GroupName == s2.GroupName)
                    {
                        continue;
                    }

                    var intersects = new HashSet<string>(s1.AccountNames);
                    intersects.IntersectWith(s2.AccountNames);
                    if (intersects.Count <= 0) continue;
                    
                    newGroups.Remove(s1);
                    newGroups.Remove(s2);
                    var mergedName = s1.GroupName + "&" + s2.GroupName;
                    var union = new HashSet<string>(s1.AccountNames);
                    union.UnionWith(s2.AccountNames);

                    var newGroup = new Group {GroupName = mergedName, AccountNames = union};
                    newGroups.Add(newGroup);
                    isIntersected = true;
                    break;
                }

                if (isIntersected) break;
            }

            if (isIntersected)
            {
                newGroups = MergeGroup(newGroups);
            }

            return newGroups;
        }
    }
}