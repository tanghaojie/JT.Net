namespace JT.DB.Common {
    public static class SQLCombinater {
        public static string CombinaterWhereClause(string[] whereClauses) {
            if (whereClauses == null || whereClauses.Length <= 0) { return string.Empty; }
            string where = string.Empty;
            var len = whereClauses.Length;
            for (int i = 0; i < len; i++) {
                var whereClause = whereClauses[i];
                if (i == 0) {
                    where = whereClause;
                } else {
                    where += $" and {whereClause}";
                }
            }
            return where;
        }
    }
}
