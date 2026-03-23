namespace LibrarySystem
{
    public class StudentMember : Member
    {
        public StudentMember(int id, string name, string phone)
            : base(id, name, phone)
        {
        }

        public override int GetMaxBorrowLimit()
        {
            return 3;
        }
    }
}