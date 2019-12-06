namespace GroupAssignment.Models {
    internal class ItemDescription {
        public string ItemCode { get; set; }
        public decimal ItemCost { get; set; }
        public string ItemDesc { get; set; }

        public override string ToString() {
            return ItemCode;
        }
    }
}