namespace JT.DB.Common {
    public abstract partial class DBField<T> where T : struct {
        public string Name { get; set; }
        public T Type { get; set; }
        public int Length { get; set; }
        public int Modify { get; set; }
        public bool Notnull { get; set; }
    }
}
