using Sensitivewords_Business.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sensitivewords_Business.Contracts
{
    public interface ISensitiveWordsService
    {
        Task<int> AddWord(Word name);
        Task<bool> RemoveWord(string name);
        Task<bool> UpdateWord(int id, Word name);
        Task<Word> GetWord(string name);
        Task<List<Word>> GetAllWord();
        Task<bool> IsWordSensitive(string word);
    }
}
