using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionDB.Extensions
{
    public static class KindExtensions
    {
        public static IQueryable<Kind> Search(this IQueryable<Kind> kinds, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return kinds;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return kinds.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));

            
        }
    }
}
