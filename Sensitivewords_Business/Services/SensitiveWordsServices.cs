using Sensitivewords_Business.Contracts;
using Sensitivewords_Business.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sensitivewords_Business.Services
{
    public class SensitiveWordsServices : ISensitiveWordsService
    {
        private readonly ISensitiveWordsRepository _sensitiveWordsRepo;
        public SensitiveWordsServices(ISensitiveWordsRepository sensitiveWordsRepository)
        {
            _sensitiveWordsRepo = sensitiveWordsRepository;
        }
        public async Task<int> AddWord(Word name)
        {
            return await _sensitiveWordsRepo.AddWord(name);
        }
        public async Task<IReadOnlyList<Word>> GetAllWord()
        {
            return await _sensitiveWordsRepo.GetAllWord();
        }
        public async Task<Word> GetWord(string name)
        {
            return await _sensitiveWordsRepo.GetWord(name);
        }
        public async Task<bool> IsWordSensitive(string word)
        {
           return await _sensitiveWordsRepo.IsWordSensitive(word);
        }
        public async Task<bool> RemoveWord(string name)
        {
            return await _sensitiveWordsRepo.RemoveWord(name);
        }
        public async Task<bool> UpdateWord(int id, Word name)
        {
            return await _sensitiveWordsRepo.UpdateWord(id, name);
        }
    }
}
