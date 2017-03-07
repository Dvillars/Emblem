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

        public void AddUnit(Unit newUnit)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO players_units (players_id, units_id) VALUES (@PlayersId, @UnitId);", conn);

            cmd.Parameters.Add(new SqlParameter("@UnitId", newUnit.GetUnitId()));
            cmd.Parameters.Add(new SqlParameter("@PlayersId", this.GetId()));

            cmd.ExecuteNonQuery();

            if (conn != null)
            {
                conn.Close();
            }
        }

        public List<Unit> GetUnits()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT units_id FROM players_units WHERE players_id = @PlayersId;", conn);

            cmd.Parameters.Add(new SqlParameter("@PlayersId", this.GetId()));


            SqlDataReader rdr = cmd.ExecuteReader();

            List<int> unitIds = new List<int> {};

            while (rdr.Read())
            {
                int unitId = rdr.GetInt32(0);
                unitIds.Add(unitId);
            }
            if (rdr != null)
            {
                rdr.Close();
            }


            List<Unit> units = new List<Unit> {};

            foreach (int unitId in unitIds)
            {
                SqlCommand unitQuery = new SqlCommand("SELECT * FROM units WHERE id = @UnitId;", conn);

                unitQuery.Parameters.Add(new SqlParameter("@UnitId", unitId));

                SqlDataReader queryReader = unitQuery.ExecuteReader();

                while (queryReader.Read())
                {
                    string unitName = queryReader.GetString(1);
                    string unitType = queryReader.GetString(2);
                    int weaponId = queryReader.GetInt32(3);
                    int hp = queryReader.GetInt32(4);
                    int str = queryReader.GetInt32(5);
                    int skl = queryReader.GetInt32(6);
                    int spd = queryReader.GetInt32(7);
                    int lck = queryReader.GetInt32(8);
                    int def = queryReader.GetInt32(9);
                    int res = queryReader.GetInt32(10);
                    int id = queryReader.GetInt32(0);
                    Unit newUnit = new Unit(unitName, unitType, weaponId, hp, str, skl, spd, lck, def, res, id);
                    units.Add(newUnit);
                }
                if (queryReader != null)
                {
                    queryReader.Close();
                }
            }
            if (conn != null)
            {
                conn.Close();
            }
            return units;
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
