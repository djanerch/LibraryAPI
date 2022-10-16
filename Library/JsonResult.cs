using Library.Api.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Library.Api
{
    public class JsonResult
    {
        private int allPages;
        private int taked = 10;
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public IEnumerable Results { get; set; }

        public void BuildProfiles(List<AllProfileInfo> list, int page)
        {
            Build(list, page);

            Results = list.Skip((page - 1) * taked).Take(taked);
        }

        private void Build(IList list, int page)
        {
            allPages = (int)Math.Ceiling((decimal)list.Count / taked);

            if (page > allPages || page < 1)
            {
                return;
            }

            Count = list.Count;

            if (page < allPages)
            {
                Next = $"https://localhost:5001/api/allprofiles?page={(page + 1)}";
            }

            if (page > 1)
            {
                Previous = $"https://localhost:5001/api/allprofiles?page={(page - 1)}";
            }
        }
    }
}