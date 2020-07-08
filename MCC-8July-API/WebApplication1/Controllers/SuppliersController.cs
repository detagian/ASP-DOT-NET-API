using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SuppliersController : ApiController
    {

        MyContext myContext = new MyContext();
        
        //get id
        [HttpGet]
        public Supplier Get(int id) 
        {
            return myContext.Suppliers.Find(id);
        }


        //get list all
        [HttpGet]
        public List<Supplier> Get()
        {
            return myContext.Suppliers.ToList();
        }


        //post supplier
        [HttpPost]
        public string Post(Supplier supplier)
        {
            if (supplier.Equals(null))
            {
                return "gagal";
            }
            else if (string.IsNullOrWhiteSpace(supplier.Id.ToString()) || string.IsNullOrWhiteSpace(supplier.Name))
            {
                return "gagall";

            }
            else
            {
                myContext.Suppliers.Add(supplier);
                myContext.SaveChanges();
                return "sukses";
            }

        }

        [HttpDelete]
        public string Delete(int id)
        {
            if (myContext.Suppliers.Find(id).Equals(null))
            {
                return "data is empty";
            }else
            {
                Supplier rmv_supplier = myContext.Suppliers.Where(x => x.Id == id).Single<Supplier>();
                myContext.Suppliers.Remove(rmv_supplier);
                myContext.SaveChanges();
                return "remove success";
            }
        }

        [HttpPut]

        public string Put(Supplier supplier)
        {
            MyContext SP = new MyContext();
            Supplier supp = myContext.Suppliers.Where(x => x.Id == supplier.Id).Single<Supplier>();
            supp.Id = supplier.Id;
            supp.Name = supplier.Name;
            supp.JoinDate = supplier.JoinDate;
            SP.Entry(supp).State = System.Data.Entity.EntityState.Modified;
            SP.SaveChanges();
            return "Update Success";
        }



    }
}
