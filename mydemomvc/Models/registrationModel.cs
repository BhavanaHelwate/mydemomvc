using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using mydemomvc.Data;
using WebGrease.Css.Ast;




namespace mydemomvc.Models
{
    public class registrationModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int srno { get; private set; }

        public string Savereg(registrationModel model)
        {
            string msg = "Save";

            mvcdemoEntities Db = new mvcdemoEntities();
            var reg = Db.tblregistrations.Where(p =>p.ID== model.ID).FirstOrDefault();
            if(model.ID==0)
            {

                var regData = new tblregistration()
                {
                    ID = model.ID,
                    Name = model.Name,
                    MobileNo = model.MobileNo,
                    City = model.City,
                    Address = model.Address,
                };
                Db.tblregistrations.Add(regData);
                Db.SaveChanges();
                
            }
            else
            {
                reg.ID = model.ID;
                reg.Name = model.Name;
                reg.MobileNo = model.MobileNo;
                reg.City = model.City;
                reg.Address = model.Address;
                
            Db.SaveChanges();
            msg = "update successfully!";

        }
        return msg;
    }
        public List<registrationModel> GetregistrationList()
        {
            mvcdemoEntities Db = new mvcdemoEntities();
            List<registrationModel> lstRegistration = new List<registrationModel>();
            var AddregistrationList = Db.tblregistrations.ToList();
            int srno = 1;
            if (AddregistrationList != null)
            {
                foreach (var registration in AddregistrationList)
                {
                    lstRegistration.Add(new registrationModel()
                    {
                        srno = srno,
                        ID = registration.ID,
                        Name = registration.Name,
                        MobileNo = registration.MobileNo,
                        City = registration.City,
                        Address = registration.Address,
                    });
                    srno++;
                }
            }
            return lstRegistration;
        }
        public string deleteregistration(int ID)
        {
            var msg = "Delete Successfull";
            mvcdemoEntities Db = new mvcdemoEntities();
            var data = Db.tblregistrations.Where(p => p.ID == ID).FirstOrDefault();
            if (data != null) 
            {
                Db.tblregistrations.Remove(data);
                Db.SaveChanges();

            }
            return msg;

        }
        public registrationModel getregistrationbyID(int ID)
        {
            registrationModel model = new registrationModel();
            mvcdemoEntities Db = new mvcdemoEntities();
            var data = Db.tblregistrations.Where(p => p.ID == ID).FirstOrDefault();
            if (data != null)
            {

                model.ID = data.ID;
                model.Name = data.Name;
                model.MobileNo = data.MobileNo;
                model.City = data.City;
                model.Address = data.Address;
            }
            return model;

        }
    }

}


 
