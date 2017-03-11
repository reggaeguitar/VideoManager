namespace VideoManagerDomain
{
    public class TagDto
    {
        public int TagId { get; private set; }
        public string TagName { get; private set; }

        public TagDto(int tagId, string tagName)
        {
            TagId = tagId;
            TagName = tagName;
        }
    }
}