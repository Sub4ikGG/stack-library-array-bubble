namespace StackUtils
{
    public class SUtils
    {
        private static ulong _n_OP = 0;

        public static void Print(Stack<int> stack) // + 1
        {
            int n = stack.Count; // + 2
            int[] array = new int[n]; // + 2
            stack.CopyTo(array, 0); // + 2

            // + 2
            for (int i = 0; i < n; i++) // + 2
            {
                Console.Write($"{array[i]} "); // + 2
            }

            _n_OP += 11;
        }

        public static int Get(Stack<int> stc, int id) // + 2
        {
            _n_OP += 2;
            if (id > stc.Count - 1)
            { // + 3
                _n_OP += 6;
                throw new Exception($"Выход за границы стэка. Посл. инд. стека: {stc.Count - 1}. Запрашиваемый индекс: {id}"); // + 3
            }

            int n = stc.Count; // + 2
            int[] array = new int[n]; // + 2
            stc.CopyTo(array, 0); // + 2

            _n_OP += 9;
            return array[id]; // + 3
        }

        public static void Set(ref Stack<int> stc, int id, int newValue) // + 3
        {
            _n_OP += 3;
            if (id > stc.Count - 1)
            { // + 3
                _n_OP += 6;
                throw new Exception($"Выход за границы стэка. Посл. инд. стека: {stc.Count - 1}. Запрашиваемый индекс: {id}"); // + 3
            }

            var len = stc.Count; // + 2
            _n_OP += 7; 

            Stack<int> stc_2 = new Stack<int>(); // + 3
            for (int i = 0; i < len; i++) // + 2
            {
                var x = stc.Pop(); // + 2

                _n_OP += 4;
                if (id == i)
                {
                    stc_2.Push(newValue); // + 2
                    _n_OP += 2;
                }
                else
                {
                    stc_2.Push(x); // + 1
                    _n_OP++;
                }
            }

            stc.Clear();

            // + 2
            _n_OP += 2;
            
            for (int i = 0; i < len; i++) // + 2
            {
                var x = stc_2.Pop(); // + 2

                stc.Push(x); // + 1
                _n_OP += 5;
            }
        }

        public static void Sort(ref Stack<int> stack) // + 1
        {
            var N = stack.Count; // + 2

            // + 2
            _n_OP += 5;

            for (int i = 0; i < N; i++) // + 2 + 4
            {
                _n_OP += 6;
                for (int j = 0; j < N - 1 - i; j++) // + 4
                {
                    var x = Get(stack, j); // + 3
                    var y = Get(stack, j + 1); // + 4

                    _n_OP += 11;

                    _n_OP += 1;
                    if (x > y) // + 1
                    {
                        Set(ref stack, j, y); // + 3
                        Set(ref stack, j + 1, x); // + 4

                        _n_OP += 7;
                    }
                }
            }
        }

        public static void FillByRandom(ref Stack<int> stack, int count) // + 2
        {
            Random random = new Random(); // + 3
            int N = count; // + 2

            _n_OP += 7;

            // + 2
            _n_OP += 2;
            for (int i = 0; i < N; i++) // + 2
            {
                stack.Push(random.Next(1, 100)); // + 3

                _n_OP += 5;
            }
        }

        public static ulong GetNOP()
        {
            return _n_OP;
        }

        public static void ClearNOP()
        {
            _n_OP = 0;
        }

    }
}