using System;
using System.Collections.Generic;
using System.Data;
using checkpoint7.Models;
using Dapper;

namespace checkpoint7.Services
{
    public class StepsRepository
    {
        private readonly IDbConnection _db;

        public StepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Step> GetAll()
        {
            string sql = @"
            SELECT
            s.*
            a.*
            FROM steps s
            JOIN accounts a ON a.id = s.creatorID;
            ";

            List<Step> steps = _db.Query<Step, Account, Step>(sql, (step, account) =>
            {
                step.Creator = account;
                return step;
            }).ToList();
            return steps;
        }

        internal StepsRepository Create(StepsRepository newStep)
        {
            throw new NotImplementedException();
        }
    }
}