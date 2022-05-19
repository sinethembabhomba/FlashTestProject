﻿using Sensitivewords_BL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sensitivewords_BL.Contracts
{
    public interface ISensitiveWordsServices
    {
        Task<int> AddWord(string name);
        Task<bool> RemoveWord(string name);
        Task<bool> UpdateWord(Guid id, string name);
        Task<string> GetWord(string name);
        Task<List<Word>> GetAllWord();
    }
}
