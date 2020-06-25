using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using haliSahaRezervasyon.Entity;

namespace haliSahaRezervasyon
{
    public class SqlCon
    {
       
        Context dbcontext = new Context();

        public void SahaEkle(string SahaIsim,string Adres,int Fiyat,int SahaKisi,bool SahaDurum)
        {
            Sahalar saha = new Sahalar();
            saha.SahaIsim = SahaIsim;
            saha.Adres = Adres;
            saha.Fiyat = Fiyat;
            saha.SahaKisi = SahaKisi;
            saha.SahaDurum = true;
            dbcontext.Sahalars.Add(saha);
            dbcontext.SaveChanges();


        }
        public void SahaDurumGuncelle(int SahaId,bool SahaDurum)
        {
            Sahalar saha = dbcontext.Sahalars.First(o => o.SahaId == SahaId);
            saha.SahaDurum = SahaDurum;
            dbcontext.SaveChanges();
        }
        
        public DataTable RezervasyonFiyatGetir()
        {
            string query = dbcontext.Sahalars.Select(o => new { o.Fiyat }).ToString();
            DataTable dataTable = this.DataTable(dbcontext, query);
            return dataTable;
        }
       
        public DataTable RezervasyonTablo()
        {
            string query = (
                from Rezervasyons in dbcontext.Rezervasyons
                join Sahalars in dbcontext.Sahalars on Rezervasyons.SahaId equals Sahalars.SahaId
                select new
                {
                    Sahalars.SahaIsim,
                    Rezervasyons.Tarih,
                    Rezervasyons.RezervasyonSaat,
                    Sahalars.SahaKisi,
                    Sahalars.Fiyat,
                    Sahalars.Adres,
                    FiyatDurumu = Rezervasyons.PayCheck
                }
                ).ToString();

            DataTable dataTable = this.DataTable(dbcontext, query);
            return dataTable;
        }
        public DataTable TabloyuGetir1(Boolean? SahaDurum)
        {
            string query = "";
            if (SahaDurum != null)
            {
                if (SahaDurum == true)
                {
                    query = dbcontext.Sahalars.Where(o => o.SahaDurum == true).ToString();
                }
                else
                {
                    query = dbcontext.Sahalars.Where(o => o.SahaDurum == false).ToString();
                }
            }
            else
            {
                query = dbcontext.Sahalars.ToString();
            }

            DataTable dataTable = this.DataTable(dbcontext, query);
            return dataTable;
        }
        public Boolean SaatTarihKontrol(int SahaId,string Tarih,string saat)
        {
            DateTime dateTime = Convert.ToDateTime(Tarih);
            Rezervasyon rezervasyon = dbcontext.Rezervasyons.Where(o => o.RezervasyonSaat == saat && o.Tarih == dateTime && o.SahaId == SahaId).FirstOrDefault();

            return (rezervasyon != null) ? true : false;
        }
        public Boolean PayCheckUpdate(string Tarih, string saat, int RSahaId, bool PayCheck)
        {
            DateTime tarih_date = Convert.ToDateTime(Tarih);
            Rezervasyon rezervasyons = dbcontext.Rezervasyons.First(o => o.SahaId == RSahaId && o.Tarih == tarih_date && o.RezervasyonSaat == saat);
            rezervasyons.PayCheck = PayCheck;
            dbcontext.SaveChanges();
            
            return true;
        }


        //LINQ SQL -> Datatable verisi alındığı yer
        public DataTable DataTable(DbContext context, string sqlQuery)
        {
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(context.Database.Connection);

            using (var cmd = dbFactory.CreateCommand())
            {
                cmd.Connection = context.Database.Connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlQuery;
                using (DbDataAdapter adapter = dbFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = cmd;

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;
                }
            }
        }
    }
}