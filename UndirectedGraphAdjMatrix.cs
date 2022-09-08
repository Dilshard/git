using System;


namespace Tutorial_9
{
    class UndirectedGraphAdjMatrix : Graph
        {
            private const int NOT_ADJACENT = -1;
            private const int DEFAULT_WEIGHT = 1;

            private int[,] AM;

            public UndirectedGraphAdjMatrix(String graphName, int numberOfVertices)
                   : base(graphName, numberOfVertices)
            {
                AM = new int[numberOfVertices, numberOfVertices];
            }

            public UndirectedGraphAdjMatrix(String graphName, int numberOfVertices, int[,] Edges)
                   : base(graphName, numberOfVertices, Edges)
            {
                // Create the Adjacency Matrix for the graph

                AM = new int[numberOfVertices, numberOfVertices];

                // Initialise the Adjacency Matrix to have no edges
                for (int sv = 0; sv < numberOfVertices; sv++)
                {
                    for (int dv = 0; dv < numberOfVertices; dv++)
                    {
                        AM[sv, dv] = NOT_ADJACENT;
                    }
                }

                // Add the edges to the Adjacency Matrix 

                int numbEdges = Edges.GetLength(0); // size of 1st dimension of Edges[,]

                for (int edge = 0; edge < numbEdges; edge++)
                {
                    addEdge(Edges[edge, 0], Edges[edge, 1]);
                }

            }


            private bool validVertex(int vertex)
            {
                return (0 <= vertex & vertex <= numberOfVertices() - 1);
            }

            override public bool addEdge(int sourceVertex, int destinationVertex)
            {
                if (validVertex(sourceVertex) & validVertex(destinationVertex))
                {
                    // add edge "(sV, dV)"  & "(dV, sV)" to the graph by setting AM[sV, dV] != 0

                    AM[sourceVertex, destinationVertex] = DEFAULT_WEIGHT;

                    AM[destinationVertex, sourceVertex] = DEFAULT_WEIGHT;

                    cardEdges++;

                    Console.WriteLine("Edge {{ {0}, {1} }} added to graph", sourceVertex, destinationVertex);
                    return true;
                }
                else
                {
                    Console.WriteLine("Edge {{ {0}, {1} }} INVALID - Not added to graph", sourceVertex, destinationVertex);
                    return false;
                }

            }

            override public bool removeEdge(int sourceVertex, int destinationVertex)
            {
                if (validVertex(sourceVertex) & validVertex(destinationVertex))
                {
                    if (isAdjacent(sourceVertex, destinationVertex))
                    {
                        // remove edges "(sV, dV)" & "(dV, sV)" from the graph

                        AM[sourceVertex, destinationVertex] = NOT_ADJACENT;

                        AM[destinationVertex, sourceVertex] = NOT_ADJACENT;

                        this.cardEdges--;

                        Console.WriteLine("Edge {{ {0}, {1} }}: Deleted", sourceVertex, destinationVertex);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Edge {{ {0}, {1} }}: Cannot Delete - Does Not Exist", sourceVertex, destinationVertex);
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Edge {{ {0}, {1} }} INVALID - Not deleted from graph", sourceVertex, destinationVertex);
                    return false;
                }
            }

            override public bool isAdjacent(int sourceVertex, int destinationVertex)
            {
                // check if edge "(sV, dV)" exists in the graph by 
                // checking if the adjacency matrix has [sV, dV] != 0.

                if (validVertex(sourceVertex) & validVertex(destinationVertex))
                {
                    return (AM[sourceVertex, destinationVertex] != NOT_ADJACENT);
                }
                else
                {
                    Console.WriteLine("isAdjacent: FAILED - INVALID Edge {{ {0}, {1} }}", sourceVertex, destinationVertex);
                    return false;
                }


            }

    } // UndirectedGraphAdjMatrix

} // Tutorial_9

