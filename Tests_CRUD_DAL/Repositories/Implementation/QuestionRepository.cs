﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tests_CRUD_DAL.Entities;
using Tests_CRUD_DAL.Repositories.Interfaces;

namespace Tests_CRUD_DAL.Repositories.Implementation
{
    public class QuestionRepository : IQuestionRepository
    {
        private ApplicationContext _context;

        public QuestionRepository()
        {
            _context ??= new ApplicationContext();
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return false;
            }

            _context.Questions.Remove(question);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(Question obj)
        {
            var question = await _context.Questions.FindAsync(obj.Id);
            if (question == null)
            {
                return false;
            }

            question.TestId = obj.TestId;
            question.Text = obj.Text;

            question.Answers = _context.Answers.Where(x => x.QuestionId == obj.Id);
            question.Test = await _context.Tests.FindAsync(obj.TestId);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task CreateAsync(Question obj)
        {
            await _context.Questions.AddAsync(obj);
            await _context.SaveChangesAsync();
        }
    }
}