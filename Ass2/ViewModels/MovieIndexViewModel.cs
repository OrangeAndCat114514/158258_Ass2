using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ass2.Models;
using PagedList;

namespace Ass2.ViewModels
{
    public class MovieIndexViewModel
    {
      //  public IQueryable<Movie> Movies { get; set; }
      public IPagedList<Movie> Movies {  get; set; }
        public string Search { get; set; }
        public IEnumerable<CategoryWithCount> CatsWithCount { get; set; }
        public string MovieCategory { get; set; }
        public string SortBy { get; internal set; }
        public Dictionary<string, string> Sorts { get; set; }


        public IEnumerable<SelectListItem> CatFilterItems
        {
            get
            {
                var allCats = CatsWithCount.Select(cc => new SelectListItem
                {
                    Value = cc.MovieCategoryName,
                    Text = cc.CatNameWithCount
                });
                return allCats;
            }
        }
        
    }
    public class CategoryWithCount
    {
        public int MovieCount { get; set; }
        public string MovieCategoryName { get; set; }
        public string CatNameWithCount
        {
            get
            {
                return MovieCategoryName + " (" +
                MovieCount.ToString() + ")";
            }
        }
    }
}