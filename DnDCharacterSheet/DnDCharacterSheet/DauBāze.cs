using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.ApplicationServices;

namespace DnDCharacterSheet
{

    internal class DauBāze
    {

        public static DauBāze DabūtDbInstanci()
        {
            return new DauBāze("Data Source=pizza.db");
        }

        private readonly string connectionString;
        private  DauBāze(string connectionString)
        {
            this.connectionString = connectionString;

            CreateUserTable();
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
            }
        }


        public DNDModel NolasītDNDIerakstu(int? Id)
        {

            var rez = new DNDModel(); 


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
                            sql.AppendFormat(",\r\n    DNDData.{0},", p.Name);
                        }                        
                    }

                }
                sql.Append(@"
                    FROM Users inner join DNDData on DNDData.UserId=Users.Id
                    where DNDData.ID=@DND_ID
                    ");
                 
                createTableCommand.CommandText = sql.ToString();
                createTableCommand.Parameters.Add("DND_ID", SqliteType.Integer).Value = Id;

                var sqlRindina=createTableCommand.ExecuteReader();
                while (sqlRindina.Read()) {

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
            }
            return rez;
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

                        Name varchar(max) Not null,
                        CharacterRace varchar(max) Not null,
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
                            sql.AppendFormat(",\r\n    {0} varchar(max),",p.Name);
                        } else if (p.PropertyType == typeof(int))
                        {
                            sql.AppendFormat(",\r\n    {0} int,", p.Name);
                        }
                        else if (p.PropertyType == typeof(bool))
                        {
                            sql.AppendFormat(",\r\n    {0} bit,", p.Name);
                        }
                    }

                }
                sql.Append(")");

                createTableCommand.CommandText =  sql.ToString();
               

                createTableCommand.ExecuteNonQuery();
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
                        return (reader["Username"].ToString(), reader["Password"].ToString(), Convert.ToBoolean(reader["IsAdmin"]));
                    }
                }

                throw new Exception("User not found");
            }
        }


    }
}
