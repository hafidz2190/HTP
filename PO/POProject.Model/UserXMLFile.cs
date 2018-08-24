namespace POProject.Model
{
    public class UserXMLFile : BaseEntity
    {
        //USERNAME, FILENAME, FILE_XML, FILE_NOTE, SEPARATE
        public string Username { get; set; }
        public string Filename { get; set; }
        public string File_XML { get; set; }
        public string File_Note { get; set; }
        public char Separate { get; set; }
    }
}