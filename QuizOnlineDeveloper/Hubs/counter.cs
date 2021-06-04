using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.SignalR;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace QuizOnlineDeveloper.Hubs
{
    public class counter : Hub
    {

        static long couter = 0;
        static DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public override Task OnConnected()
        {
            var dao = new CountConnectDao();
            dao.deleteData(date.AddDays(-10));
            dao.addData(date,"add");
            couter += 1; // add one when user connected 
            Clients.All.UpdateCount(couter); // call client method to update interface
            return base.OnConnected();
        }
        public override Task OnReconnected()
        {
            var dao = new CountConnectDao();
            dao.addData(date, "sub");
            couter -= 1; // add one when user connected 
            Clients.All.UpdateCount(couter); // call client method to update interface
            return base.OnReconnected();
        }
        
        public override Task OnDisconnected(bool stopCalled)
        {
            couter -= 1;
            Clients.All.UpdateCount(couter);
            return base.OnDisconnected(stopCalled);
        }
    }
}