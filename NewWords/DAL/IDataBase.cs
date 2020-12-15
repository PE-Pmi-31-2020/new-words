using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IDataBase
    {
        DbSet<Subject> subjects { get; set; }
        DbSet<User> users { get; set; }
        DbSet<Word> words { get; set; }
    }
}