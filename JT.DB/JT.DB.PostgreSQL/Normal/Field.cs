using JT.DB.Common;
namespace JT.DB.PostgreSQL.Normal {
    public class Field : DBField<FieldType> {
        public Field(string name, FieldType type, int length, int modify, bool notnull) {
            Name = name;
            Type = type;
            Length = length;
            Modify = modify;
            Notnull = notnull;
        }
    }
}
