using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sensitivewords_API.Dto_s;
using Sensitivewords_API.Errors;
using Sensitivewords_API.Helper;
using Sensitivewords_Business.Contracts;
using Sensitivewords_Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        [HttpGet("getwordbykeyword/{word}")]
        public async Task<ActionResult<WordDto>> GetWordByKeyWord(string word)
        {
            if(word == null)
                return NotFound(new ApiResponse(400, "word not found"));

            var results = await _sensitiveWordsServices.GetWord(word);
            var mapedResult = _mapper.Map<Word,WordDto>(results);
            return Ok(mapedResult);
        }

        [HttpGet("getwords")]
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


                var wordresult = _mapper.Map<WordDto, Word>(name);
               var results = await _sensitiveWordsServices.AddWord(wordresult);

                if (results == 0) return BadRequest(new ApiResponse(400, "Name Already Exist"));

                return Ok(new ApiResponse(200,"Added succesfully"));
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, WordDto wordDto)
        {
            if (wordDto == null)
                return BadRequest(new ApiResponse(400, "Word is required"));

                var wordresult = _mapper.Map<WordDto, Word>(wordDto);
                return Ok(await _sensitiveWordsServices.UpdateWord(id,wordresult));
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete(string word)
        {
           
            if (word == null)
            {
                return BadRequest(new ApiResponse(400, "Word is required"));
            }

            try
            {
                if (!await _sensitiveWordsServices.RemoveWord(word))
                {
                    return NotFound(new ApiResponse(400, "Word not found"));
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost("sendmessage")]
        public async Task<IActionResult> SendMessage(string message)
        {
            var results = await _sensitiveWordsServices.GetAllWord();

            //Only select name from a list object
            var words = results.Select(x => x.Name).ToList();

            //Split messange into an array so that you can itarate through it and comparing each word on the sentance with 
            var splittedSentMessege = message.Split(" ");

            //String builder to append words after star out
            var output = new StringBuilder();

            var tempList = new List<string>();

            foreach (var messageword in splittedSentMessege)
            {
                foreach (var word in words)
                {
                    if (word.ToLower() == messageword.ToLower())
                    {
                        var staredWord = SensitiveWordLookUp.StarOutWord(messageword);
                        output.Append(staredWord + " ");
                        tempList.Add(messageword);
                    }
                }
                //check the words that are not stared out are present in list and if they not present, add them to the list.
                if (!tempList.Contains(messageword))
                    output.Append(messageword + " ");
            }
            return Ok(new ApiResponse(200,output.ToString()));
        }

    }
}
