using Model.EF;
using Model.ModelCustom;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CountConnectDao
    {
        DBCONTENT db = null;
        public CountConnectDao()
        {
            db = new DBCONTENT();
        }
        public void addData(DateTime date,string check)
        {
            var newdate = new DateTime(date.Year, date.Month, date.Day);
            if (db.CountConnects.Where(x => x.dateConnect == newdate).Count() > 0)
            {
                var countConnect = db.CountConnects.Find(newdate);
                if (check == "add")
                {
                    countConnect.countView += 1;
                }
                else
                {
                    countConnect.countView -= 1;
                }
                
                db.SaveChanges();
            }
            else
            {
                var countConnect = new CountConnect();
                countConnect.dateConnect = date;
                countConnect.countView = 1;
                db.CountConnects.Add(countConnect);
                db.SaveChanges();
            }
        }
        public bool deleteData(DateTime date)
        {
            try
            {
                var list = db.CountConnects.Where(x => x.dateConnect <= date).ToList();
                foreach (var item in list)
                {
                    var countConnect = db.CountConnects.Find(item.dateConnect);
                    db.CountConnects.Remove(countConnect);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<CountConnect> listAll()
        {
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            deleteData(date.AddDays(-10));
            var list = db.CountConnects.Where(x => x.dateConnect != null).ToList();
            var countConnect = new CountConnect();
            if (list.Count < 10)
            {
                if (list == null)
                {
                    for (int i = 9; i >= 0; i--)
                    {
                        countConnect.dateConnect = date.AddDays(-i);
                        countConnect.countView = 0;
                        db.CountConnects.Add(countConnect);
                        db.SaveChanges();
                    }
                    list = db.CountConnects.Where(x => x.dateConnect != null).OrderBy(x => x.dateConnect).ToList();
                }
                else
                {
                    List<DateTime> dateInList = new List<DateTime>();
                    for (int i = 9; i >= 0; i--)
                    {
                        dateInList.Add(date.AddDays(-i));
                    }
                    foreach (var item in list)
                    {
                        dateInList.Remove(item.dateConnect);
                    }
                    for (int i = 0; i < dateInList.Count; i++)
                    {
                        using (DBCONTENT db = new DBCONTENT())
                        {
                            var dao = new CountConnect();
                            dao.dateConnect = dateInList[i];
                            dao.countView = 0;
                            db.CountConnects.Add(dao);
                            db.SaveChanges();
                        }
                    }

                    list = db.CountConnects.Where(x => x.dateConnect != null).OrderBy(x => x.dateConnect).ToList();
                }
            }
            return list;
        }
        public string ConvertToJSON(IEnumerable<UserCharts> list)
        {
            return JsonConvert.SerializeObject(list);
        }
    }
}
