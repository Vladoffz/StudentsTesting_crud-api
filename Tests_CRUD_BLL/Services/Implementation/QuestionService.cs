﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tests_CRUD_BLL.Models;
using Tests_CRUD_BLL.Services.Interfaces;
using Tests_CRUD_DAL.Repositories.Interfaces;

namespace Tests_CRUD_BLL.Services.Implementation
{
    public class QuestionService : IQuestionService
    {
        public IQuestionRepository Repository { get; set; }

        public QuestionService(IQuestionRepository repository)
        {
            this.Repository = repository;
        }
        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Question obj)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(Question obj)
        {
            throw new NotImplementedException();
        }
    }
}