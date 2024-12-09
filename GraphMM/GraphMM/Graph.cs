namespace GraphMM
{
    /// <summary>
    /// Список методов для описания решений задач:
    /// - представление графов;
    /// - обход графа;
    /// Считаем, что узлы графа всегда представлены целыми числами от 1 до N
    /// (не нужно писать дополнительные проверки).
    /// </summary>
    public static class Graph
    {
        /// <summary>
        /// Преобразует представление ориентированного графа из списка ребер в матрицу смежности.
        /// </summary>
        /// <param name="nodes">Список ребер. 
        /// Каждое ребро представлено кортежом из двух значений: 
        /// откуда есть стрелка (первое значение) и куда (второе значение).
        /// </param>
        /// <returns>Возвращает двумерный массив, соответствующий матрице смежности.
        /// Нулевые строка и столбец массива соответствует 1 пункту назначения.
        /// </returns>
        public static int[,] ToAdjacencyMatrix(List<(int, int)> nodes)
        {
            
            int v = nodes.SelectMany(e => new[] { e.Item1, e.Item2 }).Distinct().Count();
            int[,] matrix = new int[v, v];
            foreach (var node in nodes)
            {
                matrix[node.Item1-1, node.Item2-1] = 1;
            }
            return matrix;
        }


        /// <summary>
        /// Преобразует представление ориентированного графа из списка ребер в список смежности.
        /// </summary>
        /// <param name="nodes">
        /// Список ребер. 
        /// Каждое ребро представлено кортежом из двух значений: 
        /// откуда есть стрелка (первое значение) и куда (второе значение).
        /// </param>
        /// <returns>
        /// Возвращает словарь, соответствующий списку смежности.
        /// Ключом словаря является номер узла. Значением - отсортированный список смежных вершин.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Dictionary<int, List<int>> ToAdjacencyList(List<(int, int)> nodes)
        {
            Dictionary<int,List<int>> list=new Dictionary<int, List<int>>();
            foreach (var (u, v) in nodes)
            {
                if (!list.ContainsKey(u))
                {
                    list[u]=new List<int> { v };
                }
                else
                {
                    list[u].Add(v);
                }

                if (!list.ContainsKey(v))
                {
                    list[v] = new List<int>();
                }
                
                
            }
            return list;
        }


        /// <summary>
        /// Проверяет, существует ли маршрут из пункта first в пункт second.
        /// </summary>
        /// <param name="nodes">
        /// Список ребер, представляющий граф.
        /// </param>
        /// <param name="first">Номер первого пункта назначения.</param>
        /// <param name="second">Номер второго пункта назначения.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool HasConnection(List<(int, int)> nodes, int first, int second)
        {
            Dictionary<int, List<int>> list = ToAdjacencyList(nodes);
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();
            queue.Enqueue(first);
            while (queue.Count > 0)
            {
                int node=queue.Dequeue();
                if (node == second)
                {
                    return true;
                }
                if (list.ContainsKey(node))
                {
                    foreach (int u in list[node])
                    {
                        if (!visited.Contains(u))
                        {
                            queue.Enqueue(u);
                            visited.Add(u);
                        }
                        if (!visited.Contains(u))
                        {
                            queue.Enqueue(u);
                            visited.Add(u);
                        }
                    }
                }

            }
            return false;
        }
    }
}
