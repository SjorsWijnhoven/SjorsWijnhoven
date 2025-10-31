using Database;
using MySql.Data.MySqlClient;
using ZstdSharp.Unsafe;

namespace StudieDashboardDatabase {
    public static class DBConnectionBridge {


        private static MySqlConnection MakeDBConnection() {
            string connectionString = "Server=localhost;Database=studie_dashboard;uid=root;Pwd=;";
            MySqlConnection connection = new(connectionString);
            connection.Open();
            return connection;
        }

        private static void CloseDBConnection(MySqlConnection connection) {
            connection.Dispose();
            connection.Close();
        }

        
        public static List<Cursus> GiveDataGridCorrectData(List<char> cursusStatussen, List<string> cursusRichtingen, bool isSorted, string sortedBy, bool geavanceerd) {
            MySqlCommand command;

            using (MySqlConnection connection = MakeDBConnection()) {
                if (geavanceerd) {
                    command = GetDataFromDB_Geavanceerd(connection, cursusStatussen, cursusRichtingen, isSorted, sortedBy);
                } else {
                    command = GetDataFromDB_Normaal(connection, cursusStatussen, isSorted, sortedBy);
                }

                using (MySqlDataReader reader = command.ExecuteReader()) {

                    List<Cursus> cursusData = [];
                    while(reader.Read()) {
                        Cursus cursus = new(reader.GetString("code"), reader.GetString("naam"), reader.GetInt32("punten"), reader.GetString("categorie"), reader.GetChar("status"));
                        cursusData.Add(cursus);
                    }

                    CloseDBConnection(connection);
                    return cursusData;
                }
            }
        }

        private static MySqlCommand GetDataFromDB_Normaal(MySqlConnection connection, List<char> cursusStatussen, bool isSorted, string sortedBy) {
            string query = QueryBuilder.BuildCursusDataQuery(isSorted);

            using (MySqlCommand command = new(query, connection)) {

                command.Parameters.Add(new MySqlParameter("@cursusStatus", MySqlDbType.Enum) { Value = cursusStatussen[0] });
                command.Parameters.Add(new MySqlParameter("@sortedBy", MySqlDbType.VarChar) { Value = sortedBy });

                return command;
            }
        }

        private static MySqlCommand GetDataFromDB_Geavanceerd(MySqlConnection connection, List<char> cursusStatussen, List<string> cursusRichtingen, bool isSorted, string sortedBy) {
            string query = QueryBuilder.BuildGeavanceerdeInstellingenQuery(isSorted, cursusStatussen, cursusRichtingen);

            using (MySqlCommand command = new(query, connection)) {

                for (int i = 0; i < cursusStatussen.Count; i++)
                    command.Parameters.Add(new MySqlParameter("cursusStatus" + i.ToString(), MySqlDbType.Enum) { Value = cursusStatussen[i] });
                for (int i = 0; i < cursusRichtingen.Count; i++)
                    command.Parameters.Add(new MySqlParameter("cursusRichting" + i.ToString(), MySqlDbType.VarChar) { Value = cursusRichtingen[i] });
                command.Parameters.Add(new MySqlParameter("@sortedBy", MySqlDbType.VarChar) { Value = sortedBy });

                return command;
            }
        }

        public static Dictionary<string, int> GivePuntenData() {
            using (MySqlConnection connection = MakeDBConnection()) {
                string query = QueryBuilder.BuildPuntenQuery();

                using (MySqlCommand command = new(query, connection)) {

                    using (MySqlDataReader reader = command.ExecuteReader()) {

                        Dictionary<string, int> puntenData = [];
                        while (reader.Read()) {
                            puntenData["Punten Totaal"] = reader.GetInt32("Punten Totaal");
                            puntenData["Behaalde Punten"] = reader.GetInt32("Behaalde Punten");
                        }

                        CloseDBConnection(connection);
                        return puntenData;
                    }
                }
            }
        }
    }
}