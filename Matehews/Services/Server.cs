using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace Services
{
    public class Server
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        SqlDataAdapter Adapter;
        SqlDataReader Reader;

        public Server()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=MatehNews;Integrated Security=True");
            Open();
        }

        public void Open()
        {
            if (Conn.State == ConnectionState.Closed)
                Conn.Open();
        }
        public bool InsertOrUpdate(string spName, List<DbParameter> DBparameters)
        {
            SqlParameter[] parameters = new SqlParameter[DBparameters.Count];
            for (int i = 0; i < DBparameters.Count; i++)
            {
                parameters[i] = DBparameters[i].ToSql;
            }
            try
            {

                Cmd = new SqlCommand(spName, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddRange(parameters);
                Cmd.ExecuteNonQuery();
                bool x = true;
                /*
                if (Cmd.Parameters.Contains("@Msg"))
                {
                     var res = Cmd.Parameters["@Msg"].Value.ToString();
                     x = (res[0] == '|') ? true : false;

                    if (res != "x")
                    {
                        var Icon = (res[0] == '|') ? MsgIcon.Ready : MsgIcon.Error;
                        Box.Show(res, "Ready", MsgButton.OK, Icon);
                    }
                }
                else Box.Show("OkBik", "Ready");
                */
                Conn.Close();
                return x;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Mi error: " + ex.ToString());

                return false;
            }

        }

        public DataTable Query(string spName, List<DbParameter> DBparameters)
        {
            DataTable dt = new DataTable();
            var parameters = new SqlParameter[1];
            if (DBparameters != null)
            {
                parameters = new SqlParameter[DBparameters.Count];
                for (int i = 0; i < DBparameters.Count; i++)
                {
                    parameters[i] = DBparameters[i].ToSql;
                }
            }

            try
            {

                Cmd = new SqlCommand(spName, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                if (DBparameters != null)
                    Cmd.Parameters.AddRange(parameters);
                Adapter = new SqlDataAdapter();
                Adapter.SelectCommand = Cmd;
                Adapter.Fill(dt);
                //var res = Cmd.Parameters["@Msg"].Value.ToString();
                // Box.Show(res, "Ready", MsgButton.OK, MsgIcon.Warning);
                return dt;
            }
            catch (Exception ex)
            {

                //  Box.Show(ex.ToString(), "Error", MsgButton.Retry, MsgIcon.Error);
                return dt;
            }
        }

        public SqlDataReader QueryList(string spName, List<DbParameter> DBparameters)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            bool HayParams = false;
            if (DBparameters != null)
            {
                parameters = new SqlParameter[DBparameters.Count];
                for (int i = 0; i < DBparameters.Count; i++)
                {
                    parameters[i] = DBparameters[i].ToSql;
                }
                HayParams = true;
            }

            try
            {

                Cmd = new SqlCommand(spName, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;

                if (HayParams)
                    Cmd.Parameters.AddRange(parameters);

                Reader = Cmd.ExecuteReader();
                var x = Reader;
                return x;
            }
            catch (Exception ex)
            {
                // Box.Show(ex.ToString(), "Error", MsgButton.Retry, MsgIcon.Error);
                return null;
            }
        }

        public void Close()
        {
            if (Conn.State == ConnectionState.Open)
                Conn.Close();
        }
    }
}