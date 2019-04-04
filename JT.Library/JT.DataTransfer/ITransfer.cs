namespace JT.DataTransfer {
    public interface ITransfer<T, U> {
        void Transfer(T from, U to);
    }
}
