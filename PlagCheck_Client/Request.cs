using System;
using System.Collections.Generic;
using PlagCheck_Server;

namespace PlagCheck_Client
{
    [Serializable]
    public class Request
    {
        private PlagCheck_Server.Problem chosenProblem;
        private string chosenLanguage;
        private List<PlagCheck_Server.Solution> solutionList;
        private bool isInternalCheck;

        public Request()
        {
            chosenProblem = new PlagCheck_Server.Problem();
            chosenLanguage = "";
            solutionList = new List<PlagCheck_Server.Solution>();
            isInternalCheck = false;
        }

        public Request(PlagCheck_Server.Problem chosenProb, string lang, List<PlagCheck_Server.Solution> solList, bool internalCheck)
        {
            chosenProblem = chosenProb;
            chosenLanguage = lang;
            solutionList = solList;
            isInternalCheck = internalCheck;
        }

        public Problem ChosenProblem { get => chosenProblem; set => chosenProblem = value; }
        public string ChosenLanguage { get => chosenLanguage; set => chosenLanguage = value; }
        public List<Solution> SolutionList { get => solutionList; set => solutionList = value; }
        public bool IsInternalCheck { get => isInternalCheck; set => isInternalCheck = value; }
    }
}
