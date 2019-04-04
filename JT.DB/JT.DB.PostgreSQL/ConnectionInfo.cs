namespace JT.DB.PostgreSQL {
    public partial class ConnectionInfo {
        public ConnectionInfo(string server, int port, string username, string password, string database, int commandTimeout = 0) {
            Server = server;
            Port = port;
            Username = username;
            Password = password;
            Database = database;
            CommandTimeout = commandTimeout;
        }
    }
    public partial class ConnectionInfo {
        public static bool operator ==(ConnectionInfo x, ConnectionInfo y) {
            return ReferenceEquals(x, y) ? true : (x is null) ? false : (y is null) ? false : (x.Server == y.Server && x.Port == y.Port && x.Username == y.Username && x.Password == y.Password && x.Database == y.Database && x.CommandTimeout == y.CommandTimeout);
        }
        public static bool operator !=(ConnectionInfo x, ConnectionInfo y) {
            return ReferenceEquals(x, y) ? false : (x is null) ? true : (y is null) ? true : (x.Server != y.Server || x.Port != y.Port || x.Username != y.Username || x.Password != y.Password || x.Database != y.Database || x.CommandTimeout != y.CommandTimeout);
        }
        public static bool Equals(ConnectionInfo x, ConnectionInfo y) {
            return ReferenceEquals(x, y) ? true : (x is null) ? false : (y is null) ? false : (x.Server == y.Server && x.Port == y.Port && x.Username == y.Username && x.Password == y.Password && x.Database == y.Database && x.CommandTimeout == y.CommandTimeout);
        }
        public bool Equals(ConnectionInfo other) {
            return (other is null) ? false : ReferenceEquals(this, other) ? true : (Server == other.Server && Port == other.Port && Username == other.Username && Password == other.Password && Database == other.Database && CommandTimeout == other.CommandTimeout);
        }
        public override bool Equals(object obj) {
            return (obj is null) ? false : ReferenceEquals(this, obj) ? true : (obj is ConnectionInfo other) ? (Server == other.Server && Port == other.Port && Username == other.Username && Password == other.Password && Database == other.Database && CommandTimeout == other.CommandTimeout) : false;
        }
    }
    public partial class ConnectionInfo {
        public override int GetHashCode() {
            unchecked {
                int hashCode = Server.GetHashCode();
                hashCode = (hashCode * 397) ^ Port.GetHashCode();
                hashCode = (hashCode * 397) ^ Username.GetHashCode();
                hashCode = (hashCode * 397) ^ Password.GetHashCode();
                hashCode = (hashCode * 397) ^ Database.GetHashCode();
                hashCode = (hashCode * 397) ^ CommandTimeout.GetHashCode();
                return hashCode;
            }
        }
    }
    public partial class ConnectionInfo {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public int CommandTimeout { get; set; }
    }
}
