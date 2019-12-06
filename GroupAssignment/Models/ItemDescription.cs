namespace GroupAssignment.Models {
    internal class ItemDescription {
        public int ItemCode { get; set; }
        public decimal ItemCost { get; set; }
        public string ItemDesc { get; set; }

        public override string ToString() {
            return ItemCode.ToString();
        }
    }
}