using System;
using System.Collections.Generic;

namespace PlagCheck_Server
{
    [Serializable]
    public class Response
    {
        private PlagCheck_Client.Request sourceRequest;
        private List<Solution> serverSolutionList;
        private List<List<float>> similarityMatrix;

        public Response()
        {
            sourceRequest = new PlagCheck_Client.Request();
            serverSolutionList = new List<Solution>();
            similarityMatrix = new List<List<float>>();
        }

        public Response(PlagCheck_Client.Request srcReq, List<Solution> svSList)
        {
            sourceRequest = srcReq;
            serverSolutionList = svSList;
            int N = srcReq.SolutionList.Count + svSList.Count;
            similarityMatrix = new List<List<float>>();
            for (int i=0; i<N; i++)
            {
                similarityMatrix.Add(new List<float>());
                for (int j=0; j<N; j++)
                {
                    similarityMatrix[i].Add(0);
                }
            }
        }

        public PlagCheck_Client.Request SourceRequest { get => sourceRequest; set => sourceRequest = value; }
        public List<Solution> ServerSolutionList { get => serverSolutionList; set => serverSolutionList = value; }
        public List<List<float>> SimilarityMatrix { get => similarityMatrix; set => similarityMatrix = value; }
    }
}
