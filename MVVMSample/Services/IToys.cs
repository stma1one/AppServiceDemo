using MVVMSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSample.Services;

interface IToys
{

    //בשלב זה רק לדעת מה הפעולות שניתן לבצע באמצעות השרות
    Task<List<Toy>?> GetToys();//החזרת אוסף צעצועים
    Task<List<ToyTypes>?> GetToyTypes();//החזרת סוגי צעצועים
    public Task<List<Toy>> GetToyByType(ToyTypes type);//החזרת אוסף צעצועים לפי סוג
    public Task<List<Toy>?> GetToysByPriceCondition(double price, bool abovePrice);//החזרת צעצועים מעל או מתחת מחיר
    public Task<List<Toy>?> GetToysByPriceCondition(Predicate<double> condition);//החזרת צעצועים עפ"י תנאי
    public Task<bool> AddToy(Toy toy);//הוספת צעצוע
    public Task<bool> DeleteToy(Toy toy);//מחיקת צעצוע

    public Task<User> Login(string username, string password);  //חיבור



}
