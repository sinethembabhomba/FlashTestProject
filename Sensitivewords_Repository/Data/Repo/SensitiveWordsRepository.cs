using Microsoft.EntityFrameworkCore;
using Sensitivewords_Business.Contracts;
using Sensitivewords_Business.Entities;
using Sensitivewords_Repository.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sensitivewords_Repository.Data.Repo
{
    public class SensitiveWordsRepository : ISensitiveWordsRepository
    {
        private readonly SensitiveWordsContext _storeContext;
        public SensitiveWordsRepository(SensitiveWordsContext sensitiveWordsContext)
        {
            _storeContext = sensitiveWordsContext;
        }

        public async Task<int> AddWord(Word name)
        {
            try
            {
                var isWordExist = await _storeContext.Words.FirstOrDefaultAsync(w => w.Name == name.Name);
                if (isWordExist != null) return 0;

                _storeContext.Words.Add(name);
                return await _storeContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);

                return 0;
            }
        }
        public async Task<List<Word>> GetAllWord()
        {
            try
            {
                return await _storeContext.Words.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<Word> GetWord(string name)
        {
            try
            {
                var entity = await _storeContext.Words.FirstOrDefaultAsync(x=> x.Name == name);

                if (entity != null && !string.IsNullOrEmpty(entity.Name))
                    return entity;

                return new Word() { };
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return null;
        }
        public async Task<bool> IsWordSensitive(string word)
        {
            var result = await _storeContext.Words.FirstOrDefaultAsync(x => x.Name == word);
            if (result != null)
                return true;
            else
                return false;
        }
        public async Task<bool> RemoveWord(string name)
        {
            try
            {
                var word = await _storeContext.Words.FirstOrDefaultAsync(x=> x.Name == name);

                //Delete that post
                var results =  _storeContext.Remove(word);

                //Commit the transaction
                 await _storeContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);

                return false;

            }
        }
        public async Task<bool> UpdateWord(int id, Word name)
        {
            try
            {
                  var word = await _storeContext.Words.FindAsync(id);
                  word.Name = name.Name;
                 _storeContext.Update(word);

                var result = await _storeContext.SaveChangesAsync();

                if (result == 1) return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);

                return false;

            }
        }
    }
}
