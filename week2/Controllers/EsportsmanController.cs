using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace week2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EsportsmanController : ControllerBase
    {
        private readonly List<Esportsman>  list;
            
        public delegate double Delegate(List<Esportsman> list);

        public EsportsmanController()
        {
            list = new List<Esportsman>()
            {
                new Esportsman() { Id = 1, Name = "Amer", Surname = "Al-Barkawi", NickName = "Miracle-", Birthday = new DateTime(1997, 6, 20), MMR = 11000 },
                new Esportsman() { Id = 2, Name = "Aliwi", Surname = "Omar", NickName = "w33", Birthday = new DateTime(1995, 3, 6), MMR = 9700 },
                new Esportsman() { Id = 3, Name = "Ivan", Surname = "Ivanov ", NickName = "MinD_ContRoL ", Birthday = new DateTime(1995, 1, 20), MMR = 9200 },
                new Esportsman() { Id = 4, Name = "Maroun", Surname = "Merhej ", NickName = "Gh", Birthday = new DateTime(1995, 6, 17), MMR = 9500 },
                new Esportsman() { Id = 5, Name = "Kuro", Surname = "Salehi Takhasomi ", NickName = "KuroKy", Birthday = new DateTime(1992, 10, 28), MMR = 9000 },
            };
        }

        [HttpGet]
        public List<Esportsman> GetAllMan()
        {
            return list.OrderBy(Esportsman => Esportsman.Id).ToList();
        }

       [HttpGet("id/{id}")]

        public Esportsman GetManById(int id)
        {
            return list.FirstOrDefault(Esportsman => Esportsman.Id == id);
        }

        [HttpGet("name/{name}")]

        public Esportsman GetManByName(string name)
        {
            return list.FirstOrDefault(Esportsman => Esportsman.Name == name);
        }

        [HttpGet("surname/{surname}")]

        public Esportsman GetManBySurname(string surname)
        {
            return list.FirstOrDefault(Esportsman => Esportsman.Surname == surname);
        }

        [HttpGet("nickname/{nickname}")]

        public Esportsman GetManByNickName(string nickname)
        {
            return list.FirstOrDefault(Esportsman => Esportsman.NickName == nickname);
        }

        [HttpGet("mmr")]
        public List<Esportsman> GetByMmr()
        {

            return list.OrderByDescending(Esportsman => Esportsman.MMR).ToList();//or we can write just orderby which will sort by ascending order.s

        }


        [HttpGet("birthyear/{year}")]
        public List<Esportsman> GetEqualBirthYear(int year)
        {
            return (from Esportsman in list where Esportsman.Birthday.Year.Equals(year) select Esportsman).ToList();
        }

            private double GetAverage(List<Esportsman> list)
        {
            return list.Average(Esportsman => Esportsman.MMR);
        }

        [HttpGet("getwithdelegate")]
        public double GetAverWithDelegate()
        {
            Delegate del;
            del = GetAverage;
            return del(list);
        }
    }
}
