using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudieDashboardDatabase
{
    public static class QueryBuilder
    {
        public static string BuildCursusDataQuery(bool isSorted) {
            string query =
                @"SELECT code, naam, punten, categorie, status" +
                @" FROM cursussen" + 
                @" WHERE status = @cursusStatus";

            if (isSorted) {
                query += @" ORDER BY" + 
                                @" CASE @sortedBy" +
                                    @" WHEN 'categorie' THEN categorie" +
                                    @" WHEN 'naam' THEN naam" +
                                    @" WHEN 'punten' THEN punten" +
                                @" END ASC";
            }
            
            return query;
        }

        public static string BuildGeavanceerdeInstellingenQuery(bool isSorted, List<char> statussen, List<string> richtingen) {
            string query =
                @"SELECT cu.code, cu.naam, cu.punten, cu.categorie, cu.status" +
                @" FROM cursussen cu INNER JOIN categorieën ca ON cu.categorie = ca.naam" +
                @" WHERE";
            if (statussen.Count >= 0) {
                query += @" (cu.status = '!'";
            }
            if (statussen.Count != 0) {
                for (int i = 0; i < statussen.Count; i++) {
                    query += @" OR cu.status = @cursusStatus" + i.ToString();
                }
            }
            query += ")";
                
            
                query += @" AND (ca.richting = 'Algemeen'";
            if (richtingen.Count != 0) {
                for (int i = 0; i < richtingen.Count; i++) {
                    query += @" OR ca.richting = @cursusRichting" + i.ToString();
                }
            }
            query += ")";

            if (isSorted) {
                query += @" ORDER BY" +
                                @" CASE @sortedBy" +
                                    @" WHEN 'categorie' THEN cu.categorie" +
                                    @" WHEN 'naam' THEN cu.naam" +
                                    @" WHEN 'punten' THEN cu.punten" +
                                @" END ASC";
            }
            return query;
        }

        public static string BuildPuntenQuery() {
            string query =
                "SELECT SUM(CASE" +
                    " WHEN Status = 'T' OR Status = 'V' OR Status = 'O' THEN Punten" +
                    " ELSE 0" +
                " END) AS 'Punten Totaal'," +
                " SUM(CASE" +
                    " WHEN Status = 'V' THEN Punten" +
                    " ELSE 0" +
                " END) AS 'Behaalde Punten'" +
                " FROM Cursussen";
            return query;
        }
    }
}
