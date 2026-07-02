namespace BE
{
    public class AccountBook
    {
        public AccountBook()
        {
            Delstatus = false;
        }
        public int id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        /// <summary>
        /// Name of account
        /// </summary>
        public string AccountName { get; set; }
        public Accounts AccountId { get; set; }

        /// <summary>
        /// Name of person
        /// </summary>
        public string PersonName { get; set; }
        public People PeopleId { get; set; }
        /// <summary>
        /// Name of Cost Group
        /// </summary>
        public string CostGroupName { get; set; }
        public CostGroup CostGroupId { get; set; }
        public bool Delstatus { get; set; }
    }
}
