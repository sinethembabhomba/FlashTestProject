using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sensitivewords_API.Dto_s;
using Sensitivewords_API.Errors;
using Sensitivewords_API.Helper;
using Sensitivewords_Business.Contracts;
using Sensitivewords_Business.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sensitivewords_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensitivewordsController : ControllerBase
    {
        private readonly ISensitiveWordsService _sensitiveWordsServices;
        private readonly IMapper _mapper;

        public SensitivewordsController(ISensitiveWordsService sensitiveWordsServices, IMapper mapper)
        {
            _sensitiveWordsServices = sensitiveWordsServices;
            _mapper = mapper;
        }

        [HttpGet("{word}")]
        public async Task<ActionResult<WordDto>> GetWordByKeyWord(string word)
        {
            if(word == null)
                return NotFound();

            var results = await _sensitiveWordsServices.GetWord(word);
            var mapedResult = _mapper.Map<Word,WordDto>(results);
            return Ok(mapedResult);
        }

        [HttpGet("getwordslist")]
        public async Task<ActionResult<IReadOnlyList<WordDto>>> ReadWordList()
        {
            var results = await _sensitiveWordsServices.GetAllWord();
            return Ok(results);
        }

        [HttpPost("addword")]
        public async Task<ActionResult<string>> AddWord(WordDto name)
        {
            if(name.Name == null)
                return BadRequest(new ApiResponse(400, "Name field is required"));

            if ( await _sensitiveWordsServices.IsWordSensitive(name.Name))
            {
                var message = SensitiveWordLookUp.StarOutWord(name.Name);
                return BadRequest(new ApiResponse(400, message));
            }
            else
            {
                var wordresult = _mapper.Map<WordDto, Word>(name);

                return Ok(await _sensitiveWordsServices.AddWord(wordresult));
                
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWordD(int id, WordDto wordDto)
        {
            if (wordDto == null)
                return NotFound();



            if (await _sensitiveWordsServices.IsWordSensitive(wordDto.Name))
            {
                var message = SensitiveWordLookUp.StarOutWord(wordDto.Name);
                return BadRequest(new ApiResponse(400, message));
            }

            else
            {
                var wordresult = _mapper.Map<WordDto, Word>(wordDto);

                return Ok(await _sensitiveWordsServices.UpdateWord(id,wordresult));

            }
        }

        [HttpPost]
        [Route("DeleteWordDto")]
        public async Task<IActionResult> DeleteWordDtot(string word)
        {
           
            if (word == null)
            {
                return BadRequest();
            }

            try
            {
                if (await _sensitiveWordsServices.IsWordSensitive(word))
                {
                    var message = SensitiveWordLookUp.StarOutWord(word);
                    return BadRequest(new ApiResponse(400, message));
                }

                if (!await _sensitiveWordsServices.RemoveWord(word))
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
