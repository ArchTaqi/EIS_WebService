using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    //Select * from [dbo].[TblNotification] where SubcriptionId=(Select SubscriptionId from TblSubscription where [IsActive] = 1 and [UserId]='12' and Constid = 4)
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        String conid;
        String connStr = "Data Source=MUHAMMADTAQI;Initial Catalog=ECII(Old);Persist Security Info=True;User ID=sa;Password=finally";
       
        public confilter[] getconfilter(String condetail)
        {
            SqlConnection dbConnsearch = new SqlConnection(connStr);
            dbConnsearch.Open();
           
            string querrycon = " Select * FROM TblConstituency where code='" + condetail + "'";

            SqlDataAdapter da = new SqlDataAdapter(querrycon, dbConnsearch);
            DataTable dt = new DataTable();
            SqlCommand dbCommand = new SqlCommand(querrycon, dbConnsearch);
            dbCommand.CommandType = CommandType.Text;
            da.Fill(dt);
            List<int> canlist = new List<int>();
            List<confilter> listcan = new List<confilter>();
            confilter target = new confilter();
            foreach (DataRow row in dt.Rows)
            {
                
                target.conid = row["ConstID"].ToString();
                target.conname = row["Name"].ToString();
                target.concode = row["Code"].ToString();
                target.conpopulace =  row["Populace"].ToString();
                target.confemalevoter = row["FemaleVoters"].ToString();
                target.conmalevoter = row["MaleVoters"].ToString();
               
                
            }
            dt.Clear();

            string querrycan = "SELECT TblUserConstituency.UserId  FROM TblConstituency INNER JOIN TblUserConstituency ON TblConstituency.ConstID = TblUserConstituency.ConstID where TblConstituency.ConstID =" + target.conid;
            //target.conname = querrycan;
            dbCommand.CommandText = querrycan;
            SqlDataAdapter da1 = new SqlDataAdapter(querrycan, dbConnsearch);
            da1.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {

                canlist.Add(int.Parse(row["UserId"].ToString()));
            }

            target.canlist = new List<candidate>();

            foreach (int i in canlist)
            {
                dt.Clear();
                querrycan = "SELECT TblUserDetails.FirstName+LastName as name, TblUserDetails.AvatarFilePath, TblParty.PartyName FROM TblParty INNER JOIN TblUserParty ON TblParty.PartyId = TblUserParty.PartyID INNER JOIN TblUserDetails ON TblUserParty.UserID = TblUserDetails.UserId where TblUserDetails.UserId ="+i;
                dbCommand.CommandText = querrycan;
                SqlDataAdapter da2 = new SqlDataAdapter(querrycan, dbConnsearch);
                da2.Fill(dt);
                candidate cc = new candidate();
                foreach (DataRow row in dt.Rows)
                {

                    cc.UserId = i.ToString();
                    cc.canname = row["name"].ToString();
                    cc.canparty = row["PartyName"].ToString();
                    cc.canpic = row["AvatarFilePath"].ToString();
                }

                target.canlist.Add(cc);

            }

            listcan.Add(target);

            return listcan.ToArray();



        }


       public candidate[] getcandidateetail(String candidateetail)
        {
            SqlConnection dbConnsearch = new SqlConnection(connStr);
            dbConnsearch.Open();

            string querrycon = "select TblUserDetails.UserId ,TblUserDetails.FirstName+LastName as name, TblUserDetails.AvatarFilePath, TblParty.PartyName FROM TblParty INNER JOIN TblUserParty ON TblParty.PartyId = TblUserParty.PartyID INNER JOIN TblUserDetails ON TblUserParty.UserID = TblUserDetails.UserId where FirstName+LastName like'%" + candidateetail + "%'";

            SqlDataAdapter da = new SqlDataAdapter(querrycon, dbConnsearch);
            DataTable dt = new DataTable();
            SqlCommand dbCommand = new SqlCommand(querrycon, dbConnsearch);
            dbCommand.CommandType = CommandType.Text;
            da.Fill(dt);
            List<candidate> listcan = new List<candidate>();
            
            foreach (DataRow row in dt.Rows)
            {

candidate cc = new candidate();
            cc.UserId = row["UserId"].ToString();
                cc.canname = row["name"].ToString();
                cc.canparty = row["PartyName"].ToString();
                cc.canpic = row["AvatarFilePath"].ToString();

                listcan.Add(cc);
            }

            return listcan.ToArray();



        }

        public Constituency[] getConstituency(String name)
        {
            
            SqlConnection dbConn = new SqlConnection(connStr);
            dbConn.Open();
            string sqlSelect = "";
          
                sqlSelect = " select Code,Name FROM TblConstituency WHERE Category='"+name+"'";
       
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, dbConn);
            DataTable dt = new DataTable();
            SqlCommand dbCommand = new SqlCommand(sqlSelect, dbConn);
            da.Fill(dt);
            dbConn.Close();
            List<Constituency> list = new List<Constituency>();
            foreach (DataRow row in dt.Rows)
            {
                Constituency target = new Constituency();
                target.conname = row["Name"].ToString();
                target.connumb = row["Code"].ToString();
                list.Add(target);
            }
         return list.ToArray();
            

        }

        public Notification[] getnotification(String candidatename,String conid)
        {
            SqlConnection dbConn = new SqlConnection(connStr);
            dbConn.Open();
            string sqlSelect = "";

            sqlSelect = "Select * from [dbo].[TblNotification] where [SubcriptionId]=(Select [SubscriptionId] from [dbo].[TblSubscription] where [IsActive] = 1 and [UserId]=" + candidatename +"and Constid="+conid+ ")";

            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, dbConn);
            DataTable dt = new DataTable();
            SqlCommand dbCommand = new SqlCommand(sqlSelect, dbConn);
            da.Fill(dt);
            dbConn.Close();
            List<Notification> list = new List<Notification>();
            foreach (DataRow row in dt.Rows)
            {
                Notification target = new Notification();
                target.NotificationText = row["Body"].ToString();
                target.CreatedBy = row["PostedBy"].ToString();
                target.CreatedOn = row["PostedOn"].ToString();
                target.countlikes = row["Likes"].ToString();

                list.Add(target);
            }
              return list.ToArray();
        }

        public videos[] getvideos(String candidatid, String conid)
        {
            SqlConnection dbConn = new SqlConnection(connStr);
            dbConn.Open();
            string sqlSelect = "";

            sqlSelect = "Select * from [dbo].[TblVideos] where [SubcriptionId]=(Select [SubscriptionId] from [dbo].[TblSubscription] where [IsActive] = 1 and [UserId]="+candidatid+"and Constid="+conid+"and Constid="+conid+")";

            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, dbConn);
            DataTable dt = new DataTable();
            SqlCommand dbCommand = new SqlCommand(sqlSelect, dbConn);
            da.Fill(dt);
            dbConn.Close();
            List<videos> list = new List<videos>();
            foreach (DataRow row in dt.Rows)
            {
                videos target = new videos();
                target.VideoTitle = row["Title"].ToString();
                target.VideoLink = row["Url"].ToString();
                target.Category=row["Category"].ToString();
                target.Details = row["Details"].ToString();
                target.CreatedOn = row["PublishedOn"].ToString();
                target.likes = row["countlikes"].ToString();

                list.Add(target);
            }
            return list.ToArray();
        }



        public events [] getevents(String candidateid,String conid)
        {
            SqlConnection dbConn = new SqlConnection(connStr);
            dbConn.Open();
            string sqlSelect = "";

            sqlSelect = "Select * from [dbo].[TblEvent] where [SubcriptionId]=(Select [SubscriptionId] from [dbo].[TblSubscription] where [IsActive] = 1 and [UserId]=" + candidateid + "and Constid=" + conid + ")";

            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, dbConn);
            DataTable dt = new DataTable();
            SqlCommand dbCommand = new SqlCommand(sqlSelect, dbConn);
            da.Fill(dt);
            dbConn.Close();
            List<events> list = new List<events>();
            foreach (DataRow row in dt.Rows)
            {
                events target = new events();
                target.EventId = row["EventId"].ToString();
                target.EventTitle = row["Title"].ToString();
                target.EventDescription = row["Details"].ToString();
                target.Eventimg = row["Bannerurl"].ToString();
                target.countlikes = row["Likes"].ToString();
                target.Eventtiming = row["Publishedon"].ToString();
                target.Eventstartdate = row["Startdate"].ToString();
                target.Eventenddate = row["Enddate"].ToString();
                target.Eventstarttime = row["Starttime"].ToString();
                target.Eventendtime = row["Endtime"].ToString();
                target.Venue = row["Venue"].ToString();
                target.City = row["City"].ToString();
                target.Contact = row["Contact"].ToString();
                list.Add(target);
            }
            return list.ToArray();
        }



        public article[] getarticle(String candidateid,String conid)
        {
            SqlConnection dbConn = new SqlConnection(connStr);
            dbConn.Open();
            string sqlSelect = "";

            sqlSelect = "Select * from [dbo].[TblArticles]  where [SubcriptionId]=(Select [SubscriptionId] from [dbo].[TblSubscription] where [IsActive] = 1 and [UserId]=" + candidateid + "and Constid=" + conid + ")";

            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, dbConn);
            DataTable dt = new DataTable();
            SqlCommand dbCommand = new SqlCommand(sqlSelect, dbConn);
            da.Fill(dt);
            dbConn.Close();
            List<article> list = new List<article>();
            foreach (DataRow row in dt.Rows)
            {
                article target = new article();
                target.ArticlesId = row["ArticleID"].ToString();
                target.ArticleTitle = row["Title"].ToString();
                target.CreatedOn = row["PublishedOn"].ToString();
               // target.CreatedBy = row["CreatedBy"].ToString();
                target.countlikes = row["countlikes"].ToString();
                target.Articlledetails = row["Body"].ToString();
                target.ArticleAuthor = row["Author"].ToString();
                target.Articlecatagory = row["Categories"].ToString();
                list.Add(target);
            }
            return list.ToArray();
        }


        public candetails[] getdetails(String canid)
        {
            SqlConnection dbConn = new SqlConnection(connStr);
            dbConn.Open();
            string sqlSelect = "";

            sqlSelect = "Select [FirstName],[LastName],[FatherName],[DateofBirth],[OfficeAddress],[City],[Proivnce],[WorkPhone] from [dbo].[TblUserDetails] where [UserId]=" + canid + "";

            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, dbConn);
            DataTable dt = new DataTable();
            SqlCommand dbCommand = new SqlCommand(sqlSelect, dbConn);
            da.Fill(dt);
            dbConn.Close();
            List<candetails> list = new List<candetails>();
            foreach (DataRow row in dt.Rows)
            {
                candetails target = new candetails();
                target.FirstName = row["FirstName"].ToString();
                target.LastName = row["LastName"].ToString();
                target.Proivnce = row["Proivnce"].ToString();
                target.WorkPhone = row["WorkPhone"].ToString();
                target.OfficeAddress = row["OfficeAddress"].ToString();
                target.FatherName = row["FatherName"].ToString();
                target.City = row["City"].ToString();
                target.DateofBirth=row["DateofBirth"].ToString();
                list.Add(target);
            }
            return list.ToArray();
        }



      //  Select [FirstName],[LastName],[FatherName],[DateofBirth],[OfficeAddress],[City],[Proivnce],[WorkPhone] from [dbo].[TblUserDetails] where [UserId]='12'



    }


}
