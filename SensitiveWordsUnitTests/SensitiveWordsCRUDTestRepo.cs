using Moq;
using Sensitivewords_Business.Contracts;
using Sensitivewords_Business.Entities;
using Sensitivewords_Business.Services;
using System.Threading.Tasks;
using Xunit;

namespace SensitiveWordsUnitTests
{
    public class SensitiveWordsCRUDTestRepo
    {
     [Fact]
     public void AddWord_AddNewWord_ReturnsOneWhenAddedSuccefully()
        {
            //arrange
            var word = new Word() { Name = "ReturnsOneWhenAddedSuccefully" };

            var mockRepo = new Mock<ISensitiveWordsRepository>();
            mockRepo.Setup(x => x.AddWord(word)).Returns(Task.FromResult((1)));

            var repo = new SensitiveWordsServices(mockRepo.Object).AddWord(word);
            //act
            
            //assert
            Assert.Equal(1, repo.Result);
        }

     [Fact]
     public void GetWord_Return_ReturnsWordByKeyWord()
        {
            //arrange
            var word = new Word() { Name = "ReturnsOneWhenAddedSuccefully" };

            var mockRepo = new Mock<ISensitiveWordsRepository>();
            mockRepo.Setup(x => x.GetWord(word.Name)).Returns(Task.FromResult((word)));

            var repo = new SensitiveWordsServices(mockRepo.Object).GetWord(word.Name);
            //act

            //assert
            Assert.Equal("ReturnsOneWhenAddedSuccefully", repo.Result.Name);
        }

     [Fact]
     public void DeleteWord_DeleteWordFormDB_RemoveWordFromDBAndReturnBooleanValue()
        {
            //arrange
            var word = new Word() { Name = "ReturnsOneWhenAddedSuccefully" };

            var mockRepo = new Mock<ISensitiveWordsRepository>();
            mockRepo.Setup(x => x.RemoveWord(word.Name)).Returns(Task.FromResult((true)));

            //act
            var repo = new SensitiveWordsServices(mockRepo.Object).RemoveWord(word.Name);

            //assert
            Assert.True(repo.Result);
        }

     [Fact]
     public void IsWordSensitive_IsTheWordPassedByClientSensitive_ReturnsTrueIfTheWordIsSensitive()
     {
            //arrange
            var word = new Word() { Name = "ReturnsOneWhenAddedSuccefully" };

            var mockRepo = new Mock<ISensitiveWordsRepository>();
            mockRepo.Setup(x => x.IsWordSensitive(word.Name)).Returns(Task.FromResult((true)));

            //act
            var repo = new SensitiveWordsServices(mockRepo.Object).IsWordSensitive(word.Name);

            //assert
            Assert.True(repo.Result);
      }

     [Fact]
     public void UpdateWord_UpdateWordOnDataBase_UpdateTheWordAndReturnsTrue()
        {
            //arrange
            var word = new Word() {Id= 10, Name = "ReturnsOneWhenAddedSuccefully" };

            var mockRepo = new Mock<ISensitiveWordsRepository>();
            mockRepo.Setup(x => x.UpdateWord(word.Id, word)).Returns(Task.FromResult((true)));

            //act
            var repo = new SensitiveWordsServices(mockRepo.Object).UpdateWord(word.Id, word);

            //assert
            Assert.True(repo.Result);
        }
    }
}
