using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace SigilOfFlame
{
    public class Player
    {
        private string _name;
        private int _id;

        public Player(string name, int id=0)
        {
            _name = name;
            _id = id;
        }
        public string GetName()
        {
            return _name;
        }
        public void SetName(string Name)
        {
            _name = Name;
        }
        public int GetId()
        {
            return _id;
        }


        public override bool Equals(System.Object otherPlayer)
        {
            if (!(otherPlayer is Player))
            {
                return false;
            }
            else
            {
                Player newPlayer = (Player) otherPlayer;
                bool nameEquality = this.GetName() == newPlayer.GetName();
                bool idEquality = this.GetId() == newPlayer.GetId();
                return (idEquality && nameEquality);
            }
        }

        public static List<Player> GetAll()
        {
            List<Player> allPlayers = new List<Player>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM players;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistName = rdr.GetString(1);
                Player newPlayer = new Player(stylistName, stylistId);
                allPlayers.Add(newPlayer);
            }


            DB.CloseSqlConnection(rdr, conn);

            return allPlayers;
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO players (name) OUTPUT INSERTED.id VALUES (@PlayerName);", conn);

            SqlParameter nameParameter = new SqlParameter();
            nameParameter.ParameterName = "@PlayerName";
            nameParameter.Value = this.GetName();

            cmd.Parameters.Add(nameParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }

            DB.CloseSqlConnection(rdr, conn);
        }

        public static Player Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM players WHERE id = @PlayerId;", conn);
            SqlParameter playerIdParameter = new SqlParameter();
            playerIdParameter.ParameterName = "@PlayerId";
            playerIdParameter.Value = id.ToString();
            cmd.Parameters.Add(playerIdParameter);
            SqlDataReader rdr = cmd.ExecuteReader();

            int foundPlayerId = 0;
            string foundPlayerName = null;

            while(rdr.Read())
            {
                foundPlayerId = rdr.GetInt32(0);
                foundPlayerName = rdr.GetString(1);
            }
            Player foundPlayer = new Player(foundPlayerName,  foundPlayerId);

            DB.CloseSqlConnection(rdr, conn);

            return foundPlayer;
        }

        // public void Delete()
        // {
        //   SqlConnection conn = DB.Connection();
        //   conn.Open();
        //
        //   SqlCommand cmd = new SqlCommand("DELETE FROM players WHERE id = @PlayerId; DELETE FROM categories_players WHERE player_id = @PlayerId;", conn);
        //   SqlParameter playerIdParameter = new SqlParameter();
        //   playerIdParameter.ParameterName = "@PlayerId";
        //   playerIdParameter.Value = this.GetId();
        //
        //   cmd.Parameters.Add(playerIdParameter);
        //   cmd.ExecuteNonQuery();
        //
        //   if (conn != null)
        //   {
        //     conn.Close();
        //   }
        // }

        public static void DeleteAll()
        {
            DB.TableDeleteAll("players");
        }
    }
}
