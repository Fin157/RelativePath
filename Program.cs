namespace RelativePath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetRelativePath(@"\domov\jinyAdresar\mujAdresar", @"\domov\nejakyJinyAdresar"));
        }

        static string GetRelativePath(string startPath, string endPath)
        {
            // Step 1: Get the index where both paths deviate from each other
            int deviationIndex = GetDeviationIndex(startPath, endPath);

            // Step 2: Build the relative path based on the deviation index
            string[] startPathSplit = startPath.Split(@"\", StringSplitOptions.RemoveEmptyEntries);
            string[] endPathSplit = endPath.Split(@"\", StringSplitOptions.RemoveEmptyEntries);

            string relPath = string.Join("", Enumerable.Repeat(@"\..", Math.Clamp(startPathSplit.Length - deviationIndex, 0, int.MaxValue)));

            if (deviationIndex < endPathSplit.Length)
                relPath += @"\" + string.Join(@"\", endPathSplit[deviationIndex..]);

            return relPath;
        }

        static int GetDeviationIndex(string path1, string path2)
        {
            int i = 1;
            string[] path1Split = path1.Split(@"\");
            string[] path2Split = path2.Split(@"\");

            while (i < path1Split.Length && i < path2Split.Length && path1Split[i] == path2Split[i])
            {
                i++;
            }

            return i - 1;
        }
    }
}
