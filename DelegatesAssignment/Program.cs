namespace CollectionManipulation
{
    class Program
    {
        // Delegate
        delegate int Operation(int x);

        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            List<int> doubled = ApplyOperation(numbers, Double);
            Console.WriteLine("Doubled (delegate): " + string.Join(", ", doubled));

            List<int> tripled = ApplyOperation(numbers, delegate (int x) { return x * 3; });
            Console.WriteLine("Tripled (anonymous): " + string.Join(", ", tripled));

            List<int> quadrupled = ApplyOperation(numbers, x => x * 4);
            Console.WriteLine("Quadrupled (lambda): " + string.Join(", ", quadrupled));

            List<int> squared = numbers.SquareEach();
            Console.WriteLine("Squared (extension): " + string.Join(", ", squared));

            var evens = numbers.Where(x => x % 2 == 0).ToList();
            Console.WriteLine("Even numbers: " + string.Join(", ", evens));

            var plusOne = numbers.Select(x => x + 1).ToList();
            Console.WriteLine("Plus one (Select): " + string.Join(", ", plusOne));

            var customWhere = numbers.Filter(x => x > 3).ToList();
            Console.WriteLine("Custom where: " + string.Join(", ", customWhere));
        }

        static int Double(int x) => x * 2;

        static List<int> ApplyOperation(List<int> list, Operation op)
        {
            List<int> result = new List<int>();
            foreach (var item in list)
            {
                result.Add(op(item));
            }
            return result;
        }
    }

    public static class ListExtensions
    {
        public static List<int> SquareEach(this List<int> list)
        {
            return list.Select(x => x * x).ToList();
        }
    }

    public static class CustomWhere
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Func<T, bool> filter)
        {
            foreach (var item in collection)
            {
                if (filter(item))
                    yield return item;
            }
        }
    }
}


