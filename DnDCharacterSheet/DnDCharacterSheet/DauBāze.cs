using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing;
using System.Data.SqlTypes;

namespace DnDCharacterSheet
{

    internal class DatuBāze
    {
        private static DatuBāze db = null;
        
        public static DatuBāze DabūtDbInstanci
        {
            get
            {
                if (db == null)
                {
                     db=  new DatuBāze("Data Source=pizza.db");
                }
                return db;
            }
        }

        private readonly string connectionString;
        private DatuBāze(string connectionString)
        {
            this.connectionString = connectionString;

            CreateUserTable();
            CreateDNDDataTable();
        }

        public void CreateUserTable()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var createTableCommand = connection.CreateCommand();
                createTableCommand.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL,
                        IsAdmin BOOLEAN
                    ) 
                ";

                createTableCommand.ExecuteNonQuery();
                connection.Close();
            }
        }
        public List<DNDListRow> NolasītDNDSarakstu(int UserId)
        {

            List<DNDListRow> rez =new List<DNDListRow>();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var createTableCommand = connection.CreateCommand();

                var sql = @"
                    SELECT  
                        autors.Username,
                        DNDData.ID,
                        DNDData.EditDate,
                        DNDData.Name,
                        DNDData.CharacterRace
                    FROM 
                        Users autors
                        inner join DNDData on DNDData.UserId=autors.Id
                        left join Users admins on admins.Id=@UserId and admins.IsAdmin=1
                    where autors.Id=@UserId or admins.IsAdmin=1
                    order by 
                        autors.Username,
                        DNDData.Name, 
                        DNDData.EditDate;
                ";
             

                createTableCommand.CommandText = sql;
                createTableCommand.Parameters.AddWithValue("@UserId", UserId);

                var sqlRindinas = createTableCommand.ExecuteReader();
                while (sqlRindinas.Read())
                {
                   var rinda = new DNDListRow();
                    rinda.Id = (int)sqlRindinas["Id"];
                    rinda.UserName = (string)sqlRindinas["UserName"];
                    rinda.Name = (string)sqlRindinas["Name"];
                    rinda.CharacterRace = (string)sqlRindinas["CharacterRace"];
                    rinda.EditDate = ((DateTime)sqlRindinas["EditDate"]).ToString();
                    rez.Add(rinda);
                }
                connection.Close();
            }

            return rez;
        }

        public DNDModelForBinding NolasītDNDIerakstu(int? Id)
        {

            DNDModelForBinding rez = null; 


            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var createTableCommand = connection.CreateCommand();

                var sql = new StringBuilder();
                sql.Append(@"
                    SELECT  
                        Users.Username,
                        DNDData.ID,
                        DNDData.EditDate,
                        DNDData.Name,
                        DNDData.CharacterRace
");


                var datuKlasesTips = typeof(DNDModel);
                foreach (var p in datuKlasesTips.GetProperties())
                {
                    //Var rakstīt un ir definēta DNDModel klasē
                    if (p.CanWrite && p.DeclaringType == datuKlasesTips)
                    {
                        if (
                            p.PropertyType == typeof(string) ||                            
                            p.PropertyType == typeof(int) ||
                            p.PropertyType == typeof(bool) 
                            )
                        {
                            sql.AppendFormat(",\r\n    DNDData.{0}", p.Name);
                        }                        
                    }

                }
                sql.Append(@"
                    FROM Users inner join DNDData on DNDData.UserId=Users.Id
                    where DNDData.ID=@DND_ID
                    ");
                 
                createTableCommand.CommandText = sql.ToString();
                createTableCommand.Parameters.AddWithValue("@DND_ID", Id);

                var sqlRindina=createTableCommand.ExecuteReader();
                while (sqlRindina.Read()) {
                    rez = new DNDModelForBinding();
                    foreach (var p in datuKlasesTips.GetProperties())
                    {
                        //Var rakstīt un ir definēta DNDModel klasē
                        if (p.CanWrite)
                        {
                            if ( p.PropertyType == typeof(string)  )
                            {
                                string str;
                                if (sqlRindina[p.Name] == DBNull.Value)
                                {
                                    str = null;
                                } else
                                {
                                   str= (string)sqlRindina[p.Name]; 
                                }
                                p.SetValue(rez, str);

                            } else  if ( p.PropertyType == typeof(int) )
                            {
                                int sk;
                                if (sqlRindina[p.Name] == DBNull.Value)
                                {
                                    sk = 0;
                                }
                                else
                                {
                                    sk = (int)sqlRindina[p.Name];
                                }
                                p.SetValue(rez, sk);

                                
                            }
                            else if (p.PropertyType == typeof(bool))
                            {
                                bool b;
                                if (sqlRindina[p.Name] == DBNull.Value)
                                {
                                    b = false;
                                }
                                else
                                {
                                    b = (bool)sqlRindina[p.Name];
                                }
                                p.SetValue(rez, b);

                            }
                            else if ( p.PropertyType == typeof(DateTime))
                            {
                                DateTime? dat;
                                if (sqlRindina[p.Name] == DBNull.Value)
                                {
                                    dat = null;
                                }
                                else
                                {
                                   dat = (DateTime)sqlRindina[p.Name];
                                }
                                p.SetValue(rez, dat);
                            }
                        }

                    }

                }
                connection.Close();
            }

            return rez;
        }

        public void SaglabātDNDIerakstu(int? UserId, DNDModel modelis)
        {
            

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var createTableCommand = connection.CreateCommand();

                var sqlKolonas = new StringBuilder();
                var sqlMainigie = new StringBuilder();

                // Id,  UserId, Name, CharacterRace, EditDate
                sqlKolonas.Append(modelis.Id==0? "UserId, Name, CharacterRace, EditDate":" Id,  UserId, Name, CharacterRace, EditDate");
                sqlMainigie.Append(modelis.Id == 0 ? "@UserId, @Name, @CharacterRace, @EditDate" : " @Id,  @UserId, @Name, @CharacterRace, @EditDate");
                if (modelis.Id != 0) {
                    createTableCommand.Parameters.AddWithValue("@Id", modelis.Id);
                }
                createTableCommand.Parameters.AddWithValue("@UserId", UserId == null ? DBNull.Value : UserId.Value);
                createTableCommand.Parameters.AddWithValue("@Name", modelis.Name==null?DBNull.Value: modelis.Name);
                createTableCommand.Parameters.AddWithValue("@CharacterRace", modelis.CharacterRace == null ? DBNull.Value : modelis.CharacterRace);
                createTableCommand.Parameters.AddWithValue("@EditDate",DateTime.Now);
                


                var datuKlasesTips = typeof(DNDModel);
                foreach (var p in datuKlasesTips.GetProperties())
                {
                    //Var rakstīt un ir definēta DNDModel klasē
                    if (p.CanWrite && p.DeclaringType == datuKlasesTips)
                    {
                        if (
                            p.PropertyType == typeof(string) ||
                            p.PropertyType == typeof(int) ||
                            p.PropertyType == typeof(bool)
                            )
                        {
                            sqlKolonas.AppendFormat(", {0}", p.Name);
                            sqlMainigie.AppendFormat(", @{0}", p.Name);
                            if (p.PropertyType == typeof(string) && p.GetValue(modelis)==null)
                            {
                                createTableCommand.Parameters.AddWithValue("@" + p.Name,  DBNull.Value);
                            }
                            else
                            {
                                createTableCommand.Parameters.AddWithValue("@" + p.Name, p.GetValue(modelis));
                            }
                              
                        }
                    }

                }
               var  sql= string.Format("INSERT OR REPLACE INTO DNDData({0}) VALUES({1}); ", sqlKolonas.ToString(), sqlMainigie,ToString());

                createTableCommand.CommandText = sql;
                

                 createTableCommand.ExecuteNonQuery();
                connection.Close();
            }
             
        }
        public void DzēstDNDIerakstu(int id)
        {


            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var createTableCommand = connection.CreateCommand();

                  
                createTableCommand.CommandText = "Delete from DNDData where ID=@id; ";
                createTableCommand.Parameters.AddWithValue("@id",id);
                createTableCommand.ExecuteNonQuery();
                connection.Close();
            }

        }

        public void CreateDNDDataTable()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var createTableCommand = connection.CreateCommand();

               
                var sql = new StringBuilder();
                sql.Append(@"
                    CREATE TABLE IF NOT EXISTS DNDData (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserId INTEGER NOT NULL,

                        Name varchar(200) Not null,
                        CharacterRace varchar(200) Not null,
                        EditDate datetime Not null
");


                var datuKlasesTips = typeof(DNDModel); 
                foreach( var p in datuKlasesTips.GetProperties())
                {
                    //Var rakstīt un ir definēta DNDModel klasē
                    if (p.CanWrite && p.DeclaringType== datuKlasesTips)
                    {
                        if (p.PropertyType == typeof(string))
                        {
                            sql.AppendFormat(",\r\n    {0} varchar(200)", p.Name);
                        } else if (p.PropertyType == typeof(int))
                        {
                            sql.AppendFormat(",\r\n    {0} int", p.Name);
                        }
                        else if (p.PropertyType == typeof(bool))
                        {
                            sql.AppendFormat(",\r\n    {0} bit", p.Name);
                        }
                    }

                }
                sql.Append(")");

                createTableCommand.CommandText =  sql.ToString();              

                createTableCommand.ExecuteNonQuery();
                connection.Close();
            }
        }






        public void CreateUser(string username, string password, bool isAdmin)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var createUserCommand = connection.CreateCommand();
                createUserCommand.CommandText = @"
                    INSERT INTO Users(Username, Password, IsAdmin)
                    VALUES (@username, @password, @isAdmin)
                ";

                createUserCommand.Parameters.AddWithValue("username", username);
                createUserCommand.Parameters.AddWithValue("password", password);
                createUserCommand.Parameters.AddWithValue("isAdmin", isAdmin);

                createUserCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public (string, string, bool) GetUser(string username)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var selectUserCommand = connection.CreateCommand();
                selectUserCommand.CommandText = @"
                    SELECT Username, Password, IsAdmin FROM Users
                    WHERE Username = @username
                ";
                selectUserCommand.Parameters.AddWithValue("username", username);

                using (var reader = selectUserCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        connection.Close();
                        return (reader["Username"].ToString(), reader["Password"].ToString(), Convert.ToBoolean(reader["IsAdmin"]));
                    }
                }
                connection.Close();
                throw new Exception("User not found");
            }
        }


    }
}
