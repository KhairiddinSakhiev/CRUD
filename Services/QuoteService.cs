using Dapper;
using Exam.Domain;
using Npgsql;

namespace Exam.Services;

public class QuoteService
{
    private string ConnectionString = "Server = 127.0.0.1; Port = 5432; Database = ExamDb; User Id = postgres; Password = sakhi2000";
    private IHostEnvironment _hostEnvironment;
    private NpgsqlConnection _connection;
    public QuoteService(IHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
        _connection = new NpgsqlConnection(ConnectionString);
    }

    public List<Quote> GetQuotes(){
        using(_connection){
           var sql = $"select q.id , q.quotename , q.author , c.categoryname from quote q join category c on c.id = q.categoryid";
            var res = _connection.Query<Quote>(sql);
            return res.ToList();
        }
    }
    public int DeleteQuoteById(int Id){
        using(_connection){
           var sql = $"delete from quote q where q.id = {Id}";
            var res = _connection.Execute(sql);
            return res;
        }
    }
    
     public List<Quote> GetQuotesByCategory(int Id){
        using(_connection){
           var sql = $"select q.id , q.quotename , q.author , c.categoryname from quote q join category c on c.id = q.categoryid where q.categoryid = {Id}";
            var res = _connection.Query<Quote>(sql);
            return res.ToList();
        }
    }
     public List<Quote> GetRendomeQuote(int count){
        using(_connection){
           var sql = $"select q.id , q.quotename , q.author , c.categoryname from quote q join category c on c.id = q.categoryid order by random() limit {count} ";
            var res = _connection.Query<Quote>(sql);
            return res.ToList();
        }
    }

    public int InsertQuote(UIQuote iquote){
        using(_connection){
            var sql = $"insert into quote(quotename, author, categoryid) values ('{iquote.QuoteName}', '{iquote.Author}', '{iquote.CategoryId}')";
            var res = _connection.Execute(sql);

            return res;            
        }
    }
    public int UpdateQuote(UIQuote iquote, int Id){
        using(_connection){
            var sql = $"update quote set quotename = '{iquote.QuoteName}',"+
            $"author = '{iquote.Author}',"+
            $"categoryid = '{iquote.CategoryId}' where id = {Id}";
            var res = _connection.Execute(sql);
            return res;            
        }
    }

    
   public async Task<string> InsertFile(List<IFormFile> files){
       if(files.Count > 0){
           var root = _hostEnvironment.ContentRootPath;
           foreach(var file in files){
               var path = Path.Combine(root, "Downloads", file.FileName);
               using(var fileStream = new FileStream(path,FileMode.Create)){
                   await file.CopyToAsync(fileStream);
               }
           }
           return "Success";
       }
       return "Failed";
   }
}
