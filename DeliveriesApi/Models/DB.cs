using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DeliveriesApi.Models
{
    public class DB
    {
        //entity framework usage - single item
        public TenderItem GetTenderItem(int iTenderID)
        {
            MyDB context = new MyDB();
            SqlParameter tenderID = new SqlParameter("@TenderID", iTenderID);

            object[] parameters = new object[] { tenderID };
            TenderItem oTender = context.Tender.SqlQuery("Tenders2017_GetTender @TenderID", parameters).Single();

            context.Dispose();
            context = null;
            return oTender;
        }

        //entity framework usage - multiple items
        internal List<Branch> GetBranches()
        {
            MyDB context = new MyDB();
            
            List<Branch> lst = context.Branches.SqlQuery("Tenders2017_GetBranches").ToList();

            context.Dispose();
            context = null;
            return lst;
        }

        //DAL usage
        internal DataTable GetAdvertisers()
        {
            DBManager oDal = new DBManager(DataProvider.SqlServer, ConfigurationManager.ConnectionStrings["MyDB"].ToString());

            //oDal.CreateParameters(1);
            //oDal.AddParameters(0, "@CompanyName", sCompanyName);

            oDal.Open();
            DataTable dt = oDal.ExecuteDataSet(CommandType.StoredProcedure, "Tenders2017_GetAdvertisers").Tables[0];
            oDal.Close();
            oDal.Dispose();
            oDal = null;

            return dt;
        }
    }
}