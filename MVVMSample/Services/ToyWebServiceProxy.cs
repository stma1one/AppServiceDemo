﻿using MVVMSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVVMSample.Services
{
    internal class ToyWebServiceProxy : IToys
    {
        HttpClient client;//יטפל בבקשות ובתשובות מהשרת
        JsonSerializerOptions options;//להגדיר את האופן שבו יתבצעו פעולות הסיריליאזציה והדה סירי
        
        const string URL = "https://mhmdqzkj-7046.euw.devtunnels.ms/api/ToysApi/";//כתובת השרת באמצעות devtunnels
        const string IMAGE_URL = "https://mhmdqzkj-7046.euw.devtunnels.ms/Images/";//כתובת שבו נמצאות התמונות בשרת


        public ToyWebServiceProxy()
        {
            //Work With Cookies
            HttpClientHandler handle = new HttpClientHandler() { CookieContainer = new System.Net.CookieContainer(), UseCookies=true };
            //Create Client
            client = new HttpClient(handle, true);
            //הגדרות הסיריליאזציה
            options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true, WriteIndented=true };

        }
        public async Task<User> Login(string username, string password)
        {
            //create Json using anonymous type
            string json = JsonSerializer.Serialize(new
            {
                Email = username,
                Password = password
            },options);

            //make json available for the httpclient
            //StringContent is Http Content Wrapper
            //list of possible media Types: https://www.sitepoint.com/mime-types-complete-list/
            StringContent content = new StringContent( content: json,encoding:Encoding.UTF8, mediaType:"application/json");
            try
            {
                //שלח את הבקשה לשרת
                var response = await client.PostAsync($"{URL}login", content);
                //מה לעשות בהתאם לסטטוס החוזר
                /*switch (response.StatusCode)
                {
                    case (HttpStatusCode.OK):
                        json = await response.Content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize<User>(json);
                        break;
                    case (HttpStatusCode.BadGateway):
                        Console.WriteLine("URL not valid");
                        return null;
                        break;
                    default: return null;
                   }
          
                 */

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //read the json from the result content
                    json=await response.Content.ReadAsStringAsync();
                    if (json != null)
                    {
                        //deserialize
                        User? u= JsonSerializer.Deserialize<User>(json,options);
                        return u;
                    }
                }
               

            }
            catch(Exception ex) {  }
            return null;




        }
        public async Task<List<Toy>> GetToyByType(ToyTypes type)
        {
            //פעולת GET פשוטה יותר כי לא דורשת סיריאליזציה
            //רק מביאה מידע
            try
            {
                string json = string.Empty;//הג'ייסון שיקלט
                List<Toy>? toys;//האוסף שיוחזר

                //פניה לשרת עם פרמטרים
                var response = await client.GetAsync(@$"{URL}Toys\typeId={type.Id}");
                //אם הכל תקין
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //נקרא את הג'ייסון
                    json = await response.Content.ReadAsStringAsync();
                    //נמיר את הנתונים בדה סיריליאזיציה
                    toys = JsonSerializer.Deserialize<List<Toy>>(json);
                    //צריך לעדכן את הנתיב של התמונות...
                    foreach (var toy in toys)
                    {
                        toy.Image = $@"{IMAGE_URL}{toy.Image}";
                    }
                    return toys;
                }
                //אחרת נחזיר רשימה ריקה
                return new List<Toy>();


            }
            catch (Exception ex) { return new List<Toy>(); }
        }
        public async Task<List<Toy>?> GetToys()
        {
            //פעולת GET פשוטה יותר כי לא דורשת סיריאליזציה
            //רק מביאה מידע
            try
            {
                string json=string.Empty;//הג'ייסון שיקלט
                List<Toy>? toys;//האוסף שיוחזר

                //פניה לשרת
                var response = await client.GetAsync(@$"{URL}Toys/0");
                //אם הכל תקין
                if (response.StatusCode == HttpStatusCode.OK)
                    //נקרא את הגייסון
                { json = await response.Content.ReadAsStringAsync();
                    //נמיר אותו תוך שימוש באפשרויות 
                  toys=JsonSerializer.Deserialize<List<Toy>>(json,options);
                    //נעדכן את הנתיב לתמונות
                    foreach (var toy in toys)
                    {
                        toy.Image = $@"{IMAGE_URL}{toy.Image}";
                    }
                    return toys;
                }
                //אחרת
                return new List<Toy>();             
 
                
            }
            catch (Exception ex) { return new List<Toy>(); }

        }
        public Task<bool> AddToy(Toy toy)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteToy(Toy toy)
        {
            throw new NotImplementedException();
        }



        public Task<List<Toy>?> GetToysByPriceCondition(double price, bool abovePrice)
        {
            throw new NotImplementedException();
        }

        public Task<List<Toy>?> GetToysByPriceCondition(Predicate<double> condition)
        {
            throw new NotImplementedException();
        }

        public Task<List<ToyTypes>?> GetToyTypes()
        {
            throw new NotImplementedException();
        }

    }
}
