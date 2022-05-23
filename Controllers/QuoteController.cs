using Exam.Domain;
using Exam.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers;

[ApiController]
[Route("Api/[Controller]")]
public class QuoteController:ControllerBase
{
    private QuoteService _service;
    private IHostEnvironment _hostEnvironment;
    public QuoteController(QuoteService service, IHostEnvironment hostEnvironment)
    {
        _service = service;
        _hostEnvironment = hostEnvironment;
    }

    [HttpGet("GetQuotes")]
    public List<Quote> GetQuotes(){
        return _service.GetQuotes();
    }
    [HttpGet("GetQuotesByCategory")]
    public List<Quote> GetQuotesByCategory(int id){
        return _service.GetQuotesByCategory(id);
    }
    [HttpGet("GetRendomeQuote")]
    public List<Quote> GetRendomeQuote(int count){
        return _service.GetRendomeQuote(count);
    }

    [HttpPost("InsertQuote")]
    public int InsertQuote(UIQuote iquote){
        return _service.InsertQuote(iquote);
    }
    [HttpPost("UpdateQuote")]
    public int UpdateQuote(UIQuote uquote, int Id){
        return _service.UpdateQuote(uquote, Id);
    }

     [HttpDelete("DeleteQuoteById")]
    public int DeleteQuoteById(int Id){
        return _service.DeleteQuoteById(Id);
    }
     [HttpPost("InsertFile")]
    public async Task<string> InsertFile(List<IFormFile> files){
       return await _service.InsertFile(files);
    }



}
