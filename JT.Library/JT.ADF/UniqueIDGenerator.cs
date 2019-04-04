using System;
namespace JT.ADF {
    public class UniqueIDGenerator {
        public int Now { get; private set; }
        public int Increase { get; }
        private readonly object obj = new object();
        public UniqueIDGenerator(int startWith = 0, int increase = 1) {
            if (increase == 0) { throw new Exception(); }
            Now = startWith;
            Increase = increase;
        }
        /// <summary>
        /// Get now and move to next
        /// </summary>
        /// <returns></returns>
        public int Next() {
            lock (obj) {
                var x = Now;
                Now += Increase;
                return x;
            }
        }
    }
}
