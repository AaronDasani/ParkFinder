using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using ParkFinder.Models;
using Microsoft.Extensions.Options;
 
namespace ParkFinder.Factory
{
    public class TrailFactory
    {
        private MySqlOptions _options;
        public TrailFactory(IOptions<MySqlOptions> config)
        {
            _options = config.Value;
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(_options.ConnectionString);
            }
        }


        public void AddTrail(Trail trail)
        {
            using(IDbConnection dbConnection =Connection)
            {
                string query="INSERT INTO trails(name,description,elevation,trailLength,longtitude,latitude,created_at,updated_at) VALUES (@name,@description,@elevation,@trailLength,@longtitude,@latitude,NOW(),NOW())";

                dbConnection.Open();
                dbConnection.Execute(query,trail);
            }
        }
        public List<Trail> FindAllTrail(){
            using(IDbConnection dbConnection = Connection)
            {
                string query="SELECT * FROM trails";
                dbConnection.Open();
                return dbConnection.Query<Trail>(query).ToList();
            }
        }

        public Trail FindById(int trailId){

            using (IDbConnection dbConnection = Connection)
            {
                string query="SELECT * FROM trails WHERE id=@ID";
                var data = new {ID=trailId};

                dbConnection.Open();
                var result = dbConnection.Query<Trail>(query,data);
                return result.FirstOrDefault();
            }
        }

    }
}