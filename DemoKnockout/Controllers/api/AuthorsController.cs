using DemoKnockout.DAL;
using DemoKnockout.Models;
using DemoKnockout.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using DemoKnockout.Extenssions;

namespace DemoKnockout.Controllers.api
{
    public class AuthorsController : ApiController
    {
        private BookContext db = new BookContext();

        // GET api/<controller>
        public ResultList<AuthorViewModel> Get([FromUri]QueryOptions queryOptions)
        {
            var start = (queryOptions.CurrentPage - 1) * queryOptions.PageSize;

            var authors = db.Authors.OrderBy(queryOptions.Sort).Skip(start).Take(queryOptions.PageSize);
            queryOptions.TotalPages = (int)Math.Ceiling((double)db.Authors.Count() / queryOptions.PageSize);

           
            Mapper.CreateMap<Author, AuthorViewModel>();
            return new ResultList<AuthorViewModel>
            {
                QueryOptions = queryOptions,  Results = Mapper.Map<List<Author>, List<AuthorViewModel>>(authors.ToList())
            };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}