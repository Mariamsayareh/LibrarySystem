namespace LibrarySystem
{
    public class TeacherMember : Member
    {
        public TeacherMember(int id, string name, string phone)
            : base(id, name, phone)
        {
        }

        public override int GetMaxBorrowLimit()
        {
            return 5;
        }
    }
}