namespace JT.UI.Common {
    public class DisplayValueMember<T> {
        public DisplayValueMember(string display, T value) {
            Display = display;
            Value = value;
        }
        public string Display { get; }
        public T Value { get; }
    }
}
