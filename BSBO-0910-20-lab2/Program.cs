using System;
using System.Collections.Generic;
using System.Linq;

namespace BSBO_0910_20_lab2
{
    class Program
    {
       //mh
        //st<int> g, gr = new List<int>;

       static List<bool> used_node = new List<bool>();
        static List<List<int>> graph, transpose_graph;
        static List<int> order,component;
        static void Main(string[] args)
        {
            // Определить в орграфе сильно связные компоненты, подсчитать их число и вывести состав (номера узлов) каждой сильно связной компоненты.
            // Матрица инцидентности
            int[,] matrix = new int[,]
                {
                {1,-1,0,0,0,0,0,0,0,0,0,0,0,0 },//вершина а
                {-1,0,1,1,0,0,0,0,0,0,0,0,1,0 },//вершина b
                {0,0,0,-1,-1,1,0,0,0,1,0,0,0,0 },//вершина c
                {0,0,0,0,1,-1,-1,1,0,0,0,0,0,0 },//вершина d
                {0,1,-1,0,0,0,0,0,0,0,0,0,0,1},//вершина e
                { 0,0,0,0,0,0,0,0,0,0,-1,1,-1,-1 },//вершина f
                { 0,0,0,0,0,0,0,0,-1,-1,1,-1,0,0},//вершина g
                { 0,0,0,0,0,0,1,-1,1,0,0,0,0,0},//вершина h
                };
            graph = Init(matrix);
            transpose_graph = Transpose(graph);
            used_node = Enumerable.Repeat(false, 8).ToList();

        }
        // Функция dfs1 выполняет обход в глубину на графе G
        static void dfs1(int v)
        {
            used_node[v] = true;
            foreach(var node in GetNodes(v))
            {
                if (!used_node[node])
                {
                    dfs1(node);
                }
            }
            order.Add(v);
            
        }


        //недоделано!!!!!
        static void dfs2(int v)
        {
            used_node[v] = true;
            component.Add(v);
            foreach (var node in GetNodes(v))
            {
                if (!used_node[node])
                {
                    dfs1(node);
                }
            }
            
            /*
            void dfs2(int v)
            {
                used[v] = true;
                component.push_back(v);
                for (size_t i = 0; i < gr[v].size(); ++i)
                    if (!used[gr[v][i]])
                        dfs2(gr[v][i]);
             }*/
        }

        static List<int> GetNodes(int v)
        {
            List<int> res = new List<int>();
            for (int i = 0; i < 8; i++)
            {
                if (i == v) continue;
                for (int j = 0; j < 14; j++)
                {
                    if (- graph[v][j] == graph[i][j])
                    {
                        res.Add(i);
                    }
                }
            }
            return res;
        }

        

        static List<List<int>> Init (int[,] arr)
        {
            List<List<int>> res_list = new List<List<int>>();
            for (int i = 0; i<8; i++)
            {
                List<int> new_node = new List<int>();
                for (int j = 0; j < 14; j++)
                {
                    new_node.Add(arr[i, j]);
                }
                res_list.Add(new_node);

            }
            return res_list;
        }

        static List<List<int>> Transpose (List<List<int>> graph)
        {
            List<List<int>> result_graph = new List<List<int>>();
            foreach (var node in graph)
            {
                List<int> new_node = new List<int>();
                for (int i = 0; i < node.Count; i++)
                {
                    new_node.Add(-node[i]) ;
                }
                result_graph.Add(new_node);
            }
            return result_graph;
        }
    }
}
