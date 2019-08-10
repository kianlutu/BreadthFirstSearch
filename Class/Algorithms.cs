using System;
using System.Collections.Generic;

namespace BreadthFirstSearch.Class
{
    public class Algorithms
    {

        //The generic is the node
        public HashSet<T> BFS<T>(Graph<T> graph, T start, Action<T> preVisit = null)
        {
            //visited is the order visited
            HashSet<T> visited = new HashSet<T>();

            //checks if the start node has any neighbors
            //if it doesnt have any neighbors, then it just returns
            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            //Breadth First Search uses a Queue instead of a stack
            var queue = new Queue<T>();
            //start is Enqueued because it's where we begin our traversal
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                T vertex = queue.Dequeue();
                //The base case of if we've already visited this node 
                //Then continue through the loop
                //
                //The first iteration doesnt count since 
                //visited contains nothing to begin with
                ////
                ////For every iteration after the first this it will check through
                ////the queue to see if it has visited it already and if it hasn't
                ////then it checks for all of it's neighbors. If it has visited that vertex
                ////then it continues to the next item on the queue
                if (visited.Contains(vertex))
                    continue;

                //performs an action the vertex if given a delegate method in the parameter
                if (preVisit != null)
                    preVisit(vertex);

                //Adds it to visited if it wasnt visited
                visited.Add(vertex);

                //Enques each neighbor on to the stack
                //and is checked if it is visited once complete

                foreach (var neighbor in graph.AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
            }
            //Once the loop completes, it returns the order that it visited each node
            return visited;
        }
    }
}