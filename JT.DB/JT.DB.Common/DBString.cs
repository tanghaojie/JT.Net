namespace JT.DB.Common {
    public class SQLString {
        public const string SELECT = "SELECT";
        public const string FROM = "FROM";
        public const string DISTINCT = "DISTINCT";
        public const string WHERE = "WHERE";
        public const string DROP = "DROP";
        public const string TABLE = "TABLE";
        public const string TRUNCATE = "TRUNCATE";
        public const string VIEW = "VIEW";


        public const string DBPARA = "@para";
        public static string DBPara(int index) => DBPARA + index.ToString();
        /// <summary>
        ///     "
        /// </summary>
        public const string DOUBLE_QUOTATION_MARKS = "\"";
        /// <summary>
        ///     '
        /// </summary>
        public const string SINGLE_QUOTATION_MARKS = "'";
        /// <summary>
        ///     ,
        /// </summary>
        public const string COMMA = ",";
        /// <summary>
        ///     (
        /// </summary>
        public const string LEFT_PARENTHESIS = "(";
        /// <summary>
        ///     )
        /// </summary>
        public const string RIGHT_PARENTHESIS = ")";
        /// <summary>
        ///     *
        /// </summary>
        public const string ASTERISK = "*";
        /// <summary>
        ///     =
        /// </summary>
        public const string EQUAL = "=";
    }
}
