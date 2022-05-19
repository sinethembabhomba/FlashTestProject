using Sensitivewords_BL.Contracts;
using Sensitivewords_BL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sensitivewords_BL.Services
{
    public class SensitiveWordsServices : ISensitiveWordsServices
    {
        private readonly ISensitiveWordsRepository _sensitiveWordsRepository;

        public SensitiveWordsServices(ISensitiveWordsRepository sensitiveWordsRepository)
        {
            _sensitiveWordsRepository = sensitiveWordsRepository;
        }

        public Task<int> AddWord(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Word>> GetAllWord()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetWord(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveWord(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateWord(Guid id, string name)
        {
            throw new NotImplementedException();
        }
    }
}
