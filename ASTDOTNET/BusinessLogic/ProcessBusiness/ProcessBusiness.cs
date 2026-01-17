namespace ASTDOTNET.BusinessLogic.ProcessBusiness
{
    public class ProcessBusiness : IProcessBusiness
    {
        public List<string> ProcessInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input is required");

            var items = input
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();

            if (items.Count > 99)
                throw new ArgumentException("Input must not exceed 99 values");

            var duplicatedItems = items
                .GroupBy(x => x)
                .Where(g => g.Count() > 1)  /// important line
                .Select(g => g.Key)
                .ToList();

            // ตัวอักษร
            var letters = duplicatedItems
                .Where(x => !int.TryParse(x, out _))
                .OrderBy(x => x)
                .ToList();

            // ตัวเลข
            var numbers = duplicatedItems
                .Where(x => int.TryParse(x, out _))
                .Select(int.Parse)
                .OrderBy(x => x)
                .Select(x => x.ToString())
                .ToList();

            return letters
                .Concat(numbers)
                .ToList();
        }

    }
}
