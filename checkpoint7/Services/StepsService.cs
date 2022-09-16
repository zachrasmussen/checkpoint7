



using System.Collections.Generic;
using checkpoint7.Models;

namespace checkpoint7.Services
{
    public class StepsService
    {
        private readonly StepsRepository _stepsRepo;
        public StepsService(StepsRepository stepsRepo)
        {
            _stepsRepo = stepsRepo;
        }

        internal List<Step> GetAll()
        {
            return _stepsRepo.GetAll();
        }

        internal StepsRepository Create(StepsRepository newStep)
        {
            return _stepsRepo.Create(newStep);
        }
    }
}